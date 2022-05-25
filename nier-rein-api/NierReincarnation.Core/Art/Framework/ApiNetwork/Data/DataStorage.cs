using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using NierReincarnation.Core.UnityEngine;

#pragma warning disable 618

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Data
{
    // Art.Framework.ApiNetwork.Data.DataStorage
    class DataStorage : IDataStorage
    {
        private string _path; // 0x10
        private string _fileName; // 0x18

        public DataStorage(string fileName = "")
        {
            // CUSTOM: Base directory based on Unity reimplementation
            _path = Path.Combine(Application.UserDataPath, "files", "adrata", "ud");
            _fileName = string.IsNullOrEmpty(fileName) ? ".data.bin" : fileName;
        }

        public string GetFilePath() => Path.Combine(_path, _fileName);

        public T Load<T>(string filePath) where T : new()
        {
            if (!File.Exists(filePath))
                return new T(); // CUSTOM: Have new()-Constraint to create instance of generic type, instead of returning null in default case

            var fileStream = new FileStream(filePath, FileMode.Open);
            var formatter = new BinaryFormatter { Binder = new Binder() };
            var desData = formatter.Deserialize(fileStream);

            fileStream.Dispose();

            return (T)desData;
        }

        public bool Save<T>(string filePath, T value)
        {
            var fileStream = new FileStream(filePath, FileMode.Create);
            new BinaryFormatter().Serialize(fileStream, value);

            fileStream.Dispose();

            return true;
        }
    }

    // CUSTOM: Necessary to bind types from the older .NET Framework to the current version of .NET this application may use
    class Binder : SerializationBinder
    {
        public override Type? BindToType(string assemblyName, string typeName)
        {
            if (typeName == "System.Collections.Generic.Dictionary`2[[Art.Framework.ApiNetwork.Data.Key, Assembly-CSharp-firstpass, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]")
                return typeof(Dictionary<Key, string>);

            if (typeName == "System.Collections.Generic.EnumEqualityComparer`1[[Art.Framework.ApiNetwork.Data.Key, Assembly-CSharp-firstpass, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]")
                return typeof(EnumEqualityComparer<Key>);

            if (typeName == "System.Collections.Generic.KeyValuePair`2[[Art.Framework.ApiNetwork.Data.Key, Assembly-CSharp-firstpass, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]")
                return typeof(KeyValuePair<Key, string>);

            if (typeName == "Art.Framework.ApiNetwork.Data.Key")
                return typeof(Key);

            return null;
        }
    }

    // CUSTOM: Necessary for enum comparison in the above binder
    [Serializable]
    class EnumEqualityComparer<T> : EqualityComparer<T>, ISerializable where T : struct
    {
        [Pure]
        public override bool Equals(T x, T y)
        {
            int x_final = (int)Convert.ChangeType(x, typeof(int));
            int y_final = (int)Convert.ChangeType(y, typeof(int));
            return x_final == y_final;
        }

        [Pure]
        public override int GetHashCode(T obj)
        {
            int x_final = (int)Convert.ChangeType(obj, typeof(int));
            return x_final.GetHashCode();
        }

        public EnumEqualityComparer() { }

        // This is used by the serialization engine.
        protected EnumEqualityComparer(SerializationInfo information, StreamingContext context) { }

        [SecurityCritical]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // For back-compat we need to serialize the comparers for enums with underlying types other than int as ObjectEqualityComparer 
            if (Type.GetTypeCode(System.Enum.GetUnderlyingType(typeof(T))) != TypeCode.Int32)
            {
                info.SetType(typeof(ObjectEqualityComparer<T>));
            }
        }

        // Equals method for the comparer itself. 
        public override bool Equals(object obj)
        {
            return obj is EnumEqualityComparer<T>;
        }

        public override int GetHashCode()
        {
            return GetType().Name.GetHashCode();
        }
    }

    // CUSTOM: Necessary for object comparison in the above binder
    [Serializable]
    internal class ObjectEqualityComparer<T> : EqualityComparer<T>
    {
        [Pure]
        public override bool Equals(T x, T y)
        {
            if (x != null)
            {
                if (y != null) return x.Equals(y);
                return false;
            }
            if (y != null) return false;
            return true;
        }

        [Pure]
        public override int GetHashCode(T obj)
        {
            if (obj == null) return 0;
            return obj.GetHashCode();
        }

        // Equals method for the comparer itself. 
        public override bool Equals(object obj)
        {
            return obj is ObjectEqualityComparer<T>;
        }

        public override int GetHashCode()
        {
            return GetType().Name.GetHashCode();
        }
    }
}

using NierReincarnation.Core.Dark.Preference;
using NierReincarnation.Core.Dark.Variable;

namespace NierReincarnation.Core.Adam.Framework.Gameplay.Paradigm
{
    // Adam.Framework.Gameplay.Paradigm.InternalDataStructure
    class InternalDataStructure : DataStructureBase
    {
        //private List<Data> _datas; // 0x18

        // TODO: Implement data structure variable methods
        public bool GetVariable<TVariable>(string name, out TVariable value) where TVariable : new()
        {
            //var data = GetParam(name);
            //return data.GetVariable(out value);

            if (typeof(TVariable) == typeof(StateUser))
            {
                value = (TVariable)(object)new StateUser
                {
                    Id = PlayerPreference.Instance.ActivePlayer.UserId,
                    Uuid = PlayerPreference.Instance.ActivePlayer.Uuid,
                    Signature = PlayerPreference.Instance.ActivePlayer.Signature
                };
                return true;
            }

            value = new TVariable();
            return false;
        }

        //public Data GetParam(string name)
        //{
        //    return FindDataWithName(name);
        //}

        //private Data FindDataWithName(string name)
        //{
        //    if (_datas == null || _datas.Count < 1)
        //        return null;

        //    foreach (var data in _datas)
        //    {
        //        if (data.name == name)
        //            return data;
        //    }

        //    return null;
        //}
    }
}

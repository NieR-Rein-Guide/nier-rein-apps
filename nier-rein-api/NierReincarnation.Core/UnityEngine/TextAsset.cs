using System;
using System.Text;

namespace NierReincarnation.Core.UnityEngine
{
    public class TextAsset
    {
        public static readonly TextAsset Empty = new TextAsset();

        public string Text { get; } = string.Empty;
        public byte[] Bytes { get; } = Array.Empty<byte>();

        private TextAsset() { }

        public TextAsset(byte[] content)
        {
            Bytes = content;
            Text = Encoding.UTF8.GetString(content);
        }
    }
}

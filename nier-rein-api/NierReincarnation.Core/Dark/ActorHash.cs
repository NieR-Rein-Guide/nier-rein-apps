using MessagePack;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    public struct ActorHash
    {
        [Key(0)] // RVA: 0x1DEB654 Offset: 0x1DEB654 VA: 0x1DEB654
        public int hash { get; set; }

        public ActorHash(int hash)
        {
            this.hash = hash;
        }
    }
}

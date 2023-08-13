namespace NierReincarnation.Core.Dark;

[MessagePackObject]
public struct ActorHash
{
    [Key(0)]
    public int hash { get; set; }

    public ActorHash(int hash)
    {
        this.hash = hash;
    }
}

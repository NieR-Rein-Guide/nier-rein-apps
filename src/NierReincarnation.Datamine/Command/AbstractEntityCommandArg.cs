namespace NierReincarnation.Datamine.Command;

public abstract class AbstractEntityCommandArg<T>
{
    public int EntityId { get; init; }

    public T Entity { get; init; }

    public virtual bool IsValid()
    {
        return Entity != null || EntityId > 0;
    }
}

public abstract class AbstractEntityCommandWithDatesArg<T> : AbstractEntityCommandArg<T>
{
    public DateTimeOffset? FromDate { get; init; }

    public DateTimeOffset? ToDate { get; init; }
}

public abstract class AbstractCommandWithDatesArg
{
    public DateTimeOffset? FromDate { get; init; }

    public DateTimeOffset? ToDate { get; init; }
}

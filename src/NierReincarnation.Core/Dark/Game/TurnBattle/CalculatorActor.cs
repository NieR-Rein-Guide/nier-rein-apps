namespace NierReincarnation.Core.Dark.Game.TurnBattle;

public static class CalculatorActor
{
    public static ActorHash CreateActorHash(PartyHash partyHash, int partyOrder)
    {
        return new ActorHash((partyHash.Hash * 0x10) + partyOrder);
    }
}

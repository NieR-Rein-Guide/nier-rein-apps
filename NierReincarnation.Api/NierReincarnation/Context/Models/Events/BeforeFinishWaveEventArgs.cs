using Art.Framework.ApiNetwork.Grpc.Api.Battle;
using System;

namespace NierReincarnation.Context.Models.Events;

public class BeforeFinishWaveEventArgs : EventArgs
{
    public int WaveNumber { get; }

    public int WaveCount { get; }

    public BattleDetail BattleDetail { get; }

    public BeforeFinishWaveEventArgs(int waveNumber, int waveCount, BattleDetail detail)
    {
        WaveNumber = waveNumber;
        WaveCount = waveCount;
        BattleDetail = detail;
    }
}

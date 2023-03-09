using System;
using System.Timers;

namespace NierReincarnation.Context.Support
{
    public static class CooldownTimer
    {
        private const int TimerDuration_ = 1000;

        public static readonly TimeSpan RateTimeout = TimeSpan.FromMinutes(3);
        private static readonly Timer Timer;

        private static bool _isRunning;
        private static TimeSpan _currentTime;

        public static bool IsRunning => _isRunning;
        public static TimeSpan CurrentCooldown => _currentTime;

        public static event EventHandler<TimeSpan> CooldownStart;
        public static event EventHandler CooldownFinish;
        public static event EventHandler<TimeSpan> Elapsed;

        static CooldownTimer()
        {
            Timer = new Timer(TimerDuration_);
            Timer.Elapsed += Timer_Elapsed;
        }

        public static void Start()
        {
            if (IsRunning)
                return;

            _isRunning = true;
            _currentTime = RateTimeout;

            Timer.Start();

            OnCooldownStart(RateTimeout);
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _currentTime -= TimeSpan.FromSeconds(1);

            if (_currentTime.TotalMilliseconds > 0)
            {
                OnElapsed(_currentTime);
            }
            else
            {
                Timer.Stop();

                OnCooldownFinish();

                _isRunning = false;
            }
        }

        private static void OnCooldownStart(TimeSpan currentTime)
        {
            CooldownStart?.Invoke(null, currentTime);
        }

        private static void OnCooldownFinish()
        {
            CooldownFinish?.Invoke(null, EventArgs.Empty);
        }

        private static void OnElapsed(TimeSpan currentTime)
        {
            Elapsed?.Invoke(null, currentTime);
        }
    }
}

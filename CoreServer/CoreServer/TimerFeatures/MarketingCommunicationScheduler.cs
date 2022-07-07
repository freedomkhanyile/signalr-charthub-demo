using System;
using System.Threading;

namespace CoreServer.TimerFeatures
{
    public class MarketingCommunicationScheduler
    {
        private Timer _timer;
        private AutoResetEvent _autorResetEvent;
        private Action _action;
        public DateTime TimerStarted;
        public MarketingCommunicationScheduler(Action action)
        {
            _action = action;
            _autorResetEvent = new AutoResetEvent(false);
            _timer = new Timer(ExecuteTimer, _autorResetEvent, 10000,2000);
            TimerStarted =DateTime.UtcNow.ToLocalTime();
        }

        public void ExecuteTimer(object stateInfo)
        {
            _action();
            if ((DateTime.UtcNow.ToLocalTime() - TimerStarted).Seconds > 60) {
                _timer.Dispose();
            }
        }
    }
}

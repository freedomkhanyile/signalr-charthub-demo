using System;
using System.Threading;

namespace CoreServer.TimerFeatures
{
    public class TimerManager
    {
        public TimerManager(Action action)
        {

            _action = action;
            _autorResetEvent = new AutoResetEvent(false);
            _timer = new Timer(ExecuteTimer, _autorResetEvent, 5000, 10000);
            TimerStarted = DateTime.UtcNow.ToLocalTime();
        }
        private Timer _timer;
        private AutoResetEvent _autorResetEvent;
        private Action _action;

        public DateTime TimerStarted;


        // methods

        public void ExecuteTimer(object stateInfo)
        {
            _action();
            if ((DateTime.UtcNow.ToLocalTime() - TimerStarted).Seconds > 60) {
                _timer.Dispose();
            }
        }
    }
}

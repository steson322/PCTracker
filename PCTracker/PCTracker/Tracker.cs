using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCTracker
{
    /// <summary>
    /// Tracker object
    /// </summary>
    public abstract class Tracker
    {
        /// <summary>
        /// Indicate if timer started
        /// </summary>
        public bool Started { get; private set; }

        /// <summary>
        /// Timer of iteration
        /// </summary>
        protected System.Timers.Timer Timer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Interval"></param>
        public Tracker(int Interval)
        {
            this.Started = false;
            this.Timer = new System.Timers.Timer(Interval);
            this.Timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Tick);
        }

        public void Start()
        {
            Started = true;
            Timer.Enabled = true;
        }

        public void Stop()
        {
            Started = false;
            Timer.Enabled = false;
        }

        void Timer_Tick(object sender, System.Timers.ElapsedEventArgs args)
        {
            Timer.Enabled = false;
            try
            {
                TimerAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (Started)
            {
                Timer.Enabled = true;
            }
        }

        protected abstract void TimerAction();
    }
}

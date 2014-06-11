using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace PCTracker
{
    public partial class Service1 : ServiceBase
    {
        IPTracker ipTracker;

        public Service1()
        {
            InitializeComponent();
            ipTracker = new IPTracker(3000);
        }

        public void Start()
        {
            OnStart(null);
        }

        public void Stop()
        {
            OnStop();
        }

        protected override void OnStart(string[] args)
        {
            ipTracker.Start();
        }

        protected override void OnStop()
        {
            ipTracker.Stop();
        }
    }
}

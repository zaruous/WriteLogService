using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace WriteLogService
{
    public partial class WriteLogService : ServiceBase
    {
        private static readonly log4net.ILog LOGGER = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Timer tm;
        public WriteLogService()
        {
            InitializeComponent();
        }

        WriteLogImpl s;
        protected override void OnStart(string[] args)
        {
            s= new WriteLogImpl();
            tm = new Timer();
            tm.Interval = 50;
            tm.Elapsed += Tm_Elapsed;
            tm.Start();
            LOGGER.Debug("WriteLogService OnStart");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tm_Elapsed(object sender, ElapsedEventArgs e)
        {
            s.Receive();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnStop()
        {
            LOGGER.Debug("WriteLogService OnStop");
            if (s!=null)
                s.Dispose();
            tm.Stop();
        }
    }
}

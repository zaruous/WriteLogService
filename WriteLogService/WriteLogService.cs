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

namespace WriteLogService
{
    public partial class WriteLogService : ServiceBase
    {
        private static readonly log4net.ILog LOGGER = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public WriteLogService()
        {
            InitializeComponent();
        }
        

        protected override void OnStart(string[] args)
        {
        }
       
        protected override void OnStop()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WriteLogService
{
    internal static class Program
    {
        
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        static void Main()
        {
            /*
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WriteLogService()
            };
            ServiceBase.Run(ServicesToRun);
            */

            new WriteLogImpl().run();
        }
    }
}

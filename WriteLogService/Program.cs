using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.ServiceProcess;
using System.Text;
using System.Threading;

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

#if DEBUG
            using (WriteLogImpl instance = new WriteLogImpl())
            {
                while(true) {
                    instance.run();
                }
            }
                
            #else
                        ServiceBase[] ServicesToRun;
                        ServicesToRun = new ServiceBase[]
                        {
                            new WriteLogService()
                        };
                        ServiceBase.Run(ServicesToRun);
            #endif

        }
    }
}

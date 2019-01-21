using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Configuration;

namespace AIManageRecurringActivity
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static void Main()
        {
            AIManageRecurring service = new AIManageRecurring();

            //To debug set IsConsole = true;
            bool bIsConsole = false;

            if (bIsConsole)
            {
                //MessageLogs.WriteLog("Start Service Forcefully");
                service.ForceStart();
               // Console.ReadLine();

               // MessageLogs.WriteLog("Stop Service Forcefully");
                service.ForceStop();
              //  Console.WriteLine("Service has stopped.");
            }
            else
            {
                ServiceBase[] ServicesToRun = new ServiceBase[] { service };
                // MessageLogs.WriteLog("Run Service");
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}

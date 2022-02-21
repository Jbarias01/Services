using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Application_Monitor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Monitor()
            };
            ServiceBase.Run(ServicesToRun);

            // In interactive and debug mode ?
            if (Environment.UserInteractive && System.Diagnostics.Debugger.IsAttached)
            {
                // Simulate the services execution
                RunInteractiveServices(ServicesToRun);
            }
            else
            {
                // Normal service execution
                ServiceBase.Run(ServicesToRun);
            }            
        }

        static void RunInteractiveServices(ServiceBase[] servicesToRun)
        {
            try
            {
                bool result = File.Exists(@"C:\Nicket (Version Produccion) QA\TuPana.exe");
                if (!(result))
                {
                    return;
                }

                Process[] instancia = Process.GetProcessesByName($"TuPana");
                if (instancia.Length == 1)
                {
                    return ;
                }

                System.Diagnostics.Process.Start(@"C:\Nicket (Version Produccion) QA\TuPana.exe");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

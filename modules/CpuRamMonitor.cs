using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;


namespace dataExplorer.modules
{
    public class CpuRamMonitor
    {
        private readonly PerformanceCounter _cpuCounter;
        private readonly PerformanceCounter _ramCounter;

        public CpuRamMonitor()
        {
            //criar contadores de desempenho
            _cpuCounter = new PerformanceCounter("Processor","% Processor Time", "_Total");
            _ramCounter = new PerformanceCounter("Memory","Available MBytes");

        }
        
        public void DisplayCpuRamInfo()
        {
            //obter dados de cpu e ram
            float cpuUsage = _cpuCounter.NextValue();
            float availableRAM = _ramCounter.NextValue();

            Console.WriteLine("Informações da CPU e RAM");
            Console.WriteLine($"Uso de CPU: {cpuUsage:F2}%");
            Console.WriteLine($"Memória disponível: {availableRAM:F2} MB");
            Console.WriteLine();
        }
        
    }
}
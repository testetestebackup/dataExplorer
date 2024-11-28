using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibreHardwareMonitor.Hardware;

namespace dataExplorer.Models
{
    public class TemperatureMonitor
    {
        private readonly Computer _computer;

        public TemperatureMonitor()
        {
            //inicia o monitoramento
            _computer = new Computer()
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsStorageEnabled = true,
                IsMotherboardEnabled = true,

            };
            _computer.Open();

        }

        // public void DebugHardware()
        // {
        //     foreach (IHardware hardware in _computer.Hardware)
        //     {
        //         hardware.Update();
        //         Console.WriteLine($"Hardware: {hardware.Name}, Tipo: {hardware.HardwareType}");
        //         foreach (ISensor sensor in hardware.Sensors)
        //         {
        //             Console.WriteLine($"  Sensor: {sensor.Name}, Tipo: {sensor.SensorType}, Valor: {sensor.Value?.ToString() ?? "N/A"}");
        //         }
        //     }
        // }

        //EXIBE TODAS as informações incluindo sensores
        public void DisplayTemperatures()
        {
            Console.WriteLine("Temperaturas");

            foreach(IHardware hardware in _computer.Hardware)
            {
                hardware.Update(); // atualiza os dados do hardware

                Console.WriteLine($"CPU: {hardware.Name}");
                foreach (ISensor sensor in hardware.Sensors)
                {
                    Console.WriteLine($"  Sensor: {sensor.Name}, Tipo: {sensor.SensorType}, Valor: {sensor.Value?.ToString() ?? "N/A"}");

                }
            }
        }

        public void DisplayBasicInfo()
        {
            Console.WriteLine("Temperaturas básicas:");
            foreach(IHardware hardware in _computer.Hardware)
            {
                if(hardware.HardwareType == HardwareType.Cpu || hardware.HardwareType == HardwareType.GpuNvidia || hardware.HardwareType == HardwareType.GpuAmd)
                {
                    hardware.Update();
                    foreach (ISensor sensor in hardware.Sensors)
                    {
                        if(sensor.SensorType == SensorType.Temperature && (sensor.Name.Contains("Core") || sensor.Name.Contains("GPU")))
                        {
                            Console.WriteLine($"Hardware: {hardware.Name}, Temperatura: {sensor.Value?.ToString("0.##")} °C");
                        }
                    }
                }
            }
        }


    }
}
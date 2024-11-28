using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace dataExplorer.modules
{
    public class DiskMonitor
    {
        
        public void DisplayDiskInfo()
        {
            Console.WriteLine("Informações dos Discos:");

            //obter informações de todos discos
            foreach(var drive in DriveInfo.GetDrives())
            {
                if(drive.IsReady)
                {
                    long totalSpace = drive.TotalSize / (1024 * 1024 * 1024); //em GB
                    long availableSpace = drive.AvailableFreeSpace / (1024 * 1024 * 1024);
                    Console.WriteLine($"[Disco {drive.Name}] Espaço total em disco: {totalSpace} GB, Espaço disponível no disco: {availableSpace} GB");
                    
                }
                else
                {
                    Console.WriteLine($"[Disco {drive.Name}] Não está pronto para uso.");
                }
            }
            Console.WriteLine();
        }

        public void DisplayMainDiskSpace()
        {
            DriveInfo mainDrive = DriveInfo.GetDrives()[0];
            long totalSpace = mainDrive.TotalSize / (1024 * 1024 * 1024); // Em GB
            long availableSpace = mainDrive.AvailableFreeSpace / (1024 * 1024 * 1024); // Em GB
            Console.WriteLine($"Espaço total do disco {mainDrive.Name}: {totalSpace} GB, Espaço disponível no disco {mainDrive.Name}: {availableSpace} GB");
        }
    }
}
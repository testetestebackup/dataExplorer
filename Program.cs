using System;
using dataExplorer.Models;
using dataExplorer.modules;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Bem-vindo ao");
        Console.WriteLine("Monitor de Sistema dataExplorer");
        Console.WriteLine("------------------");
        Console.WriteLine();
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Visualizar informações básicas");
        Console.WriteLine("2 - Visualizar informações completas");
        Console.WriteLine("3 - Sair");
        Console.Write("Sua escolha:");

        var choice = Console.ReadLine();

        if(choice == "3")
        {
            Console.WriteLine("Encerrando o programa...");
            return;
        }

        //iniciar monitores
        var cpuRamMonitor = new CpuRamMonitor();
        var diskMonitor = new DiskMonitor();
        var tempMonitor = new TemperatureMonitor();


        while(true)
        {
            Console.Clear(); //limpa a tela

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nExbindo informações básicas:");
                    cpuRamMonitor.DisplayCpuRamInfo();
                    diskMonitor.DisplayMainDiskSpace();
                    tempMonitor.DisplayBasicInfo();

                    break;

                case "2":
                    Console.WriteLine("\nExibindo informações completas:");
                    cpuRamMonitor.DisplayCpuRamInfo();
                    diskMonitor.DisplayDiskInfo();
                    tempMonitor.DisplayTemperatures();

                    break;            

                case "default":
                    Console.WriteLine("Opção inválida. Encerrando o programa.");

                    break;
            }

            Console.WriteLine("\nAtualizando em 2 segundos... Pressione Ctrl+C para sair.");
            Thread.Sleep(2000);
        }
    }
}

//  //exibir resultados no console
//             Console.Clear();
            
//             //Exibir info de cada monitor
//             cpuRamMonitor.DisplayCpuRamInfo();
//             diskMonitor.DisplayDiskInfo();
//             tempMonitor.DisplayTemperatures();
            
//             // pausar para atualizar a cada 2 segundos
//             System.Threading.Thread.Sleep(2000);
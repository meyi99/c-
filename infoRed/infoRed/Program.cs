using System;
using System.Net.NetworkInformation;

namespace infoRed
{
    class MainClass
    {

        static int Menu()
        {
            int opcion;
            Console.WriteLine("MENÚ");
            Console.WriteLine("------------------");
            Console.WriteLine("1. Información");
            Console.WriteLine("2. Ping");
            Console.WriteLine("3. Salir");
            Console.WriteLine("¿Que desea hacer?");
            opcion = int.Parse(Console.ReadLine());
            return opcion;
        }

        static void InfoRed()
        {
            NetworkInterface[] interfacesRed = NetworkInterface.GetAllNetworkInterfaces();

            foreach(NetworkInterface adaptador in interfacesRed)
            {
                Console.WriteLine(adaptador.Description);
                Console.WriteLine("Tipo de adaptador:{0}", adaptador.NetworkInterfaceType);
                Console.WriteLine("Dirección MAC:{0}", adaptador.GetPhysicalAddress().ToString());

                if (adaptador.Supports(NetworkInterfaceComponent.IPv4))
                {
                    Console.WriteLine("Versión del protocolo IP: IPv4");
                }
                else
                {
                    Console.WriteLine("Versión del protocolo IP: IPv6");
                }
                Console.WriteLine("-----------------------------------");
            }
        }

        static void Ping(string ip)
        {
            Ping ping = new Ping();
            PingReply respuesta = ping.Send(ip);

            if(respuesta.Status.ToString() == "Success")
            {
                Console.WriteLine("Correcto, host accesible");
            }
            else
            {
                Console.WriteLine("Incorrecto, hot inaccesible");
            }
        }

        public static void Main(string[] args)
        {
            int op;
            string ip;

            do
            {
                op = Menu();
                switch (op)
                {
                    case 1:
                        InfoRed();
                        break;

                    case 2:
                        Console.WriteLine("Indica la dirección IP: ");
                        ip = Console.ReadLine();
                        Ping(ip);
                        break;

                    case 3:
                        Console.WriteLine("El programa ha finalizado");
                        break;

                    default:
                        Console.WriteLine("Opción incorrecta");
                        break;
                }
                Console.ReadLine();
            } while (op != 3);
        }
    }
}

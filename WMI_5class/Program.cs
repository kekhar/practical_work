using System;
using System.Management;

namespace WMI_5class
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ManagementScope scope = new ManagementScope("\\\\.\\root\\CIMV2");
                scope.Connect();

                string[] wqlQueries = {
                    "SELECT * FROM Win32_Process",
                    "SELECT * FROM Win32_LogicalDisk",
                    "SELECT * FROM Win32_NetworkAdapter",
                    "SELECT * FROM Win32_Service",
                    "SELECT * FROM Win32_Printer"
                };

                foreach (string query in wqlQueries)
                {
                    ObjectQuery objectQuery = new ObjectQuery(query);
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, objectQuery);

                    Console.WriteLine($"Результаты запроса: {query}");
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        foreach (PropertyData property in obj.Properties)
                        {
                            Console.WriteLine($"{property.Name}: {property.Value}");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("---------------$$$-----------------");
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Сделал работу: Малинкин Кирилл 32ИС-21К");
                Console.ReadLine();
            }
        }
    }
}

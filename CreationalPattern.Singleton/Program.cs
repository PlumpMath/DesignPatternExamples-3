using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LoadBalancer balancer = LoadBalancer.Instance;

                for (int i = 0; i < 100; i++)
                    Console.WriteLine("Selected: " + balancer.Server);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }            
        }
    }
}

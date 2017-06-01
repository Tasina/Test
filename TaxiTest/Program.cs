using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static TaxiService service;

    static void Main(string[] args)
    {
        IKernel kernel = new StandardKernel(new NinjectTaxiModule());
        ITaxi cab = kernel.Get<TaxiCab>();
        ITaxi bus = kernel.Get<TaxiBus>();

        service = new TaxiService(cab, bus);
        CallTaxi();
    }

    public static void CallTaxi()
    {
        Console.WriteLine("You have called Taxi service");
        string quit = "";
        do
        {
            Console.Write("How many people are you? = ");
            int persons = int.Parse(Console.ReadLine());

            Console.Write("How many km you wanna go? = ");
            float km = float.Parse(Console.ReadLine());
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Total price: " + service.CalculateTotalPrice(km, persons) + " DKK");

            quit = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(quit));
    }
}


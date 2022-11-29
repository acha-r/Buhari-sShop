using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buhari_sShop
{
    internal partial class HowToPayBuhari
    {
        internal void AddRecord()
        {
        start:
            Console.WriteLine("Press to view\n\n1. Daily installment list.\n2. Weekly installment list.\n3. Monthly installment list.\n4. Yearly installment list.\n");
            string userInput = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Customers in this plan and pending payment\nName\t\t\t\tAmount");

            switch (userInput)
            {
                case "1":
                    foreach (var cust in DailyInstallmentList)
                    {
                        Console.WriteLine(cust);
                    }
                    break;
                case "2":
                    foreach (var cust in WeeklyInstallmentList)
                    {
                        Console.WriteLine(cust);
                    }
                    break;
                case "3":
                    foreach (var cust in MonthlyInstallmentList)
                    {
                        Console.WriteLine(cust);
                    }
                    break;
                case "4":
                    foreach (var cust in YearlyInstallmentList)
                    {
                        Console.WriteLine(cust);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    goto start;
            }
        }

        internal void NextSteps()
        {
        nextsteps:
            Console.WriteLine("\nWould you like to add a new customer information? \n\n1. Yes\n2. No\n");
            string userInput = Console.ReadLine();
            Console.Clear();

            switch (userInput)
            {
                case "1":
                    HowToPayBuhari howToPayBuhari = new HowToPayBuhari();
                    break;
                case "2":
                    return;
                default:
                    Console.WriteLine("Invalid input");
                    goto nextsteps;
            }
        }
    }
}

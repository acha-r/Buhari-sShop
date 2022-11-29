using System.Text.RegularExpressions;

namespace Buhari_sShop
{

    internal partial class HowToPayBuhari
    {
        private static DateOnly dayOfPurchase = DateOnly.FromDateTime(DateTime.Now);
        private static DateOnly dueDate = default;

        public string CustomerName { get; set; }
        public decimal AmtToPay { get; set; }
        private static decimal FirstDeposit { get; set; }
        private static decimal AmtRemaining { get; set; }
        private string PaymentDuration { get; set; }

        List<string> DailyInstallmentList = new List<string>();
        List<string> WeeklyInstallmentList = new List<string>();
        List<string> MonthlyInstallmentList = new List<string>();
        List<string> YearlyInstallmentList = new List<string>();

        public HowToPayBuhari()
        {
            DailyInstallmentList.Add("Jimo\t\t\t\tN 20000");
            DailyInstallmentList.Add("Nkeiru\t\t\t\tN 12000");
            WeeklyInstallmentList.Add("Jimo\t\t\t\tN 40000");
            WeeklyInstallmentList.Add("Nkeiru\t\t\t\tN 32000");
            MonthlyInstallmentList.Add("Jimo\t\t\t\tN 300000");
            MonthlyInstallmentList.Add("Nkeiru\t\t\t\tN 402000");
            YearlyInstallmentList.Add("Jimo\t\t\t\tN 2000000");
            YearlyInstallmentList.Add("Nkeiru\t\t\t\tN 12000000");

            Console.Title = "Bubu's Shop";
            GetCustomerDetails();
            ChoosePaymentPlan();
        }

        public string GetCustomerDetails()
        {
            Regex regex = new Regex("[^a-zA-z ]");
        custName:
            Console.WriteLine("Enter customer name below");

            try
            {
                CustomerName = Console.ReadLine().ToUpper().Trim();
                Console.Clear();
                if (regex.IsMatch(CustomerName) || string.IsNullOrEmpty(CustomerName)) throw new InvalidCustomerNameException($"Sorry, the name, " +
                    $"{CustomerName} contains invalid characters. Please try again\n");

            }
            catch (InvalidCustomerNameException e)
            {
                Console.WriteLine(e.Message);
                goto custName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto custName;
            }

            Console.WriteLine("Enter total worth of goods");
        amount:
            try
            {
                AmtToPay = decimal.Parse(Console.ReadLine());
                if (AmtToPay < 10000)
                {
                    throw new InvalidAmountException("\nSorry, Cannot create any plan for purchase less than N 10,000.\n");
                }
                else if (AmtToPay > 20_000_000)
                {
                    throw new InvalidAmountException("\nEhm, unless, this person is buying the shop, this amount is not possible\n");
                }
                Console.Clear();
            }
            catch (InvalidAmountException e)
            {
                Console.WriteLine(e.Message);
            retry:
                Console.WriteLine("Press\n1. to exit\n2. To input new purchase information\n");
                string nextSteps = Console.ReadLine();
                Console.Clear();
                switch (nextSteps)
                {
                    case "1":
                        Environment.Exit(0);
                        break;
                    case "2":
                        goto custName;
                    default:
                        Console.WriteLine("Invalid input.");
                        goto retry;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.Clear();
                Console.WriteLine("Bubu enter a valid amount");
                goto amount;
            }
            return CustomerName;
        }
    }
}

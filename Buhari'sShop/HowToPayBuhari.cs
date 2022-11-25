namespace Buhari_sShop
{

    internal class HowToPayBuhari
    {
        public string CustomerName { get; init; }
        public decimal AmtToPay { get; init; }
        private static decimal FirstDeposit { get; set; }
        private static decimal AmtRemaining { get; set; }
        private bool PaymentCompleted { get; set; }
        public DateTime PaymentDuration { get; set; }

        List<HowToPayBuhari> weeklyInstallment = new List<HowToPayBuhari>();
        List<HowToPayBuhari> biWeeklyInstallment = new List<HowToPayBuhari>();
        List<HowToPayBuhari> monthlyInstallment = new List<HowToPayBuhari>();
        List<HowToPayBuhari> sixMonthInstallment = new List<HowToPayBuhari>();
        List<HowToPayBuhari> yearlyInstallment = new List<HowToPayBuhari>();

        public HowToPayBuhari()
        {

        }

        public HowToPayBuhari(string custName, decimal amt)
        {
            CustomerName = custName;
            AmtToPay = amt;

            PaymentPlan();
        }


        private decimal DailyPlan()
        {
            decimal dailyAmt = 0;

            try
            {
                if (AmtToPay < 1500)
                {
                    throw new WrongPlanException("Amount to pay MUST be greater than or equal to N1500. Cannot create plan\n");
                }
                else
                {
                    FirstDeposit = AmtToPay / 10;
                    AmtRemaining = AmtToPay - FirstDeposit;
                    dailyAmt = decimal.Round((AmtRemaining / 7), 2);
                    PaymentDuration = DateTime.Now.AddDays(7);

                    Console.WriteLine($"{CustomerName}'s payment information\nTotal amount to pay: N{AmtToPay}\nFirst deposit: N{FirstDeposit}\n\n" +
                        $"Remaining payment: {AmtRemaining}\nDaily payment of {dailyAmt}\nDuration: from {DateTime.Now}\n          till {PaymentDuration}");
                }
            }
            catch (WrongPlanException e)
            {
                Console.WriteLine(e.Message);
                PaymentPlan();
            }
            return dailyAmt;
        }

        public void PaymentPlan()
        {
            Console.WriteLine($"Choose payment plan for {CustomerName}. Press\n1. Daily plan\n2. Weekly plan\n3. Bi-weekly plan\n4. Monthly plan\n5. Six-month plan" +
                "\n6. Yearly plan\n");

            string buhariInput = Console.ReadLine();

            switch (buhariInput)
            {
                case "1":
                    DailyPlan();
                    break;
                case "2":
                    //WeeklyPlan();
                    break;


            }

        }

        /* public void AddToRecord()
         {
             HowToPayBuhari payy = new HowToPayBuhari(CustomerName, AmtToPay);
             if (pa)
         }*/


    }
}

namespace Buhari_sShop
{
    internal partial class HowToPayBuhari
    {
        public void ChoosePaymentPlan()
        {
        start:
            Console.WriteLine($"Choose payment plan that applies for {CustomerName}. Press\n1. Daily plan\nRange: N10,000 - N20,000\n\n" +
                $"2. Weekly plan\nRange: N20,000-  N50,000\n\n3. Monthly plan\nRange: N50,000 - N1,000,000\n\n4. Yearly plan\nRange: N1,000,000 - N20,000,000");

            string buhariInput = Console.ReadLine();
            Console.Clear();

            switch (buhariInput)
            {
                case "1":
                    DailyPlan();
                    break;
                case "2":
                    WeeklyPlan();
                    break;
                case "3":
                    MonthlyPlan();
                    break;
                case "4":
                    YearlyPlan();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    goto start;
            }
        }

        internal void DailyPlan()
        {
            try
            {
                if (AmtToPay > 20_000) throw new WrongPlanException("Amount is too large for daily plan. Choose a different plan\n");
            }
            catch (WrongPlanException e)
            {
                Console.WriteLine(e.Message);
                ChoosePaymentPlan();
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry, we're not sure why, but an error occured");
            }

            decimal dailyAmt = 0;
            FirstDeposit = AmtToPay / 10;
            AmtRemaining = AmtToPay - FirstDeposit;
            PaymentDuration = "7 days";
            dueDate = dayOfPurchase.AddDays(7);
            dailyAmt = decimal.Round((AmtRemaining / 7), 2);

            Console.WriteLine($"{CustomerName}'s payment information\n\nTotal amount to pay: N{AmtToPay}\nCollect first deposit: N{FirstDeposit}\n\n" +
                $"Remaining payment: {AmtRemaining}\nDaily payment: {dailyAmt}\nDuration (7 days): from {dayOfPurchase.DayOfWeek}, {dayOfPurchase}\n          " +
                $"till {dueDate.DayOfWeek}, {dueDate}");
            DailyInstallmentList.Add($"{CustomerName}\t\t\t\tN {AmtRemaining}");
            NextSteps();
        }

        internal void WeeklyPlan()
        {
            try
            {
                if (AmtToPay < 20_000 || AmtToPay > 50_000) throw new WrongPlanException("Amount is too small or large for weekly plan. Choose a different plan\n");
            }
            catch (WrongPlanException e)
            {
                Console.WriteLine(e.Message);
                ChoosePaymentPlan();
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry, we're not sure why, but an error occured");
            }
            decimal weeklyAmt;
            FirstDeposit = (AmtToPay / 10) * 3;
            AmtRemaining = AmtToPay - FirstDeposit;
            PaymentDuration = "4 weeks";
            dueDate = dayOfPurchase.AddMonths(1);
            weeklyAmt = decimal.Round((AmtRemaining / 4), 2);

            Console.WriteLine($"{CustomerName}'s payment information\n\nTotal amount to pay: N{AmtToPay}\nCollect first deposit: N{FirstDeposit}\n\n" +
                $"Remaining payment: {AmtRemaining}\nWeekly payment: {weeklyAmt}\nDuration (4 weeks): from {dayOfPurchase.DayOfWeek}, {dayOfPurchase}\n          " +
                $"till {dueDate.DayOfWeek}, {dueDate}");
            WeeklyInstallmentList.Add($"{CustomerName}\t\t\t\tN {AmtRemaining}");
            NextSteps();
        }

        internal void MonthlyPlan()
        {
            FirstDeposit = (AmtToPay / 10) * 3;
            AmtRemaining = AmtToPay - FirstDeposit;
            decimal monthlyAmt = 0;

            try
            {
                if (AmtToPay >= 50_000 && AmtToPay < 500_000)
                {
                    PaymentDuration = "6 months";
                    dueDate = dayOfPurchase.AddMonths(6);
                    monthlyAmt = decimal.Round((AmtRemaining / 6), 2);

                    Console.WriteLine($"{CustomerName}'s payment information\n\nTotal amount to pay: N{AmtToPay}\nCollect first deposit: N{FirstDeposit}\n\n" +
                        $"Remaining payment: {AmtRemaining}\nMonthly payment: {monthlyAmt}\nDuration (six months): from {dayOfPurchase.DayOfWeek}, {dayOfPurchase}\n          " +
                        $"till {dueDate.DayOfWeek}, {dueDate}");
                }
                else if (AmtToPay >= 500_000 && AmtToPay < 20_000_000)
                {
                    PaymentDuration = "12 months";
                    dueDate = dayOfPurchase.AddMonths(12);
                    monthlyAmt = decimal.Round((AmtRemaining / 12), 2);

                    Console.WriteLine($"{CustomerName}'s payment information\n\nTotal amount to pay: N{AmtToPay}\nCollect first deposit: N{FirstDeposit}\n\n" +
                        $"Remaining payment: {AmtRemaining}\nMonthly payment: {monthlyAmt}\nDuration: from {dayOfPurchase.DayOfWeek}, {dayOfPurchase}\n          " +
                        $"till {dueDate.DayOfWeek}, {dueDate}");
                }
                else throw new WrongPlanException("Amount is too small or too large for monthly plan. Choose a different plan\n");
            }
            catch (WrongPlanException e)
            {
                Console.WriteLine(e.Message);
                ChoosePaymentPlan();
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry, we're not sure why, but an error occured");
            }
            MonthlyInstallmentList.Add($"{CustomerName}\t\t\t\tN {AmtRemaining}");
            NextSteps();            
        }

        internal void YearlyPlan()
        {
            decimal yearlyAmt = 0;
            try
            {
                if (AmtToPay >= 1_000_000)
                {
                    FirstDeposit = AmtToPay / 10 * 3;
                    AmtRemaining = AmtToPay - FirstDeposit;
                    PaymentDuration = "2 years";
                    dueDate = dayOfPurchase.AddYears(2);
                    yearlyAmt = decimal.Round((AmtRemaining / 2), 2);

                    Console.WriteLine($"{CustomerName}'s payment information\n\nTotal amount to pay: N{AmtToPay}\nCollect first deposit: N{FirstDeposit}\n\n" +
                        $"Remaining payment: {AmtRemaining}\nYearly payment: {yearlyAmt}\nDuration (2 years): from {dayOfPurchase.DayOfWeek}, {dayOfPurchase}\n          " +
                        $"till {dueDate.DayOfWeek}, {dueDate}");
                    YearlyInstallmentList.Add($"{CustomerName}\t\t\t\tN {AmtRemaining}");
                    NextSteps();
                }
                else throw new InvalidAmountException("Amount is too small for this plan. Try a different plan\n");
            }
            catch (InvalidAmountException e)
            {
                Console.WriteLine(e.Message);
                ChoosePaymentPlan();
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry, we're not sure why, but an error occured");
            }
        }
    }
}

namespace Buhari_sShop
{
    internal class Application
    {
        public static void Start()
        {
            Console.WriteLine("Hello Bubu\n");

            HowToPayBuhari payBuhari = new HowToPayBuhari();

        next:
            Console.WriteLine("Next steps. Press \n1. To view payment lists\n\n2. To exit\n");
            string userInput = Console.ReadLine();
            Console.Clear();


            switch (userInput)
            {
                case "1":
                    payBuhari.AddRecord();
                    break;
                case "2":
                    Console.WriteLine("Goodbye");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    goto next;
                    
            }                        
        }
    }
}

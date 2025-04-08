namespace _06_03_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Money money1 = new Money(10, 50);
                Money money2 = new Money(5, 75);

                Console.WriteLine($"Money 1: {money1}");
                Console.WriteLine($"Money 2: {money2}");

                Money sum = money1 + money2;
                Console.WriteLine($"Sum: {sum}");

                Money difference = money1 - money2;
                Console.WriteLine($"Difference: {difference}");

                Money divided = money1 / 2;
                Console.WriteLine($"Divided by 2: {divided}");

                Money multiplied = money1 * 3;
                Console.WriteLine($"Multiplied by 3: {multiplied}");

                Money incremented = ++money1;
                Console.WriteLine($"Incremented Money 1: {incremented}");

                Money decremented = --money1;
                Console.WriteLine($"Decremented Money 1: {decremented}");

                Console.WriteLine($"Money 1 < Money 2: {money1 < money2}");
                Console.WriteLine($"Money 1 > Money 2: {money1 > money2}");
                Console.WriteLine($"Money 1 == Money 2: {money1 == money2}");
                Console.WriteLine($"Money 1 != Money 2: {money1 != money2}");
            }
            catch (BankruptException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }
        }
    }
}

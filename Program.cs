using System.Reflection;

namespace Problems
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            // Build a collection of all methods
            var type = Type.GetType("Problems.Program");

            if (type != null)
            {
                var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Static).ToList();

                // Print list of all pairs; ask for user input to select method to run
                for (int i = 1; i < methods.Count + 1; i += 1)
                {
                    Console.WriteLine($"  ({i}): {methods[i - 1].Name}");
                }

                Console.Write("Choose a method number to run: ");
                int.TryParse(Console.ReadLine(), out var userSelection);

                // Dynamically invoke method based on user input
                try
                {
                    methods[userSelection - 1].Invoke(null, null);
                    Console.WriteLine();
                }
                catch(ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Bad method number");
                }
            }
            else
            {
                Console.WriteLine("Unable to get methods");
            }
        }
    }
}
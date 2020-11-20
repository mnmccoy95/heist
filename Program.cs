using System;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");
            Play();
        }
        static void Play()
        {
            int skill1 = 0;
            double courage1 = 0;
            Console.Write("Enter a team member's name: ");
            string member1 = Console.ReadLine();
            Console.Write("Enter skill level: ");
            try
            {
                skill1 = Int32.Parse(Console.ReadLine());
                Console.Write("Enter courage level: ");
                courage1 = Convert.ToDouble(Console.ReadLine());
                if(courage1 < 0 | courage1 > 2)
                {
                    Console.Write("Enter courage level (between 0 and 2): ");
                    courage1 = Convert.ToDouble(Console.ReadLine());
                }
                else
                {
                Console.WriteLine($"{member1} has skill level {skill1} and courage factor {courage1}.");
                }
            }
            catch
            {
                Console.WriteLine("Something went wrong!");
            }
        }
    }
}

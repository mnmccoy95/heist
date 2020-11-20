using System;
using System.Collections.Generic;
using System.Linq;

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
            int diff = 0;
            bool tryAgain = true;
            while(tryAgain)
            {
                try
                {
                    Console.Write("Enter bank difficulty: ");
                    diff = Int32.Parse(Console.ReadLine());
                    tryAgain = false;
                }
                catch
                {
                    Console.WriteLine("Something went wrong!");
                    Console.WriteLine("");
                }
            }
            Team myTeam = new Team();
            int skill1 = 0;
            double courage1 = 0;
            Console.Write("Enter a team member's name: ");
            string member1 = Console.ReadLine();
            while(member1 != "")
            {
                while(!tryAgain)
                {
                    try
                    {
                        Console.Write("Enter skill level: ");
                        skill1 = Int32.Parse(Console.ReadLine());
                        tryAgain = true;
                    }
                    catch
                    {
                        Console.WriteLine("Something went wrong!");
                        Console.WriteLine("");
                    }
                }
                try
                {
                    Console.Write("Enter courage level: ");
                    courage1 = Convert.ToDouble(Console.ReadLine());
                    while(tryAgain)
                    {
                        if(courage1 < 0 | courage1 > 2)
                        {
                            Console.Write("Enter courage level (between 0 and 2): ");
                            courage1 = Convert.ToDouble(Console.ReadLine());
                        }
                        else
                        {
                            tryAgain = false;
                            Member member = new Member(member1, skill1, courage1);
                            myTeam.Members.Add(member);
                        }
                    }
                    Console.Write("Enter a team member's name: ");
                    member1 = Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("Something went wrong!");
                    Console.WriteLine("");
                }
            }
            Console.WriteLine($"You have {myTeam.Members.Count} team members.");
            int trials = 0;
            int trialsRun = 0;
            while(!tryAgain)
            {
                try
                {
                    Console.Write("Enter trial runs: ");
                    trials = Int32.Parse(Console.ReadLine());
                    tryAgain = true;
                }
                catch
                {
                    Console.WriteLine("Something went wrong!");
                    Console.WriteLine("");
                }
            }

            int success = 0;
            int fail = 0;
            while(trials > trialsRun)
            {
                int luck = RNG();
                int bankDifficulty = diff + luck;
                int combinedSkill = myTeam.Members.Sum(member => member.Skill);

                Console.WriteLine($"Bank Difficulty: {bankDifficulty}, Team Skill: {combinedSkill}");
                
                if(combinedSkill >= bankDifficulty)
                {
                    Console.WriteLine("You did it!!");
                    success++;
                }
                else
                {
                    Console.WriteLine("You failed! :(");
                    fail++;
                }
                trialsRun++;
            }
            Console.WriteLine("");
            Console.WriteLine($"You succeeded {success} times and failed {fail} times.");
        }
        public static int RNG() {
            Random r = new Random();
            int genRand= r.Next(-10,11);
            return genRand;
        }
    }
}

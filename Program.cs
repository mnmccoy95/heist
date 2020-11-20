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
            Team myTeam = new Team();
            int skill1 = 0;
            double courage1 = 0;
            Console.Write("Enter a team member's name: ");
            string member1 = Console.ReadLine();
            while(member1 != "")
            {
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
                        Member member = new Member(member1, skill1, courage1);
                        myTeam.Members.Add(member);
                    }
                    Console.Write("Enter a team member's name: ");
                    member1 = Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("Something went wrong!");
                }
            }
            Console.WriteLine($"You have {myTeam.Members.Count} team members.");
            foreach(Member person in myTeam.Members)
            {
                Console.WriteLine($"{person.Name} has skill level {person.Skill} and courage factor {person.Courage}.");
            }
            int luck = RNG();
            int bankDifficulty = 100 + luck;
            int combinedSkill = myTeam.Members.Sum(member => member.Skill);

            Console.WriteLine($"Bank Difficulty: {bankDifficulty}, Team Skill: {combinedSkill}");
            
            if(combinedSkill >= bankDifficulty)
            {
                Console.WriteLine("You did it!!");
            }
            else
            {
                Console.WriteLine("You failed! :(");
            }
        }
        public static int RNG() {
            Random r = new Random();
            int genRand= r.Next(-10,11);
            return genRand;
        }
    }
}

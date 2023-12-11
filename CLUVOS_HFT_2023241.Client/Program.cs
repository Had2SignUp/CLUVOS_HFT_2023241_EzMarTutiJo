using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using CLUVOS_HFT_2023241.Models;

namespace CLUVOS_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;


        static void Create(string entity)
        {
            if (entity == "League")
            {
                Console.Write("League name: ");
                string name = Console.ReadLine();
                Console.Write("League country: ");
                string country = Console.ReadLine();
                Console.Write("League has VAR?(true/false): ");
                bool HasVar = bool.Parse(Console.ReadLine());
                rest.Post(new League() { Name = name, Country = country, HasVar = HasVar },"league");

            }
            else if (entity == "Player")
            {
                Console.Write("Player name: ");
                string name = Console.ReadLine();
                Console.Write("Player age: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Player position: ");
                string pos = Console.ReadLine();
                Console.Write("Is player right footed?(true/false): ");
                bool rf = bool.Parse(Console.ReadLine());
                Console.Write("Player salary: ");
                int sal = int.Parse(Console.ReadLine());
                Console.Write("Player team ID: ");
                int tid = int.Parse(Console.ReadLine());
                rest.Post(new Player() { Name = name, Age = age, Position= pos, RightFooted=rf, Salary=sal, TeamId = tid}, "player");
            }
            else if(entity == "Team")
            {
                Console.Write("Team name: ");
                string name = Console.ReadLine();
                Console.Write("Team league ID: ");
                int leagueId = int.Parse(Console.ReadLine());
                Console.Write("Team has youth squad?(true/false): ");
                bool hys = bool.Parse(Console.ReadLine());
                rest.Post(new Team() { Name = name, LeagueId = leagueId, HasYoungLeagueTeam = hys}, "team");
            }
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "League")
            {
                List<League> leagues = rest.Get<League>("league");
                foreach (var item in leagues)
                {
                    Console.WriteLine("(" +item.Id +")" + item.Name);
                }
            }
            else if(entity == "Player")
            {
                List<Player> leagues = rest.Get<Player>("player");
                foreach (var item in leagues)
                {
                    Console.WriteLine("(" + item.Id + ")"+item.Name);
                }
            }
            else if(entity == "Team")
            {
                List<Team> leagues = rest.Get<Team>("team");
                foreach (var item in leagues)
                {
                    Console.WriteLine("(" + item.Id + ")"+item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if(entity == "League")
            {
                Console.WriteLine("League ID to modify: ");
                int id = int.Parse(Console.ReadLine());
                League l = rest.Get<League>(id, "league");
                Console.WriteLine($"Old name:{l.Name} new name: ");
                string newName= Console.ReadLine();
                l.Name = newName;
                rest.Put(l, "league");

            }
            else if( entity == "Team")
            {
                Console.WriteLine("Team ID to modify: ");
                int id = int.Parse(Console.ReadLine());
                Team t = rest.Get<Team>(id, "team");
                Console.WriteLine($"Old name:{t.Name} new name: ");
                string newName = Console.ReadLine();
                t.Name = newName;
                rest.Put(t, "team");
            }
            else if (entity == "Player")
            {
                Console.WriteLine("Player ID to modify: ");
                int id = int.Parse(Console.ReadLine());
                Player p = rest.Get<Player>(id, "player");
                Console.WriteLine($"Old name:{p.Name} new name: ");
                string newName = Console.ReadLine();
                p.Name = newName;
                rest.Put(p, "player");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "League")
            {
                Console.WriteLine("League ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "league");
            }
            else if(entity == "Team")
            {
                Console.WriteLine("Team ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "team");
            }
            else if (entity == "Player")
            {
                Console.WriteLine("Player ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "player");
            }
        }
        static void YoungerThanX(string entity)
        {
            Console.WriteLine("Players under age: ");
            int age = int.Parse(Console.ReadLine());
            IEnumerable<Player> youngplayers = rest.Get<Player>("PlusInfo/GetPlayersYoungerThanX/" + age);
            foreach (var item in youngplayers)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void YoungSalary(string entity)
        {
            int x = rest.GetSingle<int>("PlusInfo/GetYoungsterSalaryInfo");
            Console.WriteLine("U20 Players salary sum: "+x);
            Console.ReadLine();
        }
        static void YoungestPlayerAge(string entity)
        {
            int x = rest.GetSingle<int>("PlusInfo/GetYoungestPlayerAge");
            Console.WriteLine("The youngest player age is: "+x);
            Console.ReadLine();
        }
        static void AverageSalary(string entity)
        {
            Console.WriteLine("Team ID: ");
            int id = int.Parse(Console.ReadLine());
            double x = rest.GetSingle<double>("PlusInfo/AverageSalary/"+ id);
            Console.WriteLine(x);
            Console.ReadKey();
        }
        static void YouthSquadInfo(string entity)
        {
            var ysi = rest.Get<YouthSquadInfo>("YouthSquadInfo/GetYSI");
            foreach (var item in ysi)
            {
                Console.WriteLine("League ID: "+item.LeagueId);
                Console.WriteLine("Youth Squad Counter: "+item.YouthSquadsInLeague);
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:43006/", "league");
            var leagueSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("League"))
                .Add("Create", () => Create("League"))
                .Add("Delete", () => Delete("League"))
                .Add("Update", () => Update("League"))
                .Add("Youth Squad Info", () => YouthSquadInfo("League"))
                .Add("Exit", ConsoleMenu.Close); 

            var teamSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Team"))
                .Add("Create", () => Create("Team"))
                .Add("Delete", () => Delete("Team"))
                .Add("Update", () => Update("Team"))
                .Add("Average salary", () => AverageSalary("Team"))
                .Add("Exit", ConsoleMenu.Close);

            var playerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Player"))
                .Add("Create", () => Create("Player"))
                .Add("Delete", () => Delete("Player"))
                .Add("Update", () => Update("Player"))
                .Add("Younger than X", () => YoungerThanX("Player"))
                .Add("Young players salary info", () => YoungSalary("Player"))
                .Add("Youngest player age", () => YoungestPlayerAge("Player"))
                .Add("Exit", ConsoleMenu.Close);
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Leagues", () => leagueSubMenu.Show())
                .Add("Teams", () => teamSubMenu.Show())
                .Add("Players", () => playerSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}

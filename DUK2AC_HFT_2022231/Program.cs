using System;
using System.Collections.Generic;
using ConsoleTools;
using DUK2AC_HFT_2022231.Models;

namespace DUK2AC_HFT_2022231.Client
{
    class Program
    {
        static RestService rest;

        private static void Update(string v)
        {
            if (v == "Game")
            {
                Console.Write("Enter Game's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Game one = rest.Get<Game>(id, "Game");
                Console.Write($"New price [old: {one.Price}]: ");
                int price = int.Parse(Console.ReadLine());
                one.Price = price;
                rest.Put(one, "Game");
            }
            else if (v == "Developer")
            {
                Console.Write("Enter Developer's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Developer one = rest.Get<Developer>(id, "Developer");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "Developer");
            }
            else if (v == "Achievement")
            {
                Console.Write("Enter Achievement's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Achievement one = rest.Get<Achievement>(id, "Achievement");
                Console.Write($"New bonuspoint [old: {one.Bonuspoints}]: ");
                int point = int.Parse(Console.ReadLine());
                one.Bonuspoints = point;
                rest.Put(one, "Achievement");
            }
        }

        private static void Delete(string v)
        {
            if (v == "Game")
            {
                Console.Write("Enter Game's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Game");
            }
            else if (v == "Developer")
            {
                Console.Write("Enter Developer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Developer");
            }
            else if (v == "Achievement")
            {
                Console.Write("Enter Achievement's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Achievement");
            }
            
        }

        private static void Create(string v)
        {
            if (v == "Game")
            {
                Console.Write("Enter Game Name: ");
                string name = Console.ReadLine();
                rest.Post(new Game() { Title = name }, "Game");
            }
            else if (v == "Developer")
            {
                Console.Write("Enter Developer Name: ");
                string name = Console.ReadLine();
                rest.Post(new Developer() { Name = name }, "Developer");
            }
            else if (v == "Achievement")
            {
                Console.Write("Enter Achievement Name: ");
                string name = Console.ReadLine();
                rest.Post(new Achievement() { Name = name }, "Achievement");
            }
        }

        private static void List(string v)
        {
            if (v == "Game")
            {
                List<Game> actors = rest.Get<Game>("Game");
                foreach (var item in actors)
                {
                    Console.WriteLine(item.Id + ": " + item.Title);
                }
            }
            else if (v == "Developer")
            {
                List<Developer> Director = rest.Get<Developer>("Developer");
                foreach (var item in Director)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            else if (v == "Achievement")
            {
                List<Achievement> Role = rest.Get<Achievement>("Achievement");
                foreach (var item in Role)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:42084/", "games");
            
            var GameSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Game"))
                .Add("Create", () => Create("Game"))
                .Add("Delete", () => Delete("Game"))
                .Add("Update", () => Update("Game"))
                .Add("Exit", ConsoleMenu.Close);

            var DevSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Developer"))
                .Add("Create", () => Create("Developer"))
                .Add("Delete", () => Delete("Developer"))
                .Add("Update", () => Update("Developer"))
                .Add("Exit", ConsoleMenu.Close);

            var AchiSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Achievement"))
                .Add("Create", () => Create("Achievement"))
                .Add("Delete", () => Delete("Achievement"))
                .Add("Update", () => Update("Achievement"))
                .Add("Exit", ConsoleMenu.Close);
            


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Games", () => GameSubMenu.Show())
                .Add("Developers", () => DevSubMenu.Show())
                .Add("Achievements", () => AchiSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
            
            
        }
    }
}

using System;
using System.Collections.Generic;
using ConsoleTools;
using DUK2AC_HFT_2022231.Models;

namespace DUK2AC_HFT_2022231.Client
{
    class Program
    {
        static RestService rest;
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:42084/", "GameShop");
            
            var GameSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Game"))
                .Add("Create", () => Create("Game"))
                .Add("Delete", () => Delete("Game"))
                .Add("Update", () => Update("Game"))
                .Add("Exit", ConsoleMenu.Close);

            var DevSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Dev"))
                .Add("Create", () => Create("Dev"))
                .Add("Delete", () => Delete("Dev"))
                .Add("Update", () => Update("Dev"))
                .Add("Exit", ConsoleMenu.Close);

            var AchiSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Achi"))
                .Add("Create", () => Create("Achi"))
                .Add("Delete", () => Delete("Achi"))
                .Add("Update", () => Update("Achi"))
                .Add("Exit", ConsoleMenu.Close);

            


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Games", () => GameSubMenu.Show())
                .Add("Developers", () => DevSubMenu.Show())
                .Add("Achievements", () => AchiSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
            
            
        }

        private static void Update(string v)
        {
            if (v == "Game")
            {
                Console.Write("Enter Game's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Game one = rest.Get<Game>(id, "game");
                Console.Write($"New price [old: {one.Price}]: ");
                int price = int.Parse(Console.ReadLine());
                one.Price = price;
                rest.Put(one, "game");
            }
            else if (v == "Dev")
            {
                Console.Write("Enter Dev's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Developer one = rest.Get<Developer>(id, "dev");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "dev");
            }
            else if (v == "Achi")
            {
                Console.Write("Enter Achi's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Achievement one = rest.Get<Achievement>(id, "achi");
                Console.Write($"New bonuspoint [old: {one.Bonuspoints}]: ");
                int point = int.Parse(Console.ReadLine());
                one.Bonuspoints = point;
                rest.Put(one, "achi");
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
            else if (v == "Dev")
            {
                Console.Write("Enter Dev's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Dev");
            }
            else if (v == "Achi")
            {
                Console.Write("Enter Achi's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "achi");
            }
            
        }

        private static void Create(string v)
        {
            if (v == "Game")
            {
                Console.Write("Enter Actor Name: ");
                string name = Console.ReadLine();
                rest.Post(new Game() { Title = name }, "Game");
            }
            else if (v == "Dev")
            {
                Console.Write("Enter Director Name: ");
                string name = Console.ReadLine();
                rest.Post(new Developer() { Name = name }, "Dev");
            }
            else if (v == "Achi")
            {
                Console.Write("Enter Role Name: ");
                string name = Console.ReadLine();
                rest.Post(new Achievement() { Name = name }, "Achi");
            }
        }

        private static void List(string v)
        {
            if (v == "Game")
            {
                List<Game> actors = rest.Get<Game>("actor");
                foreach (var item in actors)
                {
                    Console.WriteLine(item.Id + ": " + item.Title);
                }
            }
            else if (v == "Dev")
            {
                List<Developer> Director = rest.Get<Developer>("director");
                foreach (var item in Director)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            else if (v == "Achi")
            {
                List<Achievement> Role = rest.Get<Achievement>("role");
                foreach (var item in Role)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            Console.ReadKey();
        }
    }
}

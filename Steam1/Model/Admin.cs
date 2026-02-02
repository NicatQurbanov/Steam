using System;
using System.Collections.Generic;
using System.Text;

namespace Steam
{
    public class Admin(string nickname, PlayerStatus status, Game? game = null) : Profile(nickname, status, game)
    {
        public Menu? Menu { get; set; } = null;
        public void AdminMenu()
        {
            Console.Clear();
            
            Console.WriteLine("1. Ban Player\n2. Delete Game\n3. Add Game\nEnter any key to return to the main menu...");

            ConsoleKeyInfo menuSelection = Console.ReadKey();

            switch (menuSelection.KeyChar)
            {
                case '1':
                    Ban();
                    break;
                case '2':
                    Delete();
                    break;
                case '3':
                    Add();
                    break;
                default:
                    Menu?.Start();
                    break;
            }
        }

        public void Ban()
        {
            Console.Clear();
            Menu.PlayerCtrl.ShowUsers(Menu.PlayerCtrl.players, true, false);
            Console.WriteLine("Enter player's nickname you want to ban: ");
            string? nickname = Console.ReadLine();
            if (nickname != null)
            {
                Player player = Menu.PlayerCtrl.players.Find(p => p.Nickname == nickname);
                Menu.PlayerCtrl.players.Remove(player);
                Console.WriteLine("You've successfully banned player");
            }
                Console.WriteLine("Incorrect name");
                Console.ReadLine();
                Ban();
     
            AdminMenu();
        }

        public void Delete()
        {
            Menu.GameCtrl.ShowGames();
            Console.WriteLine("Enter a game's name you want to delete from: ");
            string? name = Console.ReadLine();
            Game? game = Menu.GameCtrl.Games.Find(g => g.Name.Equals(name));
            if (game != null) Menu.GameCtrl.Games.Remove(game);
            Console.WriteLine("This game is no longer on the list");
            Console.ReadLine();
            AdminMenu();
        }

        public void Add()
        {
            Console.WriteLine("\nEnter a name of a new fame you want to add on: ");
            string? game = Console.ReadLine();
            Menu.GameCtrl.Games.Add(new Game(game));
            Console.WriteLine($"The {game} now is in the Steam list of games.");
            Console.ReadLine();
            AdminMenu();
        }
    }
}

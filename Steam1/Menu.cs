using System;
using System.Collections.Generic;
using System.Text;

namespace Steam
{
    public class Menu(PlayerController playerController, GameController gameController, Player currPlayer, Admin admin)
    {
        public PlayerController PlayerCtrl { get; } = playerController;
        public GameController GameCtrl { get; } = gameController;
        public Player CurrPlayer { get; } = currPlayer;
        public Admin Admin { get; } = admin;

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Steam Menu!\n1. Show users.\n2. Show all games\n3. Check friendlist. \n4. Enter as admin\nOr press any key to leave...");
            ConsoleKeyInfo menuSelection = Console.ReadKey(); Console.WriteLine();

                switch (menuSelection.KeyChar)
                {
                    case '1':
                        User();
                        break;
                    case '2':
                        GameCtrl.ShowGames();
                        Start();
                        break;
                    case '3':
                        Friends();
                        break;
                    case '4':
                        Admin.AdminMenu();
                        break;
                }
        }

        public void User()
        {
            Console.WriteLine("List users who is:\n1. Online\n2. Offline\n3. InGame\n4. Blocked");
            ConsoleKeyInfo menuSelection = Console.ReadKey(); Console.WriteLine();

                switch (menuSelection.KeyChar)
                {
                    case '1':
                        PlayerCtrl.ShowUsers(PlayerCtrl.ShowOnlineUsers());
                        Start();
                        break;
                    case '2':
                        PlayerCtrl.ShowUsers(PlayerCtrl.ShowOfflineUsers());
                        Start();
                        break;
                    case '3':
                        PlayerCtrl.ShowUsers(PlayerCtrl.ShowInGameUsers());
                        Start();
                        break;
                    case '4':
                        PlayerCtrl.ShowUsers(PlayerCtrl.ShowBlockedUsers());
                        Start();
                        break;
                    default:
                        User();
                        break;
                }
        }

        public void Friends()
        {
            Console.Clear();
            Console.WriteLine("~~Frienlist~~\n\n1. Show friends\n2. Send request to\n3. Delete friend\n4. Return");
            ConsoleKeyInfo menuSelection = Console.ReadKey(); Console.WriteLine();

            
                switch (menuSelection.KeyChar)
                {
                    case '1':
                        CurrPlayer.ShowFriends();
                        Friends(); 
                        break;
                    case '2':
                        PlayerCtrl.ShowUsers(PlayerCtrl.players, true, false);
                        SendRequestTo();
                        break;
                    case '3':
                        CurrPlayer.ShowFriends(true);
                        CurrPlayer.DeleteFriend();
                        Friends();
                        break;
                    case '4':
                        Start();
                        break;
                    default:
                        Friends();
                        break;
                }
        }
        public void SendRequestTo()
        {
            bool found = false;
            while (!found)
            {
                Console.WriteLine("\nEnter player's nickname you want to send request to:");
                string nickname = Console.ReadLine()?.ToLower() ?? "";
                foreach (Player p in PlayerCtrl.players)
                    if (p.Nickname == nickname)
                    {
                        if (p.Status == PlayerStatus.Blocked)
                        {
                            Console.WriteLine("This user has been blocked!");
                            Console.ReadLine();
                            found = true;
                            Friends();
                        }
                        else if (CurrPlayer.Friends.Contains(p))
                        {
                            Console.WriteLine("This user is already your friend!");
                            Console.ReadLine();
                            found = true;
                            Friends();
                        }
                        else
                        {
                            CurrPlayer.Friends.Add(p);
                            found = true;
                            Console.WriteLine($"\nFriend request sent!\n{p.Nickname} accepted your request!\n" +
                                              $"Press Enter to return to the Friendlist menu:");
                            Console.ReadLine();
                            Friends();
                        }
                       }
                    }
                if (!found) Console.WriteLine("Player not found, try again.");
            } 
        }
    }

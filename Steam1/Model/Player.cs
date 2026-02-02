namespace Steam
{
    public class Player(string nickname, PlayerStatus status, Game? game = null, List<Player>? friends = null) : Profile(nickname, status, game)
    {
        public List<Player> Friends { get; set; } = friends;

        public void ShowFriends(bool isRemoving = false)
        {
            Console.WriteLine("List of friends: ");
            foreach (Player p in Friends) 
            {
                Console.Write($"\n--{p.Nickname}: ");
                switch (p.Status)
                {
                    case PlayerStatus.InGame:
                        Console.Write($"Your friend is currently playing {p.CurrentGame?.Name}. Join with him!");  
                        break;
                    case PlayerStatus.Online:
                        Console.Write("He is waiting for you to say hi!");
                        break;
                    case PlayerStatus.Offline:
                        Console.Write("Z-z-z-z....");
                        break;
                }
            }
            if (!isRemoving)
            {
                Console.WriteLine("\nPress Enter to go back to Friendlist menu...");
                Console.ReadLine();
            }
            else
                Console.WriteLine("\nChoose a friend you want to delete:");
        }

        public void DeleteFriend()
        {
            bool isRemoved = false;
            while (!isRemoved)
            {
                if (Friends.Count ==  0 )
                {
                    Console.WriteLine("You have no friends!");
                    Console.ReadLine();
                    isRemoved = true;
                    break;
                }
                else
                {
                    string? nickname = Console.ReadLine()?.ToLower();
                    foreach (Player p in Friends)
                    {
                        if (p.Nickname == nickname)
                        {
                            Friends.Remove(p);
                            isRemoved = true;
                            Console.WriteLine($"{p.Nickname} is no longer your friend, ciao!");
                            Console.ReadLine();
                            break;
                        }
                    }
                }
                if (!isRemoved) Console.WriteLine("Not found. Try again.");
            }
        }
    }
}
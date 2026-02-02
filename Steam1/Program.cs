using System.Numerics;

namespace Steam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CREATING SAMPLE GAMES

            Game csgo = new("CS:GO");
            Game dota2 = new("Dota 2");
            Game pubg = new("PUBG");
            Game valorant = new("Valorant");
            Game fortnite = new("Fortnite");
            Game apexLegends = new("Apex Legends");
            Game codWarzone = new("Call of Duty: Warzone");
            Game rainbowSixSiege = new("Rainbow Six Siege");
            Game rust = new("Rust");
            Game amongUs = new("Among Us");

            

           

            // CREATING SAMPLE PLAYERS
            PlayerController players = new();

            Player vusal = new("vusal", PlayerStatus.Offline);
            Player seyyad = new("seyyad", PlayerStatus.Offline);
            Player elvin = new("elvin", PlayerStatus.Online);
            Player kamran = new("kamran", PlayerStatus.Online);
            Player nijat = new("nijat", PlayerStatus.InGame, csgo, [vusal, seyyad]);
            Player rashad = new("rashad", PlayerStatus.Blocked);
            Player orxan = new("orxan", PlayerStatus.InGame, csgo);
            Player emil = new("emil", PlayerStatus.InGame, fortnite);
            Player samir = new("samir", PlayerStatus.InGame, dota2);
            Player murad = new("murad", PlayerStatus.InGame, csgo);
            Player ali = new("ali", PlayerStatus.InGame, dota2);
            Player farid = new("farid", PlayerStatus.InGame, amongUs);
            Player javid = new("javid", PlayerStatus.InGame, amongUs);
            Player anar = new("anar", PlayerStatus.InGame, fortnite);
            Player rauf = new("rauf", PlayerStatus.InGame, csgo);
            Player emin = new("emin", PlayerStatus.InGame, pubg);
            Player sabir = new("sabir", PlayerStatus.Offline);
            Player tofig = new("tofig", PlayerStatus.InGame, csgo);
            Player fuad = new("fuad", PlayerStatus.Offline, friends: [rauf]);
            Player taleh = new("taleh", PlayerStatus.Blocked, friends: [farid, anar, rauf, rashad, kamran]);
            Player ayaz = new("ayaz", PlayerStatus.InGame, apexLegends, [anar]);
            Player ruslan = new("ruslan", PlayerStatus.InGame, amongUs, [sabir, seyyad, emin, kamran]);
            Player ilham = new("ilham", PlayerStatus.Offline, friends: [tofig, fuad]);
            Player namig = new("namig", PlayerStatus.InGame, valorant, [emin, sabir, taleh]);
            Player elshan = new("elshan", PlayerStatus.InGame, rust, [emil, ali]);



            Admin admin = new("admin", PlayerStatus.Online);
            players.players.AddRange(nijat, vusal, seyyad, elvin, kamran, rashad, orxan, emil, samir, murad, ali, farid,
                javid, anar, rauf, emin, sabir, tofig, fuad, taleh, ayaz, ruslan, ilham, namig, elshan);

            GameController games = new(players);
            games.Games.AddRange(csgo, dota2, pubg, valorant, fortnite, apexLegends, codWarzone, rainbowSixSiege, rust, amongUs);
            Menu menu = new(players, games, nijat, admin);
            admin.Menu = menu;
            menu.Start();
        }
    }
}
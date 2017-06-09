using System;
using System.Collections.Generic;
using System.Linq;

namespace NBA2020
{
    public class Team
    {
        public int NUM = 0;
        public string NAME = "";
        public int HOME_GAME = 0;
    }

    public class Schedule
    {
        private static void Main(string[] args)
        {
            NBA.Start_Season();
            Console.Read();
        }
    }

    public class NBA
    {
        public static void Start_Season()
        {
            List<Team> Teams = new List<Team>();
            List<Team> List_1 = new List<Team>();
            List<Team> List_2 = new List<Team>();
            List<Team> Round_2 = new List<Team>();
            int round_count = 1;

            for (int i = 1; i < 31; i++)
            {
                Team Team = new Team();
                Team.NUM = i;
                Team.NAME = Shuffle_Teams.Get_Teams(i);
                Teams.Add(Team);
            }

            Console.WriteLine("------------------------------------");

            //This will just display in Alphabetical Order at first (Challenge Input)
            Console.WriteLine("Total Team in NBA 2020");
            foreach (var team in Teams)
            {
                Console.WriteLine(team.NUM + " - " + team.NAME);
            }
            Console.WriteLine("------------------------------------");

            Console.WriteLine("Random Teams in NBA 2020");
            Console.WriteLine("------------------------------------");
            //This will assign random teams each time program runs
            Teams.Get_Random_Teams();
            foreach (var team in Teams)
            {
                Console.WriteLine(team.NUM + " - " + team.NAME);
            }

            Console.WriteLine("------------------------------------");

            Console.WriteLine();

            //I am lazy so repeating loop over - spent way too much time on this!
            for (int n = 1; n < 3; n++)
            {

                if (n == 1)
                {
                    for (int i = 0; i < 30; i++)
                    {
                        Team Team = Teams[i];
                        List_1.Add(Team);
                    }

                    for (int i = 29; i >= 0; i--)
                    {
                        Team Team = Teams[i];
                        List_2.Add(Team);
                    }
                }
                else
                {
                    for (int i = 0; i < 30; i++)
                    {
                        Team Team = Teams[i];
                        List_2.Add(Team);
                    }

                    for (int i = 29; i >= 0; i--)
                    {
                        Team Team = Teams[i];
                        List_1.Add(Team);
                    }
                }

                Team HomeTeam;
                Team AwayTeam;

                List<Team> HomeList = List_1;
                List<Team> AwayList = List_2;

                for (int i = 1; i < 30; i++)
                {
                    Console.WriteLine("------------------- ROUND - " + round_count + " -----------------");

                    for (int j = 0; j < 15; j++)
                    {
                        HomeTeam = HomeList[j];
                        AwayTeam = AwayList[j];
                        HomeTeam.HOME_GAME++;

                        Console.WriteLine(HomeTeam.NAME + " ( " + HomeTeam.NUM + " )   - VS -  " + AwayTeam.NAME + " ( " + AwayTeam.NUM + " )");
                        //Console.WriteLine(HomeTeam.NUM + "  VS  " + AwayTeam.NUM);
                        Team Team = HomeTeam;
                        Round_2.Add(HomeTeam);
                        Team = AwayTeam;
                        Round_2.Add(HomeTeam);
                    }

                    //This could have been batter way
                    if (i == 15)
                    {
                        List_1.Clear();
                        List_2.Clear();


                        Team Team = Teams[0];

                        if (n == 1) { List_1.Add(Team); } else { List_2.Add(Team); }

                        for (int j = 16; j <= 29; j++)
                        {
                            Team = Teams[j];
                            if (n == 1) { List_1.Add(Team); } else { List_2.Add(Team); }
                        }

                        for (int j = 1; j < 16; j++)
                        {
                            Team = Teams[j];
                            if (n == 1) { List_1.Add(Team); } else { List_2.Add(Team); }
                        }

                        Team = Teams[15];
                        if (n == 1) { List_2.Add(Team); } else { List_1.Add(Team); }

                        for (int j = 14; j > 0; j--)
                        {
                            Team = Teams[j];
                            if (n == 1) { List_2.Add(Team); } else { List_1.Add(Team); }
                        }

                        for (int j = 29; j > 14; j--)
                        {
                            Team = Teams[j];
                            if (n == 1) { List_2.Add(Team); } else { List_1.Add(Team); }
                        }
                        Team = Teams[0];
                        if (n == 1) { List_2.Add(Team); } else { List_1.Add(Team); }
                    }

                    Shuffle_Teams.Arrange_Lists(ref List_1, ref List_2);

                    //Another bad way to do this!
                    if (i == 29 && n == 1)
                    {

                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            HomeList = List_1;
                            AwayList = List_2;
                        }
                        else
                        {
                            HomeList = List_2;
                            AwayList = List_1;
                        }
                    }

                    Console.WriteLine();

                    round_count++;

                    if (i == 29)
                    {
                        List_1.Clear();
                        List_2.Clear();
                    }
                }

                Console.WriteLine();
            }
        }
    }

    public static class Shuffle_Teams
    {
        public static string Get_Teams(int team_number)
        {
            switch (team_number)
            {
                case 1: return "Atlanta Hawks         ";
                case 2: return "Boston Celtics        ";
                case 3: return "Brooklyn Nets         ";
                case 4: return "Charlotte Hornets     ";
                case 5: return "Chicago Bulls         ";
                case 6: return "Cleveland Cavaliers   ";
                case 7: return "Dallas Mavericks      ";
                case 8: return "Denver Nuggets        ";
                case 9: return "Detroit Pistons       ";
                case 10: return "Golden State Warriors ";
                case 11: return "Houston Rockets       ";
                case 12: return "Indiana Pacers        ";
                case 13: return "Los Angeles Clippers  ";
                case 14: return "Los Angeles Lakers    ";
                case 15: return "Memphis Grizzlies     ";
                case 16: return "Miami Heat            ";
                case 17: return "Milwaukee Bucks       ";
                case 18: return "Minnesota Timberwolves";
                case 19: return "New Orleans Pelicans  ";
                case 20: return "New York Knicks       ";
                case 21: return "Oklahoma City Thunder ";
                case 22: return "Orlando Magic         ";
                case 23: return "Philadelphia 76ers    ";
                case 24: return "Phoenix Suns          ";
                case 25: return "Portland Trail Blazers";
                case 26: return "Sacramento Kings      ";
                case 27: return "San Antonio Spurs     ";
                case 28: return "Toronto Raptors       ";
                case 29: return "Utah Jazz             ";
                case 30: return "Washington Wizards    ";
                default: return "";
            }
        }

        public static void Get_Random_Teams<T>(this List<T> list)
        {
            int n = list.Count;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void Arrange_Lists<Team>(ref List<Team> list_1, ref List<Team> list_2)
        {
            List<Team> tmp_list_1 = list_1.Skip(1).ToList();
            List<Team> tmp_list_2 = list_2.ToList();

            var last_team_list_1 = list_1.LastOrDefault();
            var First_team_list_2 = list_2.FirstOrDefault();

            list_2.Remove(First_team_list_2);
            list_2.Add(last_team_list_1);

            foreach (var item in tmp_list_1)
            {
                list_1.Remove(item);
            }

            list_1.Add(First_team_list_2);

            tmp_list_1.Remove(First_team_list_2);

            foreach (var item in tmp_list_1)
            {
                list_1.Add(item);
            }
        }
    }
}

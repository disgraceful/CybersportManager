using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace CybersportManager.Client
{
    public static class Database
    {
        public static List<Player> allPlayers;
        public static List<Team> allTeams;
        public static List<Country> allCountries = new List<Country>();
        public static List<Hero> allHeroes = new List<Hero>();
        public static List<Tournament> allTournaments = new List<Tournament>();

        private static string rootPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

        static Database()
        {
            fillCountries();
        }
        public static void readPlayers()
        {
            Debug.Write(rootPath);
            allPlayers = new List<Player>();
            CsvReader reader = new CsvReader(rootPath + "/db/players.csv");
            CSVRow row = new CSVRow();
            try
            {
                while (reader.ReadRow(row))
                {
                    for (int i = 0; i < row.Count; i++)
                    {
                        Player newplayer123 = new Player(row[i], row[i + 1], row[i + 2], Convert.ToInt32(row[i + 3]), (RoleType)Enum.Parse(typeof(RoleType), row[i + 4]));
                        if (row[i + 5] == "None")
                        {
                            newplayer123.Teamless = true;
                        }
                        else {
                            newplayer123.Team = searchTeam(row[i + 5]);
                        }
                        newplayer123.Homeland = searchCountry(row[i + 6]);
                        newplayer123.Img = new BitmapImage(new Uri(row[i + 7]));
                        allPlayers.Add(newplayer123);
                        break;
                    }
                }
            }
            catch (Exception e) { }
            reader.Close();
        }
        public static void addPlayer(Player newplayer)
        {
            allPlayers.Add(newplayer);
            savePlayers();
        }
        public static void savePlayers()
        {
            if (allPlayers != null && allPlayers.Count > 0)
            {
                CsvWriter playerwriter = new CsvWriter(rootPath + "/db/players.csv");
                foreach (Player player in allPlayers)
                {
                    CSVRow row = new CSVRow();
                    foreach (string s in player.fieldsToList())
                    {
                        row.Add(s);
                    }
                    playerwriter.WriteRow(row);
                }
                playerwriter.Close();
            }


        }

        public static void readTeams()
        {
            allTeams = new List<Team>();
            CsvReader reader = new CsvReader(rootPath + "/db/teams.csv");
            CSVRow row = new CSVRow();
            try
            {
                while (reader.ReadRow(row))
                {
                    for (int i = 0; i < row.Count; i++)
                    {
                        Team newteam = new Team(row[i], row[i + 1], (Region)Enum.Parse(typeof(Region), row[i + 2]));
                        allTeams.Add(newteam);
                        break;
                    }
                }
            }
            catch { }
            reader.Close();
        }

        public static void addTeam(Team newteam)
        {
            allTeams.Add(newteam);
            saveTeams();
        }

        public static void saveTeams()
        {
            try
            {
                if (allTeams != null && allTeams.Count > 0)
                {
                    CsvWriter teamwriter = new CsvWriter(rootPath + "/db/teams.csv");
                    foreach (Team team in allTeams)
                    {
                        CSVRow row = new CSVRow();
                        foreach (string s in team.fieldsToList())
                        {
                            row.Add(s);
                        }
                        teamwriter.WriteRow(row);
                    }
                    teamwriter.Close();
                }
            }
            catch { }
        }

        private static void fillCountries()
        {
            allCountries.Add(new Country(rootPath + "/images/countryimages/southkorea.jpg", "South Korea"));
            allCountries.Add(new Country(rootPath + "/images/countryimages/denmark.jpg", "Denmark"));
            allCountries.Add(new Country(rootPath + "/images/countryimages/na.jpg", "USA"));
        }

        public static Country searchCountry(string name)
        {
            foreach (Country country in allCountries)
            {
                if (country.Name == name)
                {
                    return country;
                }
            }
            return null;
        }

        public static Team searchTeam(string teamname)
        {
            foreach (Team team in allTeams)
            {
                if (team.Name == teamname)
                {
                    return team;
                }
            }
            return null;
        }
      }

    public class CSVRow : List<string>
    {
        public string LineText { get; set; }

    }

    public class CsvWriter : StreamWriter
    {
        public CsvWriter(Stream stream) : base(stream) { }
        public CsvWriter(string filename) : base(filename) { }

        public void WriteRow(CSVRow row)
        {
            StringBuilder builder = new StringBuilder();
            bool firstColumn = true;
            foreach (string value in row)
            {
                if (!firstColumn)
                {
                    builder.Append(',');
                }
                if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                { builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\"")); }
                else
                { builder.Append(value); }
                firstColumn = false;
            }
            row.LineText = builder.ToString();
            WriteLine(row.LineText);
        }
    }


    public class CsvReader : StreamReader
    {
        public CsvReader(Stream stream) : base(stream) { }

        public CsvReader(string filename) : base(filename) { }

        public bool ReadRow(CSVRow row)
        {
            row.LineText = ReadLine();
            if (String.IsNullOrEmpty(row.LineText))
                return false;
            int pos = 0;
            int rows = 0;
            while (pos < row.LineText.Length)
            {
                string value;
                if (row.LineText[pos] == '"')
                {
                    pos++;
                    int start = pos;
                    while (pos < row.LineText.Length)
                    {
                        if (row.LineText[pos] == '"')
                        {
                            pos++;
                            if (pos >= row.LineText.Length || row.LineText[pos] != '"')
                            {
                                pos--;
                                break;
                            }
                        }
                        pos++;

                    }
                    value = row.LineText.Substring(start, pos - start);
                    value = value.Replace("\"\"", "\"");
                }
                else
                {
                    int start = pos;
                    while (pos < row.LineText.Length && row.LineText[pos] != ',')
                        pos++;
                    value = row.LineText.Substring(start, pos - start);
                }

                if (rows < row.Count)
                {
                    row[rows] = value;
                }
                else
                    row.Add(value);
                rows++;

                while (pos < row.LineText.Length && row.LineText[pos] != ',')
                    pos++;
                if (pos < row.LineText.Length)
                    pos++;
            }
            while (row.Count > rows)
                row.RemoveAt(rows);


            return (row.Count > 0);
        }

    }
}



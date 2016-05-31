using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Model;

namespace CybersportManager.Client
{
    public class Database
    {
        public static Database DB = new Database();
        CsvReader teamreader;
        CsvReader playerreader;
        CsvWriter teamwriter;
        CsvWriter playerwriter;
        List<Player> playerlist = new List<Player>();
        public List<Player> Playerlist
        {
            get { return playerlist; } 
        }

        List<Team> teamlist = new List<Team>();
        public List<Team> Teamlist { get { return teamlist; } }
        public List<Country> countries = new List<Country>();
        public List<Country> Countries { get { return countries; } }

        public Database()
        {
            
        }
        public void ReadTeams()
        {
            teamreader = new CsvReader("teams.csv");
            CSVRow row = new CSVRow();
            while (teamreader.ReadRow(row))
            {
                for (int i = 0; i < row.Count; i++)
                {
                    Team newteam123 = new Team(row[i], row[i + 1], (Region)Enum.Parse(typeof(Region), row[i + 2]));
                    Teamlist.Add(newteam123);
                    break;
                }
            }
            teamreader.Close();
        }

        public void ReadPlayers()
        {
            playerreader = new CsvReader("players.csv");
            CSVRow row = new CSVRow();
            while (playerreader.ReadRow(row))
            {
                for (int i = 0; i < row.Count; i++)
                {
                    Player newplayer123 = new Player(row[i],row[i+1],row[i+2],Convert.ToInt32(row[i+3]), (RoleType)Enum.Parse(typeof(RoleType), row[i + 4]));
                    if (row[i + 5] == "None")
                    {
                        newplayer123.Teamless = true;
                    }
                    else {
                        newplayer123.Team = SearchTeams(row[i + 5]);
                    }
                    newplayer123.Homeland = GetCountry(row[i + 6]);
                    Playerlist.Add(newplayer123);
                    break;
                }
            }
            playerreader.Close();
        }
        public void FillCountries()
        {
            Countries.Add(new Country("CybersportManager.Client/images/countryimages/southkorea.jpg", "South Korea"));
            Countries.Add(new Country("CybersportManager.Client/images/countryimages/denmark.jpg", "Denmark"));
            Countries.Add(new Country("CybersportManager.Client/images/countryimages/na.jpg", "USA"));
        }

        public Country GetCountry(string name)
        {
            foreach (Country country in countries)
            {
                if (country.Name == name)
                { return country; }

            }
            return null;
        }
        public Team SearchTeams(string teamname)
        {
            foreach (Team team in Teamlist)
            {
                if (team.Name == teamname)
                { return team; }
            }
            return null;
        }

        public void AddPlayer(List<string> datalist)
        {
            playerwriter = new CsvWriter("players.csv", true, Encoding.UTF8);

            CSVRow row = new CSVRow();
            foreach (string s in datalist)
            {
                row.Add(s);
            }
            playerwriter.WriteRow(row);
            playerwriter.Close();
        }
    }
    public class CSVRow : List<string>
    {
        public string LineText { get; set; }
    }

    public class CsvWriter : StreamWriter
    {
        public CsvWriter(Stream stream) : base(stream) { }
        public CsvWriter(string filename, bool append, Encoding encoder) : base(filename) { }

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
   

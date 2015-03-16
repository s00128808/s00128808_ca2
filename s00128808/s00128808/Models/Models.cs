using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace s00128808.Models
{
    public class DBInitialiser : DropCreateDatabaseAlways<PremierLeagueDB>
    {
        protected override void Seed(PremierLeagueDB context)
        {

           context.Clubs.Add(new Club()
           {
               ClubName ="Arsenal",
               Position = "3",
               Manager = "Arsène  Wenger",
               Players = new List<Player>
               {
                   new Player() {PlayerName = "Santiago Cazorla", Position ="Midfielder", Nationality = "Spanish", Age = "30"},
                   new Player() {PlayerName = "Alex Oxlade-Chamberlain", Position="Midfielder", Nationality =  "English", Age = "21"},
                   new Player() {PlayerName = "Theo Walcott", Position="Forward", Nationality ="English", Age = "25"}
               },

           });
           context.Clubs.Add(new Club()
           {
               ClubName = "Liverpool",
               Position = "5",
               Manager = "Brendan Rodgers",
               Players = new List<Player>
               {
                   new Player() {PlayerName = "Philippe Coutinho", Position ="Midfielder", Nationality = "Brazilian", Age = "22"},
                   new Player() {PlayerName = "Steven  Gerrard", Position="Midfielder", Nationality = "English", Age = "34"},
                   new Player() {PlayerName = "Raheem Sterling", Position="Forward", Nationality ="English", Age = "20"}
               },

           });
           context.Clubs.Add(new Club()
           {
               ClubName = "Chelsea",
               Position = "1",
               Manager = "José Mourinho",
               Players = new List<Player>
               {
                   new Player() {PlayerName = "Eden Hazard", Position ="Midfielder", Nationality = "Belgium", Age = "24"},
                   new Player() {PlayerName = "Diego Costa", Position="Forward", Nationality =  "Spanish", Age = "26"},
                   new Player() {PlayerName = "Cesc Fábregas", Position="Midfielder", Nationality ="Spanish", Age = "27"}
               },

           });
           context.Clubs.Add(new Club()
           {
               ClubName = "West Ham",
               Position = "4",
               Manager = "Sam Allardyce",
               Players = new List<Player>
               {
                   new Player() {PlayerName = "Enner Valencia", Position ="Forward", Nationality = "Ecuador", Age = "25"},
                   new Player() {PlayerName = "Alexandre Song", Position="Midfielder", Nationality =  "Cameroon", Age = "27"},
                   new Player() {PlayerName = "Diafra Sakho", Position="Forward", Nationality ="Senegal", Age = "26"}
               },

           });


           context.SaveChanges();
           base.Seed(context);
        }
    }

    public class PremierLeagueDB:DbContext 
    {
        public int Id { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Player> Players { get; set; }
        public PremierLeagueDB():base("PLdb")
        {

        }
    }

    public class Club
    {
        public int ClubID { get; set; }
        public string ClubName { get; set; }
        public string Position { get; set; }
        public string Manager { get; set; }
        public virtual List<Player> Players { get; set; }
    }

    public class Player
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string Age { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
        public Club Club { get; set; }             //Relationship
        

    }
}

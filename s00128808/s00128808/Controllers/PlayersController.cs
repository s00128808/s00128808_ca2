using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using s00128808.Models;

namespace s00128808.Controllers
{
    public class PlayersController : ApiController
    {
        private PremierLeagueDB db = new PremierLeagueDB();

        // GET: api/Players
        public IQueryable<Player> GetPlayers()
        {
            return db.Players;
        }

        // GET: api/Players/5
       
        public IEnumerable<Player> GetPlayer(int id)
        {
            return db.Players.Where(p => p.ClubID == id);
        }

        [Route("getplayers/{id:int}")]
        public Player GetPlayerList(int id)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
               
            }

            return player;
                

        }

        // PUT: api/Players/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public Player GetPlayerDetails(int id)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {

            }

            return player;
                
        }

        // POST: api/Players
        [ResponseType(typeof(Player))]
        public IHttpActionResult PostPlayer(Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Players.Add(player);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = player.PlayerID }, player);
        }

        // DELETE: api/Players/5
        [ResponseType(typeof(Player))]
        public IHttpActionResult DeletePlayer(int id)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            db.SaveChanges();

            return Ok(player);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerExists(int id)
        {
            return db.Players.Count(e => e.PlayerID == id) > 0;
        }
    }
}
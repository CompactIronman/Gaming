using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeeklyGamingBASIC.Models;

namespace WeeklyGamingBASIC.Controllers
{
    public class Game_MembersController : Controller
    {
        private WeeklyGamingTGEntities db = new WeeklyGamingTGEntities();

        // GET: Game_Members
        public ActionResult Index(string PlayersName, string searchMemberString, string GameName, string searchGameString)
        { 
            //Making members List

            var memberslst = new List<string>();

            var membersQry = from q in db.Game_Members
                             orderby q.Members.strFirstName
                             select q.Members.strFirstName;
            memberslst.AddRange(membersQry.Distinct());
            ViewBag.PlayersName = new SelectList(memberslst);

            //making game list
            var gamelst = new List<string>();

            var gameQry = from g in db.Game_Members
                        orderby g.Game.strGameName
                        select g.Game.strGameName;
            gamelst.AddRange(gameQry.Distinct());
            ViewBag.GameName = new SelectList(gamelst);

            var games = from m in db.Game_Members
                        select m;
            //To find Members
            if (!String.IsNullOrEmpty(searchMemberString))
            {
                games = games.Where(s => s.Members.strFirstName.Contains(searchMemberString));
            }
            //Select By Member
            if (!string.IsNullOrEmpty(PlayersName))
            {
                games = games.Where(p => p.Members.strFirstName == PlayersName);
            }

            //To find Games
            if (!String.IsNullOrEmpty(searchGameString))
            {
                games = games.Where(g => g.Game.strGameName.Contains(searchGameString));
            }
            //Select By Game
            if(!string.IsNullOrEmpty(GameName))
            {
                games = games.Where(x => x.Game.strGameName == GameName);
            }

            return View(games);
            //default for index view
            //var game_Members = db.Game_Members.Include(g => g.Game).Include(g => g.Members);
            //return View(game_Members.ToList());
         
        }

        // GET: Game_Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game_Members game_Members = db.Game_Members.Find(id);
            if (game_Members == null)
            {
                return HttpNotFound();
            }
            return View(game_Members);
        }

        // GET: Game_Members/Create
        public ActionResult Create()
        {
            ViewBag.intGameID = new SelectList(db.Games, "intGameID", "strGameName");
            ViewBag.intMemberID = new SelectList(db.Members, "intMemberID", "strFirstName");
            return View();
        }

        // POST: Game_Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "intGameMemberID,intGameID,intMemberID,bitOwnGame")] Game_Members game_Members)
        {
            if (ModelState.IsValid)
            {
                db.Game_Members.Add(game_Members);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.intGameID = new SelectList(db.Games, "intGameID", "strGameName", game_Members.intGameID);
            ViewBag.intMemberID = new SelectList(db.Members, "intMemberID", "strFirstName", game_Members.intMemberID);
            return View(game_Members);
        }

        // GET: Game_Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game_Members game_Members = db.Game_Members.Find(id);
            if (game_Members == null)
            {
                return HttpNotFound();
            }
            ViewBag.intGameID = new SelectList(db.Games, "intGameID", "strGameName", game_Members.intGameID);
            ViewBag.intMemberID = new SelectList(db.Members, "intMemberID", "strFirstName", game_Members.intMemberID);
            return View(game_Members);
        }

        // POST: Game_Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "intGameMemberID,intGameID,intMemberID,bitOwnGame")] Game_Members game_Members)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game_Members).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.intGameID = new SelectList(db.Games, "intGameID", "strGameName", game_Members.intGameID);
            ViewBag.intMemberID = new SelectList(db.Members, "intMemberID", "strFirstName", game_Members.intMemberID);
            return View(game_Members);
        }

        // GET: Game_Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game_Members game_Members = db.Game_Members.Find(id);
            if (game_Members == null)
            {
                return HttpNotFound();
            }
            return View(game_Members);
        }

        // POST: Game_Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game_Members game_Members = db.Game_Members.Find(id);
            db.Game_Members.Remove(game_Members);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

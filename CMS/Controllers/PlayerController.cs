using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Model;
using System.IO;
using CMS.Models;

namespace CMS.Controllers
{
    public class PlayerController : Controller
    {
        private GuessWhoContainer db = new GuessWhoContainer();

        //
        // GET: /Player/

        public ActionResult Index()
        {
            var player = db.Player.Include(p => p.Country).Include(p => p.Decade).Include(p => p.Level);
            return View(player.ToList());
        }

        //
        // GET: /Player/Details/5

        public ActionResult Details(int id = 0)
        {
            Player player = db.Player.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        //
        // GET: /Player/Create

        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Country, "Id", "Description");
            ViewBag.DecadeId = new SelectList(db.Decade, "Id", "Description");
            ViewBag.LevelId = new SelectList(db.Level, "Id", "Description");
            return View();
        }

        //
        // POST: /Player/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayerViewModel playerViewModel)
        {
            Player player = new Player()
            {
                CountryId = playerViewModel.CountryId,
                DecadeId = playerViewModel.DecadeId,
                LevelId = playerViewModel.LevelId,
                Id = playerViewModel.Id,
                IsPublished = playerViewModel.IsPublished,
                Name = playerViewModel.Name,
                Picture = ""
            };
            if (ModelState.IsValid)
            {
                var FileName = Guid.NewGuid().ToString();
                FileName += ".jpg";
                Upload(playerViewModel.File, ConfigurationManager.AppSettings["ImagePath"]+ "Players", FileName);

                player.Picture = FileName;
                db.Player.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Country, "Id", "Description", player.CountryId);
            ViewBag.DecadeId = new SelectList(db.Decade, "Id", "Description", player.DecadeId);
            ViewBag.LevelId = new SelectList(db.Level, "Id", "Description", player.LevelId);
            return View(playerViewModel);
        }

        //
        // GET: /Player/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Player player = db.Player.Find(id);
            var playerViewModel = new PlayerViewModel();
            if (player == null)
            {
                return HttpNotFound();
            }
            else
            {

                playerViewModel.Id = player.Id;
                playerViewModel.Name = player.Name;
                playerViewModel.DecadeId = player.DecadeId;
                playerViewModel.LevelId = player.LevelId;
                playerViewModel.CountryId = player.CountryId;
                playerViewModel.IsPublished = player.IsPublished;
                playerViewModel.Picture = player.Picture;
                
            }
            ViewBag.CountryId = new SelectList(db.Country, "Id", "Description", player.CountryId);
            ViewBag.DecadeId = new SelectList(db.Decade, "Id", "Description", player.DecadeId);
            ViewBag.LevelId = new SelectList(db.Level, "Id", "Description", player.LevelId);
            return View(playerViewModel);
        }

        //
        // POST: /Player/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlayerViewModel playerViewModel)
        {
            Player player = new Player()
            {
                CountryId = playerViewModel.CountryId,
                DecadeId = playerViewModel.DecadeId,
                LevelId = playerViewModel.LevelId,
                Id = playerViewModel.Id,
                IsPublished = playerViewModel.IsPublished,
                Name = playerViewModel.Name,
                Picture = playerViewModel.Picture
            };
            if (ModelState.IsValid)
            {
                if(playerViewModel.File.ContentLength > 0)
                {
                    var FileName = Guid.NewGuid().ToString();
                    FileName += ".jpg";
                    Upload(playerViewModel.File, ConfigurationManager.AppSettings["ImagePath"] + "Players", FileName);

                    player.Picture = FileName;
                }
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Country, "Id", "Description", player.CountryId);
            ViewBag.DecadeId = new SelectList(db.Decade, "Id", "Description", player.DecadeId);
            ViewBag.LevelId = new SelectList(db.Level, "Id", "Description", player.LevelId);
            return View(player);
        }

        //
        // GET: /Player/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Player player = db.Player.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        //
        // POST: /Player/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Player.Find(id);
            db.Player.Remove(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        public static bool Upload(HttpPostedFileBase file, string caminho, string nomeArquivo)
        {
            try
            {
                if (!Directory.Exists(caminho))
                {
                    Directory.CreateDirectory(caminho);
                }

                string FileLocation = Path.Combine(caminho, nomeArquivo);
                file.SaveAs(FileLocation);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
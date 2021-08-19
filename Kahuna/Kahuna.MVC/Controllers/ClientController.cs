using Kahuna.MVC.Data;
using Kahuna.MVC.Models;
using Kahuna.MVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kahuna.MVC.Controllers
{
    public class ClientController : Controller
    {        
        private ClientRepository repo = new ClientRepository();

        // GET: ClientController
        public ActionResult Index()
        {
            var clients = repo.GetAll();
            return View(clients);
        }

        //// GET: ClientController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost, Route("{action}")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            try
            {
                repo.Add(client);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Client c)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {

                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

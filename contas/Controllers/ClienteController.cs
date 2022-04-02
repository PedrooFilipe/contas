using contas.Entidades;
using contas.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contas.Controllers
{
    public class ClienteController : Controller
    {

        IClienteDAO iClienteDAO;

        public ClienteController(IClienteDAO iClienteDAO)
        {
            this.iClienteDAO = iClienteDAO;
        }

        // GET: ClienteController
        public ActionResult Index(string nome, string sort, bool desc)
        {
            List<Cliente> clientes = iClienteDAO.List(nome: nome, sort: sort, desc: desc);

            return View(clientes);
        }

        // GET: ClienteController/Create
        public ActionResult Save()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Cliente cliente)
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

        // GET: ClienteController/Edit/5
        public ActionResult Update(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
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

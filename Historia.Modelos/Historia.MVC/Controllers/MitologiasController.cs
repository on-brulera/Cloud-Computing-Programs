using Historia.Modelos;
using Historia.UAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Historia.MVC.Controllers
{
    public class MitologiasController : Controller
    {
        private string Url = "https://localhost:7149/api/Mitologias";
        private Crud<Mitologia> Crud { get; set; }

        public MitologiasController() { 
            this.Crud = new Crud<Mitologia>();
        }

        // GET: MitologiasController
        public ActionResult Index()
        {
            var datos = Crud.Select(Url);
            return View(datos);
        }

        // GET: MitologiasController/Details/5
        public ActionResult Details(int id)
        {
            var datos = Crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // GET: MitologiasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MitologiasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mitologia datos)
        {
            try
            {
                Crud.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: MitologiasController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = Crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: MitologiasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Mitologia datos)
        {
            try
            {
                Crud.Update(Url, id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: MitologiasController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = Crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: MitologiasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Mitologia datos)
        {
            try
            {
                Crud.Delete(Url, id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}

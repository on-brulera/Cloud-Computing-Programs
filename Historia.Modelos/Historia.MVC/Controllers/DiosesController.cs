using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Historia.Modelos;
using Historia.UAPI;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Historia.MVC.Controllers
{
    public class DiosesController : Controller
    {
        private string Url = "https://localhost:7149/api/Dioses";
        private Crud<Dios> Crud { get; set; }

        public DiosesController() { 
            this.Crud = new Crud<Dios>();
        }

        // GET: DiosesController
        public ActionResult Index()
        {
            var datos = Crud.Select(Url);
            return View(datos);
        }

        // GET: DiosesController/Details/5
        public ActionResult Details(int id)
        {
            var datos = Crud.Select_ById(Url,id.ToString());
            return View(datos);
        }

        // GET: DiosesController/Create
        public ActionResult Create()
        {
            // OBTENER LISTA DE MITOLOGIAS PARA COMBO BOX
            var listaMitologias = new Crud<Mitologia>()
                .Select(Url.Replace("Dioses", "Mitologias"))
                .Select(p => new SelectListItem     // transformamos del tipo Mitologias -> SelectListItem
                {
                    Value = p.Id.ToString(),       
                    Text = p.Nombre                
                })
                .ToList();

            ViewBag.ListaMitologias = listaMitologias;  // pasamos la lista de Provincias a la vista
            return View();
        }

        // POST: DiosesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dios datos)
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

        // GET: DiosesController/Edit/5
        public ActionResult Edit(int id)
        {
            // OBTENER MITOLOGIAS
            var listaMitologias = new Crud<Mitologia>()
                .Select(Url.Replace("Dioses", "Mitologias"))
                .Select(p => new SelectListItem     // transformamos del tipo Mitologia -> SelectListItem
                {
                    Value = p.Id.ToString(),       
                    Text = p.Nombre                
                })
                .ToList();

            ViewBag.ListaMitologias = listaMitologias;  // pasamos la lista de Provincias a la vista

            var datos = Crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: DiosesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dios datos)
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

        // GET: DiosesController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = Crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: DiosesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Dios datos)
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

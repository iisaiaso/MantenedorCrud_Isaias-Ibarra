using CRUD_Isaias_Ibarra_Onofre.Data;
using CRUD_Isaias_Ibarra_Onofre.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Isaias_Ibarra_Onofre.Controllers
{
    public class PruebaController : Controller
    {
        private readonly PruebaContext _context;

        public PruebaController(PruebaContext context)
        {
            _context = context;
        }


        // GET: PruebaController
        public IActionResult Index()
        {
            IEnumerable<Prueba> pruebas = _context.GetAll();
            return View(pruebas);
          
        }
        public IActionResult Create()
        {
            return View();
        }

        // GET: PruebaController/Create
        [HttpPost]
        public IActionResult Create(Prueba prueba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prueba);
                return RedirectToAction(nameof(Index));
            }
            return View(prueba);
        }

        // GET: PruebaController/Edit/5
        public IActionResult Edit(int id)
        {
            Prueba prueba = _context.GetAll().FirstOrDefault(e => e.Id == id);
            if (prueba == null)
            {
                return NotFound();
            }
            return View(prueba);
        }

        // POST: PruebaController/Edit/5
        [HttpPost]
        public IActionResult Edit(Prueba prueba)
        {
            if (ModelState.IsValid)
            {
                _context.Update(prueba);
                return RedirectToAction(nameof(Index));
            }
            return View(prueba);
        }


        public IActionResult Delete(int id)
        {
            Prueba prueba = _context.GetAll().FirstOrDefault(e => e.Id == id);
            if (prueba == null)
            {
                return NotFound();
            }
            return View(prueba);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

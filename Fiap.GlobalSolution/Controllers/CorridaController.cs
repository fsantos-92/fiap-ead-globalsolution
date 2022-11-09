using Fiap.GlobalSolution.Models;
using Fiap.GlobalSolution.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fiap.GlobalSolution.Controllers
{
    public class CorridaController : Controller
    {
        private GlobalSolutionContext _context;

        public CorridaController(GlobalSolutionContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            var lista = _context.Corridas.Include(x => x.Motorista).Include(x => x.Passageiro).ToList();  
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var motoristas = _context.Motoristas.ToList();
            var passageiros = _context.Passageiros.ToList();

            ViewBag.motoristas = new SelectList(motoristas, "MotoristaId", "Nome");
            ViewBag.passageiros = new SelectList(passageiros, "PassageiroId", "Nome");

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Corrida corrida)
        {
            _context.Corridas.Add(corrida);
            _context.SaveChanges();
            TempData["msg"] = "Corrida Adicionada";
            return RedirectToAction(nameof(Cadastrar));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var motoristas = _context.Motoristas.ToList();
            var passageiros = _context.Passageiros.ToList();

            ViewBag.motoristas = new SelectList(motoristas, "MotoristaId", "Nome");
            ViewBag.passageiros = new SelectList(passageiros, "PassageiroId", "Nome");

            var corrida = _context.Corridas.Find(id);
            return View(corrida);
        }
        [HttpPost]
        public IActionResult Editar(Corrida corrida)
        {
            _context.Corridas.Update(corrida);
            _context.SaveChanges();
            TempData["msg"] = "Corrida atualizada!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            var corrida = _context.Corridas.Find(id);
            _context.Corridas.Remove(corrida);
            _context.SaveChanges();
            TempData["msg"] = "Corrida excluída com sucesso";
            return RedirectToAction("Index");
        }
    }
}

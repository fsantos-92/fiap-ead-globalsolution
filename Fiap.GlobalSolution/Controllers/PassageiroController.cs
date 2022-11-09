using Fiap.GlobalSolution.Models;
using Fiap.GlobalSolution.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap.GlobalSolution.Controllers
{
    public class PassageiroController : Controller
    {
        private GlobalSolutionContext _context;

        public PassageiroController(GlobalSolutionContext context)
        {
            _context = context;
        }
        public IActionResult Index(string nome)
        {
            var list = _context.Passageiros.Where(x => x.Nome == nome || nome == null).ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Passageiro passageiro)
        {
            _context.Passageiros.Add(passageiro);
            _context.SaveChanges();
            TempData["msg"] = "Passageiro Adicionado";
            return RedirectToAction(nameof(Cadastrar));
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            var passageiro = _context.Passageiros.Find(id);
            _context.Passageiros.Remove(passageiro);
            _context.SaveChanges();
            TempData["msg"] = "Passageiro excluído com sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var passageiro = _context.Passageiros.Where(x => x.PassageiroId == id).FirstOrDefault();
            return View(passageiro);
        }


        [HttpPost]
        public IActionResult Editar(Passageiro passageiro)
        {
            _context.Passageiros.Update(passageiro);
            _context.SaveChanges();
            TempData["msg"] = "Passageiro atualizado!";
            return RedirectToAction("Index");
        }
    }
}

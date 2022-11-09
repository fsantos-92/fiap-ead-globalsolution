using Fiap.GlobalSolution.Models;
using Fiap.GlobalSolution.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap.GlobalSolution.Controllers
{
    public class MotoristaController : Controller
    {
        private GlobalSolutionContext _context;

        public MotoristaController(GlobalSolutionContext context)
        {
            _context = context;
        }
        public IActionResult Index(string nome)
        {
            var list = _context.Motoristas.Where(x => x.Nome == nome || nome == null).Include(x => x.Telefone).ToList(); 
            return View(list);
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Motorista motorista)
        {
            _context.Motoristas.Add(motorista);
            _context.Telefones.Add(motorista.Telefone);
            _context.SaveChanges();
            TempData["msg"] = "Motorista Adicionado";
            return RedirectToAction(nameof(Cadastrar));
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            var motorista = _context.Motoristas.Find(id);
            _context.Motoristas.Remove(motorista);
            _context.SaveChanges();
            TempData["msg"] = "Motorista excluído com sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var motorista = _context.Motoristas.Where(x => x.MotoristaId == id).Include(x => x.Telefone).FirstOrDefault();
            return View(motorista);
        }


        [HttpPost]
        public IActionResult Editar(Motorista motorista)
        {
            _context.Motoristas.Update(motorista);
            _context.SaveChanges();
            TempData["msg"] = "Motorista atualizado!";
            return RedirectToAction("Index", new { id = motorista.MotoristaId });
        }
    }
}

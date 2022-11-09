using Fiap.GlobalSolution.Models;
using Fiap.GlobalSolution.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap.GlobalSolution.Controllers
{
    public class VeiculoController : Controller
    {
        private GlobalSolutionContext _context;

        public VeiculoController(GlobalSolutionContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            var motorista = _context.Motoristas.Find(id);
            var veiculos = _context.Veiculos.Where(x => x.MotoristaId == id).ToList();
            ViewBag.motorista = motorista;
            return View(veiculos);
        }
        [HttpGet]
        public IActionResult Cadastrar(int id)
        {
            var motorista = _context.Motoristas.Find(id);
            ViewBag.motorista = motorista;
            return View();  
        }

        [HttpPost]
        public IActionResult Cadastrar(Veiculo veiculo)
        {
            var motorista = _context.Motoristas.Find(veiculo.MotoristaId);
            veiculo.Motorista = motorista;
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
            TempData["msg"] = "Veiculo Adicionado";
            return RedirectToAction(nameof(Cadastrar));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var veiculo = _context.Veiculos.Include(m => m.Motorista).Where(m => m.VeiculoId == id).FirstOrDefault();
            return View(veiculo);
        }


        [HttpPost]
        public IActionResult Editar(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            _context.SaveChanges();
            TempData["msg"] = "Motorista atualizado!";
            return RedirectToAction("Index", new { id=veiculo.MotoristaId });
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            var veiculo = _context.Veiculos.Find(id);
            int motoristaId = veiculo.MotoristaId;
            _context.Veiculos.Remove(veiculo);
            _context.SaveChanges();
            TempData["msg"] = "Veículo excluído com sucesso";
            return RedirectToAction("Index", new { id = motoristaId });
        }
    }
}

using Fiap.GlobalSolution.Models;
using Fiap.GlobalSolution.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fiap.GlobalSolution.Controllers
{
    public class PontoController : Controller
    {
        private GlobalSolutionContext _context;

        public PontoController(GlobalSolutionContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.PontosTrabalho.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(PontoTrabalho ponto)
        {
            _context.PontosTrabalho.Add(ponto);
            _context.SaveChanges();
            TempData["msg"] = "Ponto Adicionado";
            return RedirectToAction(nameof(Cadastrar));
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            var ponto = _context.PontosTrabalho.Find(id);
            _context.PontosTrabalho.Remove(ponto);
            _context.SaveChanges();
            TempData["msg"] = "Ponto excluído com sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var ponto = _context.PontosTrabalho.Where(x => x.PontoTrabalhoId== id).FirstOrDefault();
            return View(ponto);
        }


        [HttpPost]
        public IActionResult Editar(PontoTrabalho ponto)
        {
            _context.PontosTrabalho.Update(ponto);
            _context.SaveChanges();
            TempData["msg"] = "Ponto atualizado!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalhar(int id)
        {
            var motoristasPonto = _context.MotoristaPontoTrabalhos.Where(x => x.PontoTrabalhoId== id).Select(x => x.Motorista).ToList();
            ViewBag.motoristaPonto = motoristasPonto;

            var lista = _context.Motoristas.ToList();

            var filter = lista.Where(x => !motoristasPonto.Contains(x));

            ViewBag.motoristas = new SelectList(filter, "MotoristaId", "Nome");

            var ponto = _context.PontosTrabalho.Find(id);
            return View(ponto);
        }

        [HttpPost]
        public IActionResult Adicionar(MotoristaPontoTrabalho motoristaPontoTrabalho)
        {
            _context.MotoristaPontoTrabalhos.Add(motoristaPontoTrabalho);
            _context.SaveChanges();

            TempData["msg"] = "Motorista adicionado!";
            return RedirectToAction("Detalhar", new { id = motoristaPontoTrabalho.PontoTrabalhoId });
        }

        [HttpPost]
        public IActionResult RemoverMotorista(int pontoTrabalhoId, int motoristaId)
        {
            var pontoTrabalhoMotorista = _context.MotoristaPontoTrabalhos.Where(x => x.PontoTrabalhoId == pontoTrabalhoId && x.MotoristaId == motoristaId).FirstOrDefault();
            _context.MotoristaPontoTrabalhos.Remove(pontoTrabalhoMotorista);
            _context.SaveChanges();
            TempData["msg"] = "Motorista removido do ponto com sucesso";
            return RedirectToAction("Detalhar", new { id= pontoTrabalhoId });
        }
    }
}

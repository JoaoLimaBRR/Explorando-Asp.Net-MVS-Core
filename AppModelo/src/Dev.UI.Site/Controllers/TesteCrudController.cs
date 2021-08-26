using Dev.UI.Site.Data;
using Dev.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Dev.UI.Site.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MeuDbContext _context;

        public TesteCrudController(MeuDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var aluno = new Aluno
            {
                Nome = "João",
                DataNascimento = DateTime.Now,
                Email = "joaovitorsoareslima12@gmail.com"
            };

            _context.Alunos.Add(aluno);
            _context.SaveChanges();


            var aluno2 = _context.Alunos.Find(aluno.Id);
            var aluno3 = _context.Alunos.FirstOrDefault(a => a.Email == "joaovitorsoareslima12@gmail.com");

            var aluno4 = _context.Alunos.Where(a => a.Nome == "João");

            aluno.Nome = "Eduardo";
            _context.Alunos.Update(aluno);
            _context.SaveChanges();


            _context.Alunos.Remove(aluno);
            _context.SaveChanges();

            return View("_Layout");
        }
    }
}
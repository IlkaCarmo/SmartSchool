 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        private readonly SmartContext _context;

        public readonly IRepository _repo;

        public AlunoController(SmartContext context,
                               IRepository repo)                  
        {
            _context = context;
            _repo = repo;
        }

        [HttpGet("pegaResposta")]
        public IActionResult pegaResposta()
        {
            return Ok(_repo.pegaResposta());
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }


        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");

            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(Sobrenome));
            if (aluno == null) return BadRequest("O aluno não foi encontrado");

            return Ok(aluno);
        }

        //api/aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {

            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        //api/aluno
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("O aluno não foi encontrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        //api/aluno
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu  = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu  == null) return BadRequest("O aluno não foi encontrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }


        //api/aluno
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");

            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }

    }
}

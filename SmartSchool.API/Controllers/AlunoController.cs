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
        public readonly IRepository _repo;

        public AlunoController(IRepository repo)                  
        {
             _repo = repo;
        }
        

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAlunos(true);
            return Ok(result);
         }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoByID(id, false);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");

            return Ok(aluno);
        }

        //api/aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);

            }

            return BadRequest("Aluno não cadastrado");

        }

        //api/aluno
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoByID(id);
            if (alu == null) return BadRequest("O aluno não foi encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);

            }

            return BadRequest("Aluno não Atualizado");
        }

        //api/aluno
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu  = _repo.GetAlunoByID(id);
            if (alu  == null) return BadRequest("O aluno não foi encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);

            }

            return BadRequest("Aluno não Atualizado");
        }


        //api/aluno
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var aluno = _repo.GetAlunoByID(id);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");

            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno deletado");
            }

            return BadRequest("Aluno não deletado");
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        private readonly IRepository _repo; 
        public ProfessorController(SmartContext context, IRepository repo) {

            _repo = repo;
            _context = context;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }


        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var Professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (Professor == null) return BadRequest("O Professo não foi encontrado");

            return Ok(Professor);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var Professor = _context.Professores.FirstOrDefault(a => a.Nome.Contains(nome) );
            if (Professor == null) return BadRequest("O Professor não foi encontrado");

            return Ok(Professor);
        }

        //api/Professor
        [HttpPost]
        public IActionResult Post(Professor professor)
        {

            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);

            }

            return BadRequest("Professor não cadastrado");
        }

        //api/Professor
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor Professor)
        {
            var alu = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("O Professor não foi encontrado");

            _context.Update(Professor);
            _context.SaveChanges();
            return Ok(Professor);
        }

        //api/Professor
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor Professor)
        {
            var Prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (Prof == null) return BadRequest("O Professor não foi encontrado");

            _context.Update(Professor);
            _context.SaveChanges();
            return Ok(Professor);
        }


        //api/Professor
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var Professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (Professor == null) return BadRequest("O Professor não foi encontrado");

            _context.Remove(Professor);
            _context.SaveChanges();
            return Ok();
        }

    }
}
 

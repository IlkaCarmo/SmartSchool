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
 
        public ProfessorController(SmartContext context) {

            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professos);
        }


        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var Professor = _context.Professos.FirstOrDefault(a => a.Id == id);
            if (Professor == null) return BadRequest("O Professo não foi encontrado");

            return Ok(Professor);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var Professor = _context.Professos.FirstOrDefault(a => a.Nome.Contains(nome) );
            if (Professor == null) return BadRequest("O Professor não foi encontrado");

            return Ok(Professor);
        }

        //api/Professor
        [HttpPost]
        public IActionResult Post(Professor Professor)
        {

            _context.Add(Professor);
            _context.SaveChanges();
            return Ok(Professor);
        }

        //api/Professor
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor Professor)
        {
            var alu = _context.Professos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("O Professor não foi encontrado");

            _context.Update(Professor);
            _context.SaveChanges();
            return Ok(Professor);
        }

        //api/Professor
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor Professor)
        {
            var Prof = _context.Professos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (Prof == null) return BadRequest("O Professor não foi encontrado");

            _context.Update(Professor);
            _context.SaveChanges();
            return Ok(Professor);
        }


        //api/Professor
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var Professor = _context.Professos.FirstOrDefault(a => a.Id == id);
            if (Professor == null) return BadRequest("O Professor não foi encontrado");

            _context.Remove(Professor);
            _context.SaveChanges();
            return Ok();
        }

    }
}
 

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
        

        private readonly IRepository _repo; 
        public ProfessorController(IRepository repo) {

            _repo = repo;
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetProfessores(true);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Professor = _repo.GetProfessorByID(id, false);
            if (Professor == null) return BadRequest("O Professo não foi encontrado");

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
            var prof = _repo.GetProfessorByID(id);
            if (prof == null) return BadRequest("  Professor não foi encontrado");

            _repo.Update(Professor);
            if (_repo.SaveChanges())
            {
                return Ok(Professor);

            }

            return BadRequest("Professor não Atualizado");
        }

        //api/Professor
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor Professor)
        {
            var Prof = _repo.GetProfessorByID(id);
            if (Prof == null) return BadRequest("O Professor não foi encontrado");

            _repo.Update(Professor);
            if (_repo.SaveChanges())
            {
                return Ok(Professor);

            }

            return BadRequest("Professor não Atualizado");
        }


        //api/Professor
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var Professor = _repo.GetProfessorByID(id);
            if (Professor == null) return BadRequest("O Professor não foi encontrado");

            _repo.Update(Professor);
            if (_repo.SaveChanges())
            {
                return Ok(Professor);
            }

            return BadRequest("Professor não deletado");
        }

    }
}
 

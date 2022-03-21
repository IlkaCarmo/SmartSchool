using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.DTO;
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

        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper) {

            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professor = _repo.GetProfessores(true);

            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(professor));
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Professor = _repo.GetProfessorByID(id, false);
            if (Professor == null) return BadRequest("O Professo não foi encontrado");

            var professorDto = _mapper.Map<AlunoDto>(Professor);

            return Ok(Professor);
        }

        //api/Professor
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var professor = _mapper.Map<Professor>(model);

            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/Professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));

            }

            return BadRequest("Professor não cadastrado");
        }

        //api/Professor
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorByID(id);
            if (professor == null) return BadRequest("  Professor não foi encontrado");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/profesor/{model.Id}", _mapper.Map<ProfessorDto>(professor));

            }

            return BadRequest("Professor não Atualizado");
        }

        //api/Professor
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorByID(id);
            if (professor == null) return BadRequest("O Professor não foi encontrado");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));

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
 

using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Data
{
    public interface IRepository
    {
        void Add <T>(T entity) where T : class;
        void Update <T>(T entity) where T : class;
        void Delete <T>(T entity) where T : class;
        bool SaveChanges();

        //Alunos
        Aluno[] GetAlunos(bool includeProfessor = false);
        Aluno[] GetAlunosByDisciplinaID(int disciplinaId, bool includeProfessor = false);
        Aluno GetAlunoByID(int alunoID, bool includeProfessor = false);


        //Professores
        Professor[] GetProfessores(bool incluideAlunos = false);
        Professor[] GetProfessoresByDisciplinaID(int disciplinaId, bool includeAlunos = false);
        Professor GetProfessorByID(int professorId, bool includeProfessor = false);
    }
}

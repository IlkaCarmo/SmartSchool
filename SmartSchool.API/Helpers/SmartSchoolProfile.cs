using AutoMapper;
using SmartSchool.API.DTO;
using SmartSchool.API.Models;

namespace SmartSchool.API.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
            .ForMember(
                dest => dest.Nome,
                opt => opt.MapFrom(src => $"{ src.Nome} {src.Sobrenome}")
                )
             .ForMember(
                dest => dest.Idade,
                opt => opt.MapFrom(src => src.DataNac.GetCurrentAge())
                );

              CreateMap<AlunoDto, Aluno>();
             CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();


            CreateMap<Professor, ProfessorDto>()
            .ForMember(
                dest => dest.Nome,
                opt => opt.MapFrom(src => $"{ src.Nome} {src.Sobrenome}"));
 

            CreateMap<ProfessorDto, Professor>();
            CreateMap<Professor, ProfessorRegistrarDto>().ReverseMap();

        }
    }
}

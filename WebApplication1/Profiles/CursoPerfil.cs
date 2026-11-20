using AutoMapper;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Profiles
{
    public class CursoPerfil : Profile
    {
        public CursoPerfil()
        {
            CreateMap<Curso, CursosDto>();
            CreateMap<CursosDto, Curso>();
        }
    }
}

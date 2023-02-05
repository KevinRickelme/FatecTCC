using AutoMapper;
using ProjetoFatec.Application.ViewModels;
using ProjetoFatec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PublicacaoViewModel, Publicacao>();
            CreateMap<PerfilViewModel, Perfil>();
            CreateMap<UsuarioViewModel, Usuario>(); 
        }
    }
}

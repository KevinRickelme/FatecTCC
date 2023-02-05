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
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Publicacao, PublicacaoViewModel>();
            CreateMap<Perfil, PerfilViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}

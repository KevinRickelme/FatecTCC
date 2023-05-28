using AutoMapper;
using ProjetoFatec.Application.DTOs;
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
            CreateMap<Publicacao, PublicacaoDTO>();
            CreateMap<Perfil, PerfilDTO>();
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Feed, FeedDTO>();
            CreateMap<Comentario, ComentarioDTO>();
            CreateMap<Curtida, CurtidaDTO>();
        }
    }
}

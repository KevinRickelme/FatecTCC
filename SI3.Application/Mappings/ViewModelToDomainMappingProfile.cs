using AutoMapper;
using SI3.Application.DTOs;
using SI3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI3.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PublicacaoDTO, Publicacao>();
            CreateMap<PerfilDTO, Perfil>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<FeedDTO, Feed>();
            CreateMap<ComentarioDTO, Comentario>();
            CreateMap<CurtidaDTO, Curtida>();
        }
    }
}

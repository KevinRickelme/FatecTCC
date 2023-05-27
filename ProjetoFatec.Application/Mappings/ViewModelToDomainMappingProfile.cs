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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PublicacaoDTO, Publicacao>();
            CreateMap<PerfilDTO, Perfil>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<FeedDTO, Feed>();
            CreateMap<ComentarioDTO, Comentario>();
        }
    }
}

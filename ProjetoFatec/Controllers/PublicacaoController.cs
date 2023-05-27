﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFatec.Application.Interfaces;
using ProjetoFatec.Application.DTOs;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Domain.Interfaces;
using ProjetoFatec.Utils;
using ProjetoFatec.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace ProjetoFatec.Controllers
{
    [Authorize]
    public class PublicacaoController : Controller
    {
        private readonly ILogger<PublicacaoController> _logger;
        private readonly IUsuarioService _usuarioService;
        private readonly IPublicacaoService _publicacaoService;
        private readonly IPerfilService _perfilService;
        private readonly IComentarioService _comentarioService;


        public PublicacaoController(ILogger<PublicacaoController> logger, IUsuarioService usuarioService, IPublicacaoService publicacaoService, IPerfilService perfilService, IComentarioService comentarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
            _publicacaoService = publicacaoService;
            _perfilService = perfilService;
            _comentarioService = comentarioService;
        }


        public async Task<IActionResult> PublicarPostagem(PostViewModel pvm, IFormFile imagem)
        {
            try
            {
                var usuario = _usuarioService.GetUsuarioViewModel(ClaimUtils.GetClaimInfo(User, "emailaddress")).Result;
                var perfil = _perfilService.GetPerfil(usuario).Result;
                perfil.Usuario = _usuarioService.GetUsuario(usuario.Email).Result;
                var form = Request.Form;

                var publicacao = PopularPublicacao(form, perfil, imagem);

                bool sucesso = _publicacaoService.Add(publicacao);
                if (sucesso)
                    return RedirectToAction("Index", "Home");
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index","Home", new {@erro = ex.Message.ToString()});
            }
        }

        private PublicacaoDTO PopularPublicacao(IFormCollection form, Perfil perfil, IFormFile imagem)
        {
            PublicacaoDTO pb = new PublicacaoDTO();
            pb.DataCriacao = DateTime.Now;
            pb.Legenda = form["textoPublicacao"];
            pb.Perfil = perfil;
            pb.CaminhoFoto = SalvarImagem(imagem, perfil.Id).Result;
            return pb;
        }

        private async Task<string> SalvarImagem(IFormFile imagem, int idPerfil)
        {
            if (imagem != null)
            {
                var caminho = Path.Combine("wwwroot/imgs/" + idPerfil + imagem.FileName);
                using (FileStream stream = new FileStream(caminho, FileMode.Create))
                {
                    await imagem.CopyToAsync(stream);
                    stream.Close();
                }
                return caminho;
            }
            else
            {
                return null;
            }
        }

        public IActionResult ShowpopUp(int id)
        {
            var publicacao = _publicacaoService.GetPublicacao(id);

            //specify the name or path of the partial view
            return PartialView("_partialModalPublicacao", publicacao.Comentarios);
        }
        public IActionResult ShowpopUp2(int id)
        {
            var publicacao = _publicacaoService.GetPublicacao(id);

            //specify the name or path of the partial view
            return PartialView("_partialModalPublicacao", publicacao.Comentarios);
        }

        [HttpPost]
        public IActionResult PublicarComentario(string textoPublicacao, int IdPublicacao)
        {
            var publicacao = _publicacaoService.GetPublicacao(IdPublicacao);
            var usuario = _usuarioService.GetUsuarioViewModel(ClaimUtils.GetClaimInfo(User, "emailaddress")).Result;
            var perfil = _perfilService.GetPerfil(usuario).Result;

            ComentarioDTO comentarioDTO = new()
            {
                IdPublicacao = IdPublicacao,
                IdPerfil = perfil.Id,
                Descricao = textoPublicacao,
                DataComentario = DateTime.Now
            };

            var sucesso = _comentarioService.Add(comentarioDTO);
            return RedirectToAction("Index","Home", new {@sucesso = "Comentário adicionado"});
        }
    }


}
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SI3.Application.Interfaces;
using SI3.Application.Services;
using SI3.Application.DTOs;
using SI3.Domain.Entities;
using SI3.Domain.Interfaces;
using SI3.Utils;
using SI3.ViewModels;
using System.Diagnostics;

namespace SI3.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService _usuarioService;
        private readonly IPublicacaoService _publicacaoService;
        private readonly IPerfilService _perfilService;
        private readonly IFeedService _feedService;

        public HomeController(ILogger<HomeController> logger, IUsuarioService usuarioService, IPublicacaoService publicacaoService, IPerfilService perfilService, IFeedService feedService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
            _publicacaoService = publicacaoService;
            _perfilService = perfilService;
            _feedService = feedService;
        }


        [Authorize]
        public async Task<IActionResult> Index(string? erro, string? sucesso)
        {
            if (!string.IsNullOrEmpty(erro))
                ViewBag.Erro = erro;
            if (!string.IsNullOrEmpty(sucesso))
                ViewBag.Sucesso = sucesso;
            UsuarioDTO usuario = new UsuarioDTO();
            usuario.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");

            ViewBag.Nome = (ClaimUtils.GetClaimInfo(User, "name"));
            ViewBag.PrimeiroNome = (ClaimUtils.GetClaimInfo(User, "name")).Split()[0];
            ViewBag.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");


            if (_usuarioService.PrimeiroAcesso(usuario))
            {
                return RedirectToAction("Cadastro", "Usuario");
            }
            else {
                usuario = _usuarioService.GetUsuarioViewModel(usuario.Email).Result;
                if (!(_usuarioService.TemPerfilCriado(usuario)))
                {
                    return RedirectToAction("Cadastro", "Usuario");
                }
                usuario = _usuarioService.GetUsuarioViewModel(ClaimUtils.GetClaimInfo(User, "emailaddress")).Result;
                var perfil = _perfilService.GetPerfil(usuario).Result;
                ViewData["PerfilUsuario"] = perfil;
                var Feed = _feedService.GetFeed(perfil.Id).Result;
                ViewData["Publicacoes"] = Feed.Publicacoes;
                return View();
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Chat()
        {
            UsuarioDTO usuario = new UsuarioDTO();
            usuario.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");

            ViewBag.Nome = (ClaimUtils.GetClaimInfo(User, "name"));
            ViewBag.PrimeiroNome = (ClaimUtils.GetClaimInfo(User, "name")).Split()[0];
            ViewBag.Email = ClaimUtils.GetClaimInfo(User, "emailaddress");


            if (_usuarioService.PrimeiroAcesso(usuario))
            {
                return RedirectToAction("Cadastro", "Usuario");
            }
            else
            {
                usuario = _usuarioService.GetUsuarioViewModel(usuario.Email).Result;
                if (!(_usuarioService.TemPerfilCriado(usuario)))
                {
                    return RedirectToAction("Cadastro", "Usuario");
                }
                usuario = _usuarioService.GetUsuarioViewModel(ClaimUtils.GetClaimInfo(User, "emailaddress")).Result;
                var perfil = _perfilService.GetPerfil(usuario).Result;
                ViewData["PerfilUsuario"] = perfil;
                var Feed = _feedService.GetFeed(perfil.Id).Result;
                ViewData["Publicacoes"] = Feed.Publicacoes;
                return View();
            }
        }

    }
}
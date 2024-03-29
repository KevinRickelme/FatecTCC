﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFatec.Application.Interfaces;
using ProjetoFatec.Application.Services;
using ProjetoFatec.Application.ViewModels;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Domain.Interfaces;
using ProjetoFatec.Utils;
using ProjetoFatec.ViewModels;
using System.Diagnostics;

namespace ProjetoFatec.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService _usuarioService;
        private readonly IPublicacaoService _publicacaoService;
        private readonly IPerfilService _perfilService;

        public HomeController(ILogger<HomeController> logger, IUsuarioService usuarioService, IPublicacaoService publicacaoService, IPerfilService perfilService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
            _publicacaoService = publicacaoService;
            _perfilService = perfilService;
        }


        [Authorize]
        public async Task<IActionResult> Index()
        {
            UsuarioViewModel usuario = new UsuarioViewModel();
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
                ViewData["PerfilUsuario"] = _perfilService.GetPerfil(usuario).Result;
                ViewData["Publicacoes"] = _publicacaoService.GetPublicacoes(usuario).Result;
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



    }
}
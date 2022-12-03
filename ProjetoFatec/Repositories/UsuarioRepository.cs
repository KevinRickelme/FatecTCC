using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFatec.Data;
using ProjetoFatec.Enums;
using ProjetoFatec.Interfaces;
using ProjetoFatec.Models;
using ProjetoFatec.ViewModels;
using System.Security.Claims;

namespace ProjetoFatec.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;
        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void CadastrarUsuario(CookiesViewModel cvm)
        {
            Usuario user = new Usuario()
            {
                Email = cvm.Email,
                Privilegio = PrivilegioEnum.Padrao,
                Status = StatusUsuarioEnum.Ativo
            };

            _context.Login.Add(user);
            _context.SaveChanges();
        }

        public Usuario? GetUsuario(string email)
        {
            return _context.Login.FirstOrDefault(u=> u.Email == email);
        }

        public bool PrimeiroAcesso(CookiesViewModel cvm)
        {
            bool result = _context.Login.Any(u => u.Email == cvm.Email);
             return !result;
        }

        public bool CadastrarPerfilDeUsuario(IFormCollection formularioCadastro, string email)
        {
            try
            {
                Perfil perfil = new Perfil()
                {
                    Nome = formularioCadastro["PrimeiroNome"],
                    Sobrenome = formularioCadastro["Sobrenome"],
                    Telefone = formularioCadastro["DDD"] + formularioCadastro["Telefone"],
                    Usuario = GetUsuario(email),
                    DataNascimento = Convert.ToDateTime(formularioCadastro["DataNascimento"]),
                    Sexo = formularioCadastro["Sexo"] == "Feminino" ? SexoEnum.Feminino : SexoEnum.Masculino,
                    NomeCurso = formularioCadastro["NomeCurso"],
                    SemestreAtual = int.Parse(formularioCadastro["SemestreAtual"])

                };
                _context.Perfis.Add(perfil);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Perfil GetPerfil(CookiesViewModel cvm)
        {
            return _context.Perfis.FirstOrDefault(p => p.Usuario.Id == (GetUsuario(cvm.Email).Id));
        }

        public bool TemPerfilCriado(CookiesViewModel cvm)
        {
            try { 
            bool result = _context.Perfis.Any(p => p.Usuario.Id == GetUsuario(cvm.Email).Id);
            return result;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return false;
            }
        }
    }
}

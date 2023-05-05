using Microsoft.EntityFrameworkCore;
using ProjetoFatec.Domain.Entities;
using ProjetoFatec.Domain.Enums;
using ProjetoFatec.Domain.Interfaces;
using ProjetoFatec.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Infra.Data.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly ApplicationContext _context;
        public PerfilRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool Add(Perfil perfil)
        {
            _context.Perfis.Add(perfil);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Perfil perfil)
        {
            _context.Perfis.Update(perfil);
            _context.SaveChanges();
            return true;
        }

        public async Task<Perfil?> GetPerfil(Usuario usuario)
        {
            return await _context.Perfis.FirstOrDefaultAsync(p => p.Usuario.Id == (usuario.Id));
        }

        public async Task<Perfil?> GetPerfil(int id)
        {
            Perfil perf = await _context.Perfis.Include("Usuario").Include("Amigos").FirstOrDefaultAsync(p => p.Id == id);
            if (perf != null) {
                if (perf.Amigos.Count == 0)
                    perf.Amigos = _context.Amigos.Where(a => a.IdPerfilSolicitado == id || a.IdPerfilSolicitante == id && a.Status == StatusAmizadeEnum.Ativo).ToList();
                if (perf.Amigos != null || perf.Amigos.Count == 0) {
                    perf.PerfisDeAmigos = new ();
                    foreach (var am in perf.Amigos)
                    {
                        
                        if (am.IdPerfilSolicitante == perf.Id)
                            perf.PerfisDeAmigos.Add(_context.Perfis.Where(p => p.Id == am.IdPerfilSolicitado).First());
                        else
                            perf.PerfisDeAmigos.Add(_context.Perfis.Where(p => p.Id == am.IdPerfilSolicitante).First());
                    }
                }
            }
            return perf;
        }

        public bool EnviarSolicitacao(int IdPerfilSolicitante, int IdPerfilSolicitado)
        {
            Amigo PedidoAmizade = new Amigo()
            {
                IdPerfilSolicitante = IdPerfilSolicitante,
                IdPerfilSolicitado = IdPerfilSolicitado,
                Status = StatusAmizadeEnum.Pendente,
                DataAmizade = DateTime.Now
            };
            _context.Amigos.Add(PedidoAmizade);
            return _context.SaveChanges() == 1? true:false;
        }
    }
}

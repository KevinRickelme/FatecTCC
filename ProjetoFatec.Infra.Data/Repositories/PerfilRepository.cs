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
            foreach (var amigos in perfil.Amigos)
                _context.Entry(amigos).Reload();

            perfil.FotoPerfil = _context.FotoPerfis.Where(fp => fp.IdPerfil == perfil.Id).OrderBy(fp=>fp.Id).LastOrDefault();
            if(perfil.FotoPerfil != null)
                _context.Entry(perfil.FotoPerfil).Reload();
            //_context.Entry(perfil).Reload();
            _context.Perfis.Update(perfil);

            _context.SaveChanges();
            
            return true;
        }

        public async Task<Perfil?> GetPerfil(Usuario usuario)
        {
            Perfil perf = await _context.Perfis.FirstOrDefaultAsync(p => p.Usuario.Id == (usuario.Id));
            //perf.Amigos = _context.Amigos.Include("PerfilSolicitante").Where(a => (a.IdPerfilSolicitado == perf.Id || a.IdPerfilSolicitante == perf.Id) && a.Status != StatusAmizadeEnum.Removido).ToList();

            return perf;
        }

        public Perfil? GetPerfil(int id)
        {
            Perfil? perf = _context.Perfis.Include("Usuario").
                FirstOrDefault(p => p.Id == id);

            perf.Publicacoes = _context.Publicacoes.Where(p => (p.IdPerfil == perf.Id && p.Compartilhado != true)|| p.IdPerfilQueCompartilhou == perf.Id)
                .Include(nameof(Perfil)).Include("PublicacaoOriginal").Include(p=> p.PublicacaoOriginal.Curtidas)
                .Include(p=>p.PublicacaoOriginal.Comentarios).Include(p => p.PublicacaoOriginal.Perfil).Include("Comentarios").Include("Curtidas")
                .Include("PerfilQueCompartilhou").OrderByDescending(p => p.DataCriacao)
                .ToList();
            

            if (perf != null) {
                perf.Amigos = _context.Amigos.Include("PerfilSolicitante").Where(a => (a.IdPerfilSolicitado == id || a.IdPerfilSolicitante == id) && a.Status != StatusAmizadeEnum.Removido && (a.IdPerfilSolicitado != a.IdPerfilSolicitante) ).ToList();
                if (perf.Amigos != null || perf.Amigos.Count == 0) {
                    perf.PerfisDeAmigos = new ();
                    foreach (var am in perf.Amigos)
                    {
                        
                        if (am.IdPerfilSolicitante == perf.Id && am.Status == StatusAmizadeEnum.Ativo)
                            perf.PerfisDeAmigos.Add(_context.Perfis.Where(p => p.Id == am.IdPerfilSolicitado && am.Status == StatusAmizadeEnum.Ativo && (am.IdPerfilSolicitado != am.IdPerfilSolicitante)).First());
                        else
                            if(am.Status == StatusAmizadeEnum.Ativo)
                                perf.PerfisDeAmigos.Add(_context.Perfis.Where(p => p.Id == am.IdPerfilSolicitante && am.Status == StatusAmizadeEnum.Ativo && (am.IdPerfilSolicitado != am.IdPerfilSolicitante)).First());
                        //_context.Entry(am).Reload();
                    }
                }
            }
            return perf;
        }


        public async Task<Perfil?> GetPerfilWithoutNavigation(Usuario usuario)
        {
            return await _context.Perfis.FirstOrDefaultAsync(p => p.Usuario.Id == (usuario.Id)); ;
        }

        public async Task<List<Perfil>> GetPerfisByName(string nome)
        {
            var lista = await _context.Perfis.Include("Amigos").Include("Usuario").Where(p => p.Nome.Contains(nome)).ToListAsync();
            
            foreach(var perfil in lista)
                perfil.Amigos = _context.Amigos.Include("PerfilSolicitante").Where(a => (a.IdPerfilSolicitado == perfil.Id || a.IdPerfilSolicitante == perfil.Id) && a.Status != StatusAmizadeEnum.Removido &&(a.IdPerfilSolicitado != a.IdPerfilSolicitante)).ToList();

            return lista;
        }
        public async Task<List<Perfil>> GetPerfisByFullName(string[] nome)
        {
            return await _context.Perfis.Include("Amigos").Include("Usuario").Where(p => p.Nome.Contains(nome[0]) && p.Sobrenome.Contains(nome[1])).ToListAsync();
        }

        public async Task<List<Perfil>> GetPerfisAmigosById(int Id)
        {
            var res = (from pf in _context.Perfis join am in _context.Amigos on pf.Id equals am.IdPerfilSolicitante where am.IdPerfilSolicitado == Id && am.IdPerfilSolicitado != am.IdPerfilSolicitante && am.Status == StatusAmizadeEnum.Ativo select pf).Include("Usuario").ToList();

            var res2 = (from pf in _context.Perfis join am in _context.Amigos on pf.Id equals am.IdPerfilSolicitado where am.IdPerfilSolicitante == Id && am.IdPerfilSolicitado != am.IdPerfilSolicitante && am.Status == StatusAmizadeEnum.Ativo select pf).Include("Usuario").ToList();

            foreach (var pf in res2)
                res.Add(pf);

            return res;
        }

        public async Task<int> SalvarFotoPerfil(FotoPerfil fp)
        {
            var amigos = fp.Perfil.Amigos.ToList();
            _context.Entry(fp.Perfil).Reload();
            foreach (var am in amigos)
                _context.Entry(am).Reload();
            _context.FotoPerfis.Add(fp);
            _context.SaveChanges();

            return fp.Id;
        }
    }
}

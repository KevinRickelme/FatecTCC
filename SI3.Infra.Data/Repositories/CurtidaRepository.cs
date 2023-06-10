﻿using Microsoft.EntityFrameworkCore;
using SI3.Domain.Entities;
using SI3.Domain.Interfaces;
using SI3.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI3.Infra.Data.Repositories
{
    public class CurtidaRepository : ICurtidaRepository
    {
        private readonly ApplicationContext _context;

        public CurtidaRepository(ApplicationContext context)
        {
            _context = context;
        }
        public int Add(Curtida curtida)
        {
            if (_context.Curtidas.Any(c => c.IdPerfil == curtida.IdPerfil && c.IdPublicacao == curtida.IdPublicacao))
            {
                Delete(_context.Curtidas.Where(c=>c.IdPublicacao == curtida.IdPublicacao && c.IdPerfil == curtida.IdPerfil).First());
                return -1;
            }
            else
            {
                _context.Curtidas.Add(curtida);
                return _context.SaveChanges();
            }
        }

        public int Delete(Curtida curtida)
        {
            _context.Curtidas.Remove(curtida);
            return _context.SaveChanges();
        }

        public int RemoveAll(int idPublicacao)
        {
            var curtidas = _context.Curtidas.Include("Perfil").Include(p => p.Perfil.Amigos).Where(c => c.IdPublicacao == idPublicacao).ToList();

            foreach (var list in curtidas)
            {
                _context.Entry(list.Perfil).Reload();
                foreach (var am in list.Perfil.Amigos)
                {
                    _context.Entry(am).Reload();
                }
            }
            _context.Curtidas.RemoveRange(curtidas);
            return _context.SaveChanges();
        }
    }
}
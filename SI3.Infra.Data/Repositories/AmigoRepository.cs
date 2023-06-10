using Microsoft.EntityFrameworkCore;
using SI3.Domain.Entities;
using SI3.Domain.Enums;
using SI3.Domain.Interfaces;
using SI3.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI3.Infra.Data.Repositories
{
    public class AmigoRepository : IAmigoRepository
    {
        private readonly ApplicationContext _context;
        public AmigoRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool EnviarSolicitacao(int IdPerfilSolicitante, int IdPerfilSolicitado)
        {
            Amigo PedidoAmizade = _context.Amigos.Where(a => (a.IdPerfilSolicitante == IdPerfilSolicitante && a.IdPerfilSolicitado == IdPerfilSolicitado) || (a.IdPerfilSolicitado == IdPerfilSolicitante && a.IdPerfilSolicitante == IdPerfilSolicitado)).FirstOrDefault();

            

            if (PedidoAmizade == null) {
                PedidoAmizade = new Amigo()
                {
                    IdPerfilSolicitante = IdPerfilSolicitante,
                    IdPerfilSolicitado = IdPerfilSolicitado,
                    Status = StatusAmizadeEnum.Pendente,
                    DataAmizade = DateTime.Now
                };
                _context.Amigos.Add(PedidoAmizade);
            }
            else {
                if(!(PedidoAmizade.IdPerfilSolicitante == IdPerfilSolicitante))
                    {
                    PedidoAmizade.IdPerfilSolicitante = IdPerfilSolicitante;
                    PedidoAmizade.IdPerfilSolicitado = IdPerfilSolicitado;
                    }
                PedidoAmizade.Status = StatusAmizadeEnum.Pendente;
                _context.Amigos.Update(PedidoAmizade);
            }
            return _context.SaveChanges() == 1 ? true : false;
        }

        public bool AceitarSolicitacao(int IdPerfilSolicitante, int IdPerfilSolicitado)
        {

            Amigo Amigos = _context.Amigos.Where(a => a.IdPerfilSolicitante == IdPerfilSolicitante && a.IdPerfilSolicitado == IdPerfilSolicitado).FirstOrDefault();
            Amigos.Status = StatusAmizadeEnum.Ativo;
            _context.Amigos.Update(Amigos);
            bool resultado = _context.SaveChangesAsync().Result == 1 ? true : false;
            _context.Entry(Amigos).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            return resultado;
        }
        public bool RecusarSolicitacao(int IdPerfilSolicitante, int IdPerfilSolicitado)
        {
            Amigo Amigos = _context.Amigos.Where(a => (a.IdPerfilSolicitante == IdPerfilSolicitante && a.IdPerfilSolicitado == IdPerfilSolicitado) || (a.IdPerfilSolicitado == IdPerfilSolicitante && a.IdPerfilSolicitante == IdPerfilSolicitado)).FirstOrDefault();
            Amigos.Status = StatusAmizadeEnum.Removido;
            _context.Amigos.Update(Amigos);
            return _context.SaveChanges() == 1 ? true : false;
        }
    }
}

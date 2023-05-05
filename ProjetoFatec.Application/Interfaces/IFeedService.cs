using ProjetoFatec.Application.ViewModels;
using ProjetoFatec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFatec.Application.Interfaces
{
    public interface IFeedService
    {
        bool Add(FeedViewModel Feed);
        Task<Feed> GetFeed(int IdPerfil);

        Task<FeedViewModel> GetFeedViewModel(int IdPerfil);

    }
}

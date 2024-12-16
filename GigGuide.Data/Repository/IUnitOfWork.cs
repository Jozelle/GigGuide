using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigGuide.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IVenueRepository Venues { get; }
        Task<int> Complete();
    }
}

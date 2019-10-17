using Staj.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staj.Repository
{
    public class PlayerRepository: BaseRepository<Players>
    {
        public PlayerRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}

using Staj.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staj.Repository
{
    public class PlayerSkillRepository : BaseRepository<PlayerSkills>
    {
        public PlayerSkillRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}

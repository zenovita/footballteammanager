using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj.Domain
{
    public class PlayerSkillRelationDomainModel
    {
        public PlayerDomainModel PlayerVM { get; set; }
        public PlayerSkillsDomainModel SkillVM { get; set; }
        public string teamName { get; set; }
    }
}
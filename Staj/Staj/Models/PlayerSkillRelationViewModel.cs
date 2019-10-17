using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj.Models
{
    public class PlayerSkillRelationViewModel
    {
        public PlayerViewModel PlayerVM { get; set; }
        public PlayerSkillViewModel SkillVM { get; set; }
        public string teamName { get; set; }
    }
}
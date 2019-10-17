using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj.Models
{
    public class PlayerSkillViewModel
    {
        public int id { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int pass { get; set; }
        public int spd { get; set; }
    }
}
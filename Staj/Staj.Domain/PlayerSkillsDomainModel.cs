using System;
using System.Collections.Generic;
using System.Text;

namespace Staj.Domain
{
    public class PlayerSkillsDomainModel
    {
        public int id { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int pass { get; set; }
        public int spd { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj.Models
{
    public class PlayerViewModel
    {
        public int playerId { get; set; }
        public int teamId { get; set; }
        public string playerName { get; set; }
        public string position { get; set; }
        public int skill { get; set; }
        public int isPlaying { get; set; }
    }
}
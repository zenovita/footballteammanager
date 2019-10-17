using System;
using System.Collections.Generic;
using System.Text;

namespace Staj.Domain
{
    public class PlayerDomainModel
    {
        public int playerId { get; set; }
        public int teamId { get; set; }
        public string playerName { get; set; }
        public string position { get; set; }
        public int skill { get; set; }
        public Nullable<bool> isPlaying { get; set; }

    }
}

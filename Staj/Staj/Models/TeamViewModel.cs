using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj.Models
{
    public class TeamViewModel
    {
        public int teamId { get; set; }
        public string teamName { get; set; }
        public Nullable<int> gamePlayed { get; set; }
        public Nullable<int> win { get; set; }
        public Nullable<int> lose { get; set; }
        public Nullable<int> draw { get; set; }
        public Nullable<int> goalAgainst { get; set; }
        public Nullable<int> goalDifference { get; set; }
        public Nullable<int> point { get; set; }
    }
}
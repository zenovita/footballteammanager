//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Staj.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlayerSkills
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlayerSkills()
        {
            this.Players = new HashSet<Players>();
        }
    
        public int id { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int pass { get; set; }
        public int spd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Players> Players { get; set; }
    }
}

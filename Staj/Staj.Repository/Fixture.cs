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
    
    public partial class Fixture
    {
        public int id { get; set; }
        public int teamId { get; set; }
        public string groups { get; set; }
    
        public virtual Teams Teams { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InterviewDb.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Language
    {
        public Language()
        {
            this.Players = new HashSet<Player>();
            this.Staffs = new HashSet<Staff>();
        }
    
        public int LanguageID { get; set; }
        public string RegionCode { get; set; }
        public string LanguageName { get; set; }
    
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}

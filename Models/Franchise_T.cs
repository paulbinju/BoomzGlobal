//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BoomzGlobal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Franchise_T
    {
        public Franchise_T()
        {
            this.Company_Package_T = new HashSet<Company_Package_T>();
            this.Package_T = new HashSet<Package_T>();
        }
    
        public int FranchiseID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<int> CityID { get; set; }
        public string FranchiseName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Website { get; set; }
        public string ContactPerson1 { get; set; }
        public string Mobile1 { get; set; }
        public string Email1 { get; set; }
        public string ContactPerson2 { get; set; }
        public string Mobile2 { get; set; }
        public string Email2 { get; set; }
        public Nullable<System.DateTime> DOC { get; set; }
    
        public virtual City_T City_T { get; set; }
        public virtual ICollection<Company_Package_T> Company_Package_T { get; set; }
        public virtual Country_T Country_T { get; set; }
        public virtual ICollection<Package_T> Package_T { get; set; }
    }
}

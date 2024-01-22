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
    
    public partial class Company_T
    {
        public Company_T()
        {
            this.Advertisement_T = new HashSet<Advertisement_T>();
            this.Company_Package_T = new HashSet<Company_Package_T>();
        }
    
        public int CompanyID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> SubCategoryID { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string Website { get; set; }
        public string Building { get; set; }
        public string Road { get; set; }
        public string Location { get; set; }
        public string ProductService { get; set; }
        public string Profile { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        public string Gplus { get; set; }
        public string Youtube { get; set; }
        public Nullable<System.DateTime> DOC { get; set; }
    
        public virtual ICollection<Advertisement_T> Advertisement_T { get; set; }
        public virtual Category_T Category_T { get; set; }
        public virtual City_T City_T { get; set; }
        public virtual Country_T Country_T { get; set; }
        public virtual SubCategory_T SubCategory_T { get; set; }
        public virtual ICollection<Company_Package_T> Company_Package_T { get; set; }
    }
}
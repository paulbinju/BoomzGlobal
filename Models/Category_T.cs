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
    
    public partial class Category_T
    {
        public Category_T()
        {
            this.Company_T = new HashSet<Company_T>();
            this.SubCategory_T = new HashSet<SubCategory_T>();
        }
    
        public int CategoryID { get; set; }
        public string Category { get; set; }
    
        public virtual ICollection<Company_T> Company_T { get; set; }
        public virtual ICollection<SubCategory_T> SubCategory_T { get; set; }
    }
}

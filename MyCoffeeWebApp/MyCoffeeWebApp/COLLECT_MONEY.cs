//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCoffeeWebApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class COLLECT_MONEY
    {
        public long CLMN_ID { get; set; }
        public System.DateTime DATE { get; set; }
        public int MN_ID { get; set; }
        public int CLMN_QUANLITY { get; set; }
        public long CLMN_PRICE { get; set; }
        public string CLMN_NOTE { get; set; }
    
        public virtual DATE DATE1 { get; set; }
        public virtual MENU MENU { get; set; }
    }
}

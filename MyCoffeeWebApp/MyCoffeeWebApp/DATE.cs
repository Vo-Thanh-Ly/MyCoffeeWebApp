﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations;

    public partial class DATE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DATE()
        {
            this.ALCOHOL_COLLECTS_MONEY = new HashSet<ALCOHOL_COLLECTS_MONEY>();
            this.ALCOHOL_SPENDING_MONEY = new HashSet<ALCOHOL_SPENDING_MONEY>();
            this.COLLECT_MONEY = new HashSet<COLLECT_MONEY>();
            this.SPENDING_MONEY = new HashSet<SPENDING_MONEY>();
        }

        [Required(ErrorMessage = "Ngày là bắt buộc")]
        [Display(Name = "Ngày")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime DATE_ID { get; set; }

        [Display(Name = "Gợi nhớ ngày")]
        [StringLength(150, ErrorMessage ="Độ dài tối đa là 150 ký tự")]
        public string date_name { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(1000, ErrorMessage = "Độ dài tối đa là 1000 ký tự")]
        public string note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALCOHOL_COLLECTS_MONEY> ALCOHOL_COLLECTS_MONEY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALCOHOL_SPENDING_MONEY> ALCOHOL_SPENDING_MONEY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COLLECT_MONEY> COLLECT_MONEY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPENDING_MONEY> SPENDING_MONEY { get; set; }
    }
}

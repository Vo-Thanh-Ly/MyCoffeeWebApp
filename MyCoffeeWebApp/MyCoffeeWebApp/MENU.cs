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

    public partial class MENU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MENU()
        {
            this.COLLECT_MONEY = new HashSet<COLLECT_MONEY>();
        }

       
        [Display(Name = "ID Menu")]
        public int MN_ID { get; set; }

        [Required(ErrorMessage = "Trường {0} là bắt buộc.")]
        [Display(Name = "Tên sản phẩm")]
        [StringLength(100, ErrorMessage = "Trường {0} không được vượt quá {1} ký tự.")]
        public string MN_PRODUCTNAME { get; set; }

        [Required(ErrorMessage = "Trường {0} là bắt buộc.")]
        [Display(Name = "Giá sản phẩm")]
        [Range(0, long.MaxValue, ErrorMessage = "Trường {0} phải là một số không âm.")]
        public Nullable<long> MN_PRICE { get; set; }

    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COLLECT_MONEY> COLLECT_MONEY { get; set; }
    }
}

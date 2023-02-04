namespace photographers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        public int IDuser { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name ="User Name")]        
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Password")]
        public string Pass { get; set; }

        [StringLength(50)]
        [DefaultValue("photographer")]

        public string Roles { get; set; }
    }
}

namespace photographers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public location()
        {
            reservations = new HashSet<reservation>();
        }

        [Key]
        public int IDlocation { get; set; }

        [Column("location")]
        [Required]
        [StringLength(100)]
        [Display (Name = "Location")]
        public string location1 { get; set; }

        public string locationURL { get; set; }
        [Display (Name = "Describtion")]
        public string Describtion { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservation> reservations { get; set; }
    }
}

namespace photographers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("reservation")]
    public partial class reservation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reservation()
        {
            detailReservations = new HashSet<detailReservation>();
        }

        [Key]
        public int IDreservation { get; set; }

        public DateTime reservationtime { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateRequest { get; set; }

        public int IDlocation { get; set; }

        public int IDslot { get; set; }

        [Required]
        [StringLength(30)]
        public string customerTel { get; set; }

        [Required]
        [StringLength(300)]
        public string customerEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detailReservation> detailReservations { get; set; }

        public virtual location location { get; set; }

        public virtual Slot Slot { get; set; }
    }
}

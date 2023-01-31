namespace photographers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Photographer")]
    public partial class Photographer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Photographer()
        {
            detailReservations = new HashSet<detailReservation>();
        }

        [Key]
        public int IDphotographer { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(70)]
        public string LastName { get; set; }

        [StringLength(300)]
        public string website { get; set; }

        public string instagram { get; set; }

        public string profileImgURL { get; set; }

        [Required]
        [StringLength(30)]
        public string tel { get; set; }

        [Required]
        [StringLength(300)]
        public string email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? experienceThan { get; set; }

        public int? IDportafolio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detailReservation> detailReservations { get; set; }

        public virtual portfolio portfolio { get; set; }
    }
}

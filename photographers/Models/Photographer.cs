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
        [Display (Name = "First Name:")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(70)]
        [Display (Name = "Last Name:")]
        public string LastName { get; set; }

        [StringLength(300)]
        [Display (Name = "Personal Site:")]
        public string website { get; set; }

        [Display (Name = "Instagram page:")]
        public string instagram { get; set; }

        [Display (Name = "Profile Picture:")]
        public string profileImgURL { get; set; }

        [Required]
        [StringLength(30)]

        [Display (Name = "Contact number:")]
        public string tel { get; set; }

        [Required]
        [StringLength(300)]
        [Display (Name = "Email:")]
        public string email { get; set; }

        [Column(TypeName = "date")]
        [Display (Name = "Photography experience start than:")]
        public DateTime? experienceThan { get; set; }

        public int? IDportafolio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detailReservation> detailReservations { get; set; }

        public virtual portfolio portfolio { get; set; }
    }
}

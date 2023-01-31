namespace photographers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class portfolio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public portfolio()
        {
            Photographers = new HashSet<Photographer>();
        }

        [Key]
        public int IDportfoglio { get; set; }

        [Required]
        public string aboutme { get; set; }

        public string coverIMG { get; set; }

        public string img1 { get; set; }

        public string img2 { get; set; }

        public string img3 { get; set; }

        public string img4 { get; set; }

        public string img5 { get; set; }

        public string img6 { get; set; }

        public string img7 { get; set; }

        public string img8 { get; set; }

        public string img9 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photographer> Photographers { get; set; }
    }
}

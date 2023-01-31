namespace photographers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("detailReservation")]
    public partial class detailReservation
    {
        [Key]
        public int IDdetail { get; set; }

        public int IDphotographer { get; set; }

        public int IDreservation { get; set; }

        public virtual Photographer Photographer { get; set; }

        public virtual reservation reservation { get; set; }
    }
}

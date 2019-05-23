namespace MusicMall.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_pay
    {
        public int id { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        [Required]
        [StringLength(50)]
        public string type { get; set; }

        public DateTime payTime { get; set; }

        public DateTime createTime { get; set; }

        public bool isPay { get; set; }

        public bool status { get; set; }
    }
}

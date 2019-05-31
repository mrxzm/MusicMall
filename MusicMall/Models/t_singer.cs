namespace MusicMall.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_singer
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string stageName { get; set; }

        [StringLength(50)]
        public string img { get; set; }

        public int? sex { get; set; }

        [StringLength(50)]
        public string nationality { get; set; }

        [StringLength(50)]
        public string ntion { get; set; }

        [StringLength(50)]
        public string constellation { get; set; }

        [StringLength(50)]
        public string bloodType { get; set; }

        [StringLength(50)]
        public string height { get; set; }

        public DateTime? birthday { get; set; }

        public string occupation { get; set; }

        public string broker { get; set; }

        public string representativeWork { get; set; }

        public string achievement { get; set; }

        public DateTime updateTime { get; set; }

        public bool status { get; set; }
    }
}

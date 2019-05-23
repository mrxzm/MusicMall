namespace MusicMall.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_config
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string variable { get; set; }

        [Required]
        [StringLength(50)]
        public string value { get; set; }

        public DateTime updateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string updateUserName { get; set; }

        public bool status { get; set; }
    }
}

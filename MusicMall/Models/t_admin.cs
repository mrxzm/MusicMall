namespace MusicMall.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_admin
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string phone { get; set; }

        public int loginCount { get; set; }

        public DateTime loginTime { get; set; }

        [StringLength(50)]
        public string loginIp { get; set; }

        public DateTime createTime { get; set; }

        public DateTime updateTime { get; set; }

        public bool status { get; set; }
    }
}

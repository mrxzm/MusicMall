namespace MusicMall.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_order
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string orderno { get; set; }

        public int userId { get; set; }

        [Required]
        [StringLength(50)]
        public string userName { get; set; }

        [Required]
        [StringLength(50)]
        public string userPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string country { get; set; }

        [Required]
        [StringLength(50)]
        public string province { get; set; }

        [Required]
        [StringLength(50)]
        public string city { get; set; }

        [Required]
        [StringLength(50)]
        public string area { get; set; }

        [Required]
        public string address { get; set; }

        public int musicId { get; set; }

        [Required]
        public string musicImg { get; set; }

        [Required]
        public string musicName { get; set; }

        [Required]
        public string musicFiles { get; set; }

        public int? musicUserId { get; set; }

        [StringLength(50)]
        public string musicUserName { get; set; }

        [Column(TypeName = "money")]
        public decimal total { get; set; }

        public DateTime createTime { get; set; }

        public DateTime? deliveryTime { get; set; }

        public DateTime updateTime { get; set; }

        public DateTime? payTime { get; set; }

        public bool isPay { get; set; }

        public bool isDelivery { get; set; }

        public bool status { get; set; }
    }
}

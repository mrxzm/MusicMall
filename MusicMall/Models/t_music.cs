namespace MusicMall.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_music
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public string album { get; set; }

        public string lyrics { get; set; }

        public string compose { get; set; }

        public string arranger { get; set; }

        public string singer { get; set; }

        public string summationTone { get; set; }

        public string musicalInstruments { get; set; }

        public DateTime? IssueDate { get; set; }

        public string language { get; set; }

        public TimeSpan? duration { get; set; }

        public string explain { get; set; }

        public string img { get; set; }

        [Required]
        public string files { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        public DateTime createTime { get; set; }

        public DateTime updateTime { get; set; }

        public bool status { get; set; }
    }
}

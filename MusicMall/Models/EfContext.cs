namespace MusicMall.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EfContext : DbContext
    {
        public EfContext()
            : base("name=EfContext")
        {
        }

        public virtual DbSet<t_admin> t_admin { get; set; }
        public virtual DbSet<t_config> t_config { get; set; }
        public virtual DbSet<t_music> t_music { get; set; }
        public virtual DbSet<t_order> t_order { get; set; }
        public virtual DbSet<t_pay> t_pay { get; set; }
        public virtual DbSet<t_singer> t_singer { get; set; }
        public virtual DbSet<t_user> t_user { get; set; }
        public virtual DbSet<t_user_address> t_user_address { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<t_order>()
                .Property(e => e.total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<t_pay>()
                .Property(e => e.price)
                .HasPrecision(19, 4);
        }
    }
}

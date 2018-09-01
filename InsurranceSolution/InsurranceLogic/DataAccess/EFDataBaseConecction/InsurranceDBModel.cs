namespace InsurranceLogic.EFDataBaseConecction
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InsurranceDBModel : DbContext
    {
        public InsurranceDBModel()
            : base("name=InsurranceDBModelCS")
        {
        }

        public virtual DbSet<Insurrance> Insurrances { get; set; }
        public virtual DbSet<TiposCubrimiento> TiposCubrimientos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Insurrance>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Insurrance>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Insurrance>()
                .Property(e => e.precioPoliza)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TiposCubrimiento>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TiposCubrimiento>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TiposCubrimiento>()
                .HasMany(e => e.Insurrances)
                .WithRequired(e => e.TiposCubrimiento)
                .HasForeignKey(e => e.idTipoCubrimiento)
                .WillCascadeOnDelete(false);
        }
    }
}

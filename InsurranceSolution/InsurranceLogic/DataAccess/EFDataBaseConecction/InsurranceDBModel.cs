namespace InsurranceLogic.EFDataBaseConecction
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using InsurranceLogic.DataAccess.EFDataBaseConecction;

    public partial class InsurranceDBModel : DbContext
    {
        public InsurranceDBModel()
            : base("name=InsurranceDBModelCS")
        {
            Database.SetInitializer<InsurranceDBModel>(new InsurranceDBModelSeeder());
        }

        public virtual DbSet<Insurrance> Insurrances { get; set; }
        public virtual DbSet<TiposCubrimiento> TiposCubrimientos { get; set; }
        public virtual DbSet<Permiso> permisos { get; set; }
        public virtual DbSet<Perfil> perfiles { get; set; }
        public virtual DbSet<Usuario> usuarios { get; set; }

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

            modelBuilder.Entity<Perfil>()
                .HasMany(e => e.usuarios)
                .WithRequired(e => e.perfil)
                .HasForeignKey(e => e.idPerfil)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Perfil>()
                .HasMany(e => e.permisos)
                .WithMany(e => e.perfiles);
            
        }
    }
}

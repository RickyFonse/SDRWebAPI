namespace SDRDAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SDRDbContext : DbContext
    {
        public SDRDbContext()
            : base("name=SDRDbContext")
        {
            // Do NOT enable proxied entities, else serialization fails
            Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)--eager loading
            Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            Configuration.ValidateOnSaveEnabled = false;

            //this is just to see the sql entityframework is generating..comment out when going to "production"
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<FileType> FileTypes { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyPic> PropertyPics { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Property>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.Property)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Property>()
                .HasMany(e => e.PropertyPics)
                .WithRequired(e => e.Property)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.occupied)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.fips_state)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.assoc_press)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.standard_federal_region)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.census_region)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.census_region_name)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.census_division)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.census_division_name)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.circuit_court)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.State)
                .WillCascadeOnDelete(false);
        }
    }
}

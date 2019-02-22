
namespace KaliteGiris.EfDal
{
    using Entities;

    using System.Data.Entity;

    public partial class LabDataModel : DbContext
    {
        public LabDataModel()
            :base("name=LabDataModel")
        {
        }

        public virtual DbSet<Firma> Firma { get; set; }
        public virtual DbSet<LabTalep> LabTalep { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<Durum> Durum { get; set; }

        public virtual DbSet<DurumTipi> DurumTipi { get; set; }
        public virtual DbSet<AlimTipi> AlimTipi { get; set; }

        public virtual DbSet<NavigationMenu> NavigationMenu { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<NavigationMenuRole> NavigationMenuRole { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<LabDataModel>(null); // The model backing the <VeriTabanı> context has changed since the database was created. Bu Hatada Entitiy Sınıflarını Güncellemediğinden Olabilir
            //base.OnModelCreating(modelBuilder); // Hatası İçin Kullanılan Kod Satırları. Migrationslarda Bir Hata Yoksa Gerek Yok.

            modelBuilder.Entity<LabTalep>()
               .HasRequired(s => s.SonucDurum)
               .WithMany()
               .WillCascadeOnDelete(false);
        }
    }
}

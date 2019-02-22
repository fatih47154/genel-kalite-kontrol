namespace KaliteGiris.EfDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlimTipi",
                c => new
                    {
                        AlimTipiId = c.Guid(nullable: false, identity: true),
                        AlimTipiAdi = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(),
                        UpdatededDate = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.AlimTipiId);

            CreateTable(
               "dbo.DurumTipis",
               c => new
               {
                   DurumTipiId = c.Guid(nullable: false, identity: true),
                   DurumTip = c.String(maxLength: 100),
                   CreatedDate = c.DateTime(),
                   UpdatededDate = c.DateTime(),
                   IsActive = c.Boolean(),
               })
               .PrimaryKey(t => t.DurumTipiId);

            CreateTable(
                "dbo.Durum",
                c => new
                {
                    DurumId = c.Guid(nullable: false, identity: true),
                    DurumAdi = c.String(maxLength: 100),
                    DurumTipiId = c.Guid(nullable: false),
                    CreatedDate = c.DateTime(),
                    UpdatededDate = c.DateTime(),
                    IsActive = c.Boolean(),
                })
                .PrimaryKey(t => t.DurumId)
                .ForeignKey("dbo.DurumTipis", t => t.DurumTipiId, cascadeDelete: true)
                .Index(t => t.DurumTipiId);


            CreateTable(
                "dbo.Firma",
                c => new
                {
                    FirmaId = c.Guid(nullable: false, identity: true),
                    FirmaAdi = c.String(maxLength: 100),
                    CreatedDate = c.DateTime(),
                    UpdatededDate = c.DateTime(),
                    IsActive = c.Boolean(),
                })
                .PrimaryKey(t => t.FirmaId);

            CreateTable(
                "dbo.Role",
                c => new
                {
                    RolId = c.Guid(nullable: false, identity: true),
                    RolName = c.String(nullable: false, maxLength: 30),
                    CreatedDate = c.DateTime(),
                    UpdatededDate = c.DateTime(),
                    IsActive = c.Boolean(),
                })
                .PrimaryKey(t => t.RolId);

            CreateTable(
                "dbo.Personel",
                c => new
                {
                    PersonelId = c.Guid(nullable: false, identity: true),
                    PersonelNo = c.Int(nullable: false),
                    SicilNo = c.Int(nullable: false),
                    Adi = c.String(),
                    Soyadi = c.String(),
                    Tc = c.String(maxLength: 11),
                    Kullanici = c.String(),
                    Sifre = c.String(),
                    Email = c.String(),
                    Durum = c.Boolean(nullable: false),
                    RolId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.PersonelId)
                .ForeignKey("dbo.Role", t => t.RolId, cascadeDelete: true)
                .Index(t => t.RolId);

            CreateTable(
                "dbo.LabTalep",
                c => new
                    {
                        LabTalepId = c.Guid(nullable: false, identity: true),
                        Sira = c.Int(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        RaporTarihi = c.DateTime(nullable: false),
                        FirmaId = c.Guid(nullable: false),
                        SozlesmeNo = c.String(),
                        AlimTipiId = c.Guid(nullable: false),
                        Malzeme = c.String(),
                        IrsaliyeNo = c.String(),
                        PersonelId = c.Guid(nullable: false),
                        DurumId = c.Guid(nullable: false),
                        SonucDurumId = c.Guid(nullable: false),
                        GKKSonucId = c.Guid(nullable: false),
                        Aciklama = c.String(),
                        CreatedDate = c.DateTime(),
                        UpdatededDate = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.LabTalepId)
                .ForeignKey("dbo.AlimTipi", t => t.AlimTipiId, cascadeDelete: true)
                .ForeignKey("dbo.Durum", t => t.DurumId, cascadeDelete: true)
                .ForeignKey("dbo.Firma", t => t.FirmaId, cascadeDelete: true)
                .ForeignKey("dbo.Durum", t => t.GKKSonucId, cascadeDelete: true)
                .ForeignKey("dbo.Personel", t => t.PersonelId, cascadeDelete: true)
                .ForeignKey("dbo.Durum", t => t.SonucDurumId)
                .Index(t => t.FirmaId)
                .Index(t => t.AlimTipiId)
                .Index(t => t.PersonelId)
                .Index(t => t.DurumId)
                .Index(t => t.SonucDurumId)
                .Index(t => t.GKKSonucId);                   
            
            CreateTable(
                "dbo.NavigationMenus",
                c => new
                    {
                        MenuId = c.Guid(nullable: false, identity: true),
                        MenuName = c.String(nullable: false, maxLength: 30),
                        MenuLink = c.String(nullable: false, maxLength: 30),
                        MenuSira = c.Int(nullable: false),
                        IconName = c.String(maxLength: 50),
                        ParentMenuId = c.Guid(),
                        Controler = c.String(maxLength: 30),
                        Action = c.String(maxLength: 30),
                        QuickAccessIcon = c.String(maxLength: 50),
                        QuickAccess = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatededDate = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.MenuId)
                .ForeignKey("dbo.NavigationMenus", t => t.ParentMenuId)
                .Index(t => t.ParentMenuId);
            
            CreateTable(
                "dbo.NavigationMenuRoles",
                c => new
                    {
                        MenuRolId = c.Guid(nullable: false, identity: true),
                        MenuId = c.Guid(nullable: false),
                        RolId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatededDate = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.MenuRolId)
                .ForeignKey("dbo.NavigationMenus", t => t.MenuId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RolId, cascadeDelete: true)
                .Index(t => t.MenuId)
                .Index(t => t.RolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NavigationMenuRoles", "RolId", "dbo.Role");
            DropForeignKey("dbo.NavigationMenuRoles", "MenuId", "dbo.NavigationMenus");
            DropForeignKey("dbo.NavigationMenus", "ParentMenuId", "dbo.NavigationMenus");
            DropForeignKey("dbo.LabTalep", "SonucDurumId", "dbo.Durum");
            DropForeignKey("dbo.LabTalep", "PersonelId", "dbo.Personel");
            DropForeignKey("dbo.Personel", "RolId", "dbo.Role");
            DropForeignKey("dbo.LabTalep", "GKKSonucId", "dbo.Durum");
            DropForeignKey("dbo.LabTalep", "FirmaId", "dbo.Firma");
            DropForeignKey("dbo.LabTalep", "DurumId", "dbo.Durum");
            DropForeignKey("dbo.Durum", "DurumTipiId", "dbo.DurumTipis");
            DropForeignKey("dbo.LabTalep", "AlimTipiId", "dbo.AlimTipi");
            DropIndex("dbo.NavigationMenuRoles", new[] { "RolId" });
            DropIndex("dbo.NavigationMenuRoles", new[] { "MenuId" });
            DropIndex("dbo.NavigationMenus", new[] { "ParentMenuId" });
            DropIndex("dbo.Personel", new[] { "RolId" });
            DropIndex("dbo.Durum", new[] { "DurumTipiId" });
            DropIndex("dbo.LabTalep", new[] { "GKKSonucId" });
            DropIndex("dbo.LabTalep", new[] { "SonucDurumId" });
            DropIndex("dbo.LabTalep", new[] { "DurumId" });
            DropIndex("dbo.LabTalep", new[] { "PersonelId" });
            DropIndex("dbo.LabTalep", new[] { "AlimTipiId" });
            DropIndex("dbo.LabTalep", new[] { "FirmaId" });
            DropTable("dbo.NavigationMenuRoles");
            DropTable("dbo.NavigationMenus");
            DropTable("dbo.Role");
            DropTable("dbo.Personel");
            DropTable("dbo.Firma");
            DropTable("dbo.DurumTipis");
            DropTable("dbo.Durum");
            DropTable("dbo.LabTalep");
            DropTable("dbo.AlimTipi");
        }
    }
}

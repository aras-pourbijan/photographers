namespace photographers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.detailReservation",
                c => new
                    {
                        IDdetail = c.Int(nullable: false, identity: true),
                        IDphotographer = c.Int(nullable: false),
                        IDreservation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDdetail)
                .ForeignKey("dbo.Photographer", t => t.IDphotographer)
                .ForeignKey("dbo.reservation", t => t.IDreservation)
                .Index(t => t.IDphotographer)
                .Index(t => t.IDreservation);
            
            CreateTable(
                "dbo.Photographer",
                c => new
                    {
                        IDphotographer = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 70),
                        website = c.String(maxLength: 300),
                        instagram = c.String(),
                        profileImgURL = c.String(),
                        tel = c.String(nullable: false, maxLength: 30, unicode: false),
                        email = c.String(nullable: false, maxLength: 300),
                        experienceThan = c.DateTime(storeType: "date"),
                        IDportafolio = c.Int(),
                    })
                .PrimaryKey(t => t.IDphotographer)
                .ForeignKey("dbo.portfolios", t => t.IDportafolio)
                .Index(t => t.IDportafolio);
            
            CreateTable(
                "dbo.portfolios",
                c => new
                    {
                        IDportfoglio = c.Int(nullable: false, identity: true),
                        aboutme = c.String(nullable: false),
                        coverIMG = c.String(),
                        img1 = c.String(),
                        img2 = c.String(),
                        img3 = c.String(),
                        img4 = c.String(),
                        img5 = c.String(),
                        img6 = c.String(),
                        img7 = c.String(),
                        img8 = c.String(),
                        img9 = c.String(),
                    })
                .PrimaryKey(t => t.IDportfoglio);
            
            CreateTable(
                "dbo.reservation",
                c => new
                    {
                        IDreservation = c.Int(nullable: false, identity: true),
                        reservationtime = c.DateTime(nullable: false),
                        DateRequest = c.DateTime(nullable: false, storeType: "date"),
                        IDlocation = c.Int(nullable: false),
                        IDslot = c.Int(nullable: false),
                        customerTel = c.String(nullable: false, maxLength: 30, unicode: false),
                        customerEmail = c.String(nullable: false, maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.IDreservation)
                .ForeignKey("dbo.locations", t => t.IDlocation)
                .ForeignKey("dbo.Slot", t => t.IDslot)
                .Index(t => t.IDlocation)
                .Index(t => t.IDslot);
            
            CreateTable(
                "dbo.locations",
                c => new
                    {
                        IDlocation = c.Int(nullable: false, identity: true),
                        location = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IDlocation);
            
            CreateTable(
                "dbo.Slot",
                c => new
                    {
                        IDslot = c.Int(nullable: false, identity: true),
                        timeslot = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IDslot);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IDuser = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Pass = c.String(nullable: false, maxLength: 50),
                        Roles = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IDuser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.reservation", "IDslot", "dbo.Slot");
            DropForeignKey("dbo.reservation", "IDlocation", "dbo.locations");
            DropForeignKey("dbo.detailReservation", "IDreservation", "dbo.reservation");
            DropForeignKey("dbo.Photographer", "IDportafolio", "dbo.portfolios");
            DropForeignKey("dbo.detailReservation", "IDphotographer", "dbo.Photographer");
            DropIndex("dbo.reservation", new[] { "IDslot" });
            DropIndex("dbo.reservation", new[] { "IDlocation" });
            DropIndex("dbo.Photographer", new[] { "IDportafolio" });
            DropIndex("dbo.detailReservation", new[] { "IDreservation" });
            DropIndex("dbo.detailReservation", new[] { "IDphotographer" });
            DropTable("dbo.Users");
            DropTable("dbo.Slot");
            DropTable("dbo.locations");
            DropTable("dbo.reservation");
            DropTable("dbo.portfolios");
            DropTable("dbo.Photographer");
            DropTable("dbo.detailReservation");
        }
    }
}

namespace FFLiebeslied.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        idAuthor = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        MainGenre = c.String(),
                        AuthorImage = c.Binary(),
                    })
                .PrimaryKey(t => t.idAuthor);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        idMember = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Role = c.String(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                        MemberImage = c.Binary(),
                        Group_idAuthor = c.Int(),
                    })
                .PrimaryKey(t => t.idMember)
                .ForeignKey("dbo.Authors", t => t.Group_idAuthor)
                .Index(t => t.Group_idAuthor);
            
            CreateTable(
                "dbo.Discs",
                c => new
                    {
                        idDisc = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        DiscImage = c.Binary(),
                    })
                .PrimaryKey(t => t.idDisc);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        idSong = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Disc = c.String(),
                        Genre = c.String(),
                        Price = c.Double(nullable: false),
                        Year = c.Int(nullable: false),
                        Lyrics = c.String(),
                        Author_idAuthor = c.Int(),
                        Disc_idDisc = c.Int(),
                    })
                .PrimaryKey(t => t.idSong)
                .ForeignKey("dbo.Authors", t => t.Author_idAuthor)
                .ForeignKey("dbo.Discs", t => t.Disc_idDisc)
                .Index(t => t.Author_idAuthor)
                .Index(t => t.Disc_idDisc);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderDate = c.DateTime(nullable: false),
                        Adress = c.String(),
                        CP = c.Int(nullable: false),
                        City = c.String(),
                        Province = c.String(),
                        Country = c.String(),
                        Disc_idDisc = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDate)
                .ForeignKey("dbo.Discs", t => t.Disc_idDisc)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.Disc_idDisc)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Disc_idDisc = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Discs", t => t.Disc_idDisc)
                .Index(t => t.Disc_idDisc);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "Disc_idDisc", "dbo.Discs");
            DropForeignKey("dbo.Orders", "Disc_idDisc", "dbo.Discs");
            DropForeignKey("dbo.Songs", "Disc_idDisc", "dbo.Discs");
            DropForeignKey("dbo.Songs", "Author_idAuthor", "dbo.Authors");
            DropForeignKey("dbo.Members", "Group_idAuthor", "dbo.Authors");
            DropIndex("dbo.Users", new[] { "Disc_idDisc" });
            DropIndex("dbo.Orders", new[] { "User_UserID" });
            DropIndex("dbo.Orders", new[] { "Disc_idDisc" });
            DropIndex("dbo.Songs", new[] { "Disc_idDisc" });
            DropIndex("dbo.Songs", new[] { "Author_idAuthor" });
            DropIndex("dbo.Members", new[] { "Group_idAuthor" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Songs");
            DropTable("dbo.Discs");
            DropTable("dbo.Members");
            DropTable("dbo.Authors");
        }
    }
}

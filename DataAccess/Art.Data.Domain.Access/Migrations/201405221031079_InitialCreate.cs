namespace Art.Data.Domain.Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Birthday = c.DateTime(),
                        Deathday = c.DateTime(),
                        School = c.String(maxLength: 30),
                        IsPublic = c.Boolean(nullable: false),
                        AvatarFileName = c.String(maxLength: 50),
                        Masterpiece = c.String(maxLength: 30),
                        MasterpieceTypeId = c.Int(nullable: false),
                        PrizeItems = c.String(maxLength: 30),
                        Gender = c.Int(nullable: false),
                        Degree = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArtworkType", t => t.MasterpieceTypeId, cascadeDelete: true)
                .Index(t => t.MasterpieceTypeId);
            
            CreateTable(
                "dbo.ArtistType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Artwork",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityNumber = c.Int(nullable: false),
                        Name = c.String(),
                        Institution = c.String(),
                        Size = c.String(),
                        AuctionType = c.Int(nullable: false),
                        AuctionPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDateTime = c.DateTime(),
                        EndDateTime = c.DateTime(),
                        ArtYear = c.Int(nullable: false),
                        CreationInspiration = c.String(),
                        ImageFileName = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                        FeePackageGeneral = c.Decimal(precision: 18, scale: 2),
                        FeePackageFine = c.Decimal(precision: 18, scale: 2),
                        FeeDeliveryLocal = c.Decimal(precision: 18, scale: 2),
                        FeeDeliveryNonlocal = c.Decimal(precision: 18, scale: 2),
                        AtTopDatetime = c.DateTime(),
                        DefaultCommentId = c.Int(),
                        FADateTime = c.DateTime(nullable: false),
                        FAUserName = c.String(),
                        LCDateTime = c.DateTime(),
                        LCUserName = c.String(),
                        Artist_Id = c.Int(nullable: false),
                        ArtShape_Id = c.Int(),
                        ArtTechnique_Id = c.Int(),
                        ArtMaterial_Id = c.Int(nullable: false),
                        ArtworkType_Id = c.Int(nullable: false),
                        Genre_Id = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artist", t => t.Artist_Id, cascadeDelete: true)
                .ForeignKey("dbo.ArtShape", t => t.ArtShape_Id)
                .ForeignKey("dbo.ArtTechnique", t => t.ArtTechnique_Id)
                .ForeignKey("dbo.ArtMaterial", t => t.ArtMaterial_Id, cascadeDelete: true)
                .ForeignKey("dbo.ArtworkType", t => t.ArtworkType_Id)
                .ForeignKey("dbo.Comment", t => t.DefaultCommentId)
                .ForeignKey("dbo.Genre", t => t.Genre_Id)
                .Index(t => t.DefaultCommentId)
                .Index(t => t.Artist_Id)
                .Index(t => t.ArtShape_Id)
                .Index(t => t.ArtTechnique_Id)
                .Index(t => t.ArtMaterial_Id)
                .Index(t => t.ArtworkType_Id)
                .Index(t => t.Genre_Id);
            
            CreateTable(
                "dbo.ArtMaterial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 70),
                        ArtworkType_Id = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArtworkType", t => t.ArtworkType_Id)
                .Index(t => t.ArtworkType_Id);
            
            CreateTable(
                "dbo.ArtworkType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArtShape",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ArtworkType_Id = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArtworkType", t => t.ArtworkType_Id)
                .Index(t => t.ArtworkType_Id);
            
            CreateTable(
                "dbo.ArtTechnique",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ArtworkType_Id = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArtworkType", t => t.ArtworkType_Id)
                .Index(t => t.ArtworkType_Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        State = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                        CreativeIndex = c.Single(),
                        ArtisticIndex = c.Single(),
                        ObjectiveIndex = c.Single(),
                        ArtworkId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        FADateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Artwork", t => t.ArtworkId, cascadeDelete: true)
                .Index(t => t.ArtworkId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NickName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        DeviceType = c.Int(nullable: false),
                        AvatarPath = c.String(),
                        DefaultAddressId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.DefaultAddressId)
                .Index(t => t.DefaultAddressId);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Telephone = c.String(),
                        Detail = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArtworkImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageType = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        ImagePath = c.String(),
                        Artwork_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artwork", t => t.Artwork_Id)
                .Index(t => t.Artwork_Id);
            
            CreateTable(
                "dbo.ActivityPraise",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ArtworkId = c.Int(nullable: false),
                        FADatetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artwork", t => t.ArtworkId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ArtworkId);
            
            CreateTable(
                "dbo.ArtPlace",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArtistImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageType = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        ImagePath = c.String(),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artist", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
            CreateTable(
                "dbo.AuctionBill",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArtworkId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        OriginalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BidPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustumerMessage = c.String(),
                        BidDateTime = c.DateTime(nullable: false),
                        AuctionResult = c.Int(nullable: false),
                        AuctionType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artwork", t => t.ArtworkId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.ArtworkId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.ActivityCollect",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ArtworkId = c.Int(nullable: false),
                        FADatetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artwork", t => t.ArtworkId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ArtworkId);
            
            CreateTable(
                "dbo.ActivityShare",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ArtworkId = c.Int(nullable: false),
                        FADatetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artwork", t => t.ArtworkId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ArtworkId);
            
            CreateTable(
                "dbo.ActivityFollow",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                        FADatetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artist", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.AdminUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LoginName = c.String(maxLength: 30),
                        Password = c.String(),
                        Position = c.String(),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExceptionLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppName = c.String(maxLength: 303),
                        StackTrace = c.String(),
                        Message = c.String(),
                        FAUserName = c.String(),
                        FADateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OperationLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UserName = c.String(),
                        ActionName = c.String(),
                        FriendlyActionName = c.String(),
                        ExceptionInfo = c.String(),
                        ExceptionHandled = c.Boolean(nullable: false),
                        FADateTime = c.DateTime(nullable: false),
                        Test2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        OrderNumber = c.String(),
                        CustomerId = c.Int(nullable: false),
                        ArtworkId = c.Int(nullable: false),
                        AuctionType = c.Int(nullable: false),
                        PayType = c.Int(nullable: false),
                        PackingType = c.Int(nullable: false),
                        DeliveryType = c.Int(nullable: false),
                        InvoiceType = c.Int(nullable: false),
                        InvoiceCompanyName = c.String(),
                        ReceiptAddressId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FeePackage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FeeDelivery = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                        FADateTime = c.DateTime(nullable: false),
                        RefuseMessage = c.String(),
                        RefundMessage = c.String(),
                        DeliveryCompany = c.String(),
                        DeliveryNumber = c.String(),
                        PayStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artwork", t => t.ArtworkId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Address", t => t.ReceiptAddressId)
                .Index(t => t.CustomerId)
                .Index(t => t.ArtworkId)
                .Index(t => t.ReceiptAddressId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        FADateTime = c.DateTime(nullable: false),
                        Comment_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comment", t => t.Comment_Id)
                .ForeignKey("dbo.AdminUser", t => t.User_Id)
                .Index(t => t.Comment_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.SystemNotice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 400),
                        Content = c.String(),
                        IsSuccessful = c.Boolean(nullable: false),
                        AdminUserId = c.Int(nullable: false),
                        FADateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminUser", t => t.AdminUserId, cascadeDelete: true)
                .Index(t => t.AdminUserId);
            
            CreateTable(
                "dbo.ShoppingCartItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArtworkId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FADateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artwork", t => t.ArtworkId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.ArtworkId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.ArtistArtistType",
                c => new
                    {
                        ArtistId = c.Int(nullable: false),
                        ArtistTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArtistId, t.ArtistTypeId })
                .ForeignKey("dbo.Artist", t => t.ArtistId)
                .ForeignKey("dbo.ArtistType", t => t.ArtistTypeId)
                .Index(t => t.ArtistId)
                .Index(t => t.ArtistTypeId);
            
            CreateTable(
                "dbo.ArtworkArtPlace",
                c => new
                    {
                        ArtworkId = c.Int(nullable: false),
                        ArtPlaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArtworkId, t.ArtPlaceId })
                .ForeignKey("dbo.Artwork", t => t.ArtworkId)
                .ForeignKey("dbo.ArtPlace", t => t.ArtPlaceId)
                .Index(t => t.ArtworkId)
                .Index(t => t.ArtPlaceId);
            
            CreateTable(
                "dbo.ArtistGenre",
                c => new
                    {
                        ArtistId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArtistId, t.GenreId })
                .ForeignKey("dbo.Artist", t => t.ArtistId)
                .ForeignKey("dbo.Genre", t => t.GenreId)
                .Index(t => t.ArtistId)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCartItem", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ShoppingCartItem", "ArtworkId", "dbo.Artwork");
            DropForeignKey("dbo.SystemNotice", "AdminUserId", "dbo.AdminUser");
            DropForeignKey("dbo.Reply", "User_Id", "dbo.AdminUser");
            DropForeignKey("dbo.Reply", "Comment_Id", "dbo.Comment");
            DropForeignKey("dbo.Order", "ReceiptAddressId", "dbo.Address");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Order", "ArtworkId", "dbo.Artwork");
            DropForeignKey("dbo.ActivityFollow", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ActivityFollow", "ArtistId", "dbo.Artist");
            DropForeignKey("dbo.ActivityShare", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ActivityShare", "ArtworkId", "dbo.Artwork");
            DropForeignKey("dbo.ActivityCollect", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ActivityCollect", "ArtworkId", "dbo.Artwork");
            DropForeignKey("dbo.AuctionBill", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.AuctionBill", "ArtworkId", "dbo.Artwork");
            DropForeignKey("dbo.ArtistGenre", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.ArtistGenre", "ArtistId", "dbo.Artist");
            DropForeignKey("dbo.Artist", "MasterpieceTypeId", "dbo.ArtworkType");
            DropForeignKey("dbo.ArtistImage", "Artist_Id", "dbo.Artist");
            DropForeignKey("dbo.ArtworkArtPlace", "ArtPlaceId", "dbo.ArtPlace");
            DropForeignKey("dbo.ArtworkArtPlace", "ArtworkId", "dbo.Artwork");
            DropForeignKey("dbo.ActivityPraise", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ActivityPraise", "ArtworkId", "dbo.Artwork");
            DropForeignKey("dbo.ArtworkImage", "Artwork_Id", "dbo.Artwork");
            DropForeignKey("dbo.Artwork", "Genre_Id", "dbo.Genre");
            DropForeignKey("dbo.Artwork", "DefaultCommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "ArtworkId", "dbo.Artwork");
            DropForeignKey("dbo.Comment", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Customer", "DefaultAddressId", "dbo.Address");
            DropForeignKey("dbo.Address", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Artwork", "ArtworkType_Id", "dbo.ArtworkType");
            DropForeignKey("dbo.Artwork", "ArtMaterial_Id", "dbo.ArtMaterial");
            DropForeignKey("dbo.ArtTechnique", "ArtworkType_Id", "dbo.ArtworkType");
            DropForeignKey("dbo.Artwork", "ArtTechnique_Id", "dbo.ArtTechnique");
            DropForeignKey("dbo.ArtShape", "ArtworkType_Id", "dbo.ArtworkType");
            DropForeignKey("dbo.Artwork", "ArtShape_Id", "dbo.ArtShape");
            DropForeignKey("dbo.ArtMaterial", "ArtworkType_Id", "dbo.ArtworkType");
            DropForeignKey("dbo.Artwork", "Artist_Id", "dbo.Artist");
            DropForeignKey("dbo.ArtistArtistType", "ArtistTypeId", "dbo.ArtistType");
            DropForeignKey("dbo.ArtistArtistType", "ArtistId", "dbo.Artist");
            DropIndex("dbo.ArtistGenre", new[] { "GenreId" });
            DropIndex("dbo.ArtistGenre", new[] { "ArtistId" });
            DropIndex("dbo.ArtworkArtPlace", new[] { "ArtPlaceId" });
            DropIndex("dbo.ArtworkArtPlace", new[] { "ArtworkId" });
            DropIndex("dbo.ArtistArtistType", new[] { "ArtistTypeId" });
            DropIndex("dbo.ArtistArtistType", new[] { "ArtistId" });
            DropIndex("dbo.ShoppingCartItem", new[] { "CustomerId" });
            DropIndex("dbo.ShoppingCartItem", new[] { "ArtworkId" });
            DropIndex("dbo.SystemNotice", new[] { "AdminUserId" });
            DropIndex("dbo.Reply", new[] { "User_Id" });
            DropIndex("dbo.Reply", new[] { "Comment_Id" });
            DropIndex("dbo.Order", new[] { "ReceiptAddressId" });
            DropIndex("dbo.Order", new[] { "ArtworkId" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.ActivityFollow", new[] { "ArtistId" });
            DropIndex("dbo.ActivityFollow", new[] { "CustomerId" });
            DropIndex("dbo.ActivityShare", new[] { "ArtworkId" });
            DropIndex("dbo.ActivityShare", new[] { "CustomerId" });
            DropIndex("dbo.ActivityCollect", new[] { "ArtworkId" });
            DropIndex("dbo.ActivityCollect", new[] { "CustomerId" });
            DropIndex("dbo.AuctionBill", new[] { "CustomerId" });
            DropIndex("dbo.AuctionBill", new[] { "ArtworkId" });
            DropIndex("dbo.ArtistImage", new[] { "Artist_Id" });
            DropIndex("dbo.ActivityPraise", new[] { "ArtworkId" });
            DropIndex("dbo.ActivityPraise", new[] { "CustomerId" });
            DropIndex("dbo.ArtworkImage", new[] { "Artwork_Id" });
            DropIndex("dbo.Address", new[] { "CustomerId" });
            DropIndex("dbo.Customer", new[] { "DefaultAddressId" });
            DropIndex("dbo.Comment", new[] { "CustomerId" });
            DropIndex("dbo.Comment", new[] { "ArtworkId" });
            DropIndex("dbo.ArtTechnique", new[] { "ArtworkType_Id" });
            DropIndex("dbo.ArtShape", new[] { "ArtworkType_Id" });
            DropIndex("dbo.ArtMaterial", new[] { "ArtworkType_Id" });
            DropIndex("dbo.Artwork", new[] { "Genre_Id" });
            DropIndex("dbo.Artwork", new[] { "ArtworkType_Id" });
            DropIndex("dbo.Artwork", new[] { "ArtMaterial_Id" });
            DropIndex("dbo.Artwork", new[] { "ArtTechnique_Id" });
            DropIndex("dbo.Artwork", new[] { "ArtShape_Id" });
            DropIndex("dbo.Artwork", new[] { "Artist_Id" });
            DropIndex("dbo.Artwork", new[] { "DefaultCommentId" });
            DropIndex("dbo.Artist", new[] { "MasterpieceTypeId" });
            DropTable("dbo.ArtistGenre");
            DropTable("dbo.ArtworkArtPlace");
            DropTable("dbo.ArtistArtistType");
            DropTable("dbo.ShoppingCartItem");
            DropTable("dbo.SystemNotice");
            DropTable("dbo.Reply");
            DropTable("dbo.Order");
            DropTable("dbo.OperationLog");
            DropTable("dbo.ExceptionLog");
            DropTable("dbo.AdminUser");
            DropTable("dbo.ActivityFollow");
            DropTable("dbo.ActivityShare");
            DropTable("dbo.ActivityCollect");
            DropTable("dbo.AuctionBill");
            DropTable("dbo.ArtistImage");
            DropTable("dbo.ArtPlace");
            DropTable("dbo.ActivityPraise");
            DropTable("dbo.ArtworkImage");
            DropTable("dbo.Genre");
            DropTable("dbo.Address");
            DropTable("dbo.Customer");
            DropTable("dbo.Comment");
            DropTable("dbo.ArtTechnique");
            DropTable("dbo.ArtShape");
            DropTable("dbo.ArtworkType");
            DropTable("dbo.ArtMaterial");
            DropTable("dbo.Artwork");
            DropTable("dbo.ArtistType");
            DropTable("dbo.Artist");
        }
    }
}

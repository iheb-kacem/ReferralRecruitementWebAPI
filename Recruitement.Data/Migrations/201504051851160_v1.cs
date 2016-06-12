namespace Recruitement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        AdministratorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdministratorID);
            
            CreateTable(
                "dbo.Tenancies",
                c => new
                    {
                        EntrepriseID = c.Int(nullable: false, identity: true),
                        EntrepriseName = c.String(nullable: false),
                        Logo = c.Binary(),
                        TextColor = c.String(),
                        TmpColor = c.String(),
                        Status = c.Boolean(nullable: false),
                        Administrator_AdministratorID = c.Int(),
                    })
                .PrimaryKey(t => t.EntrepriseID)
                .ForeignKey("dbo.Administrators", t => t.Administrator_AdministratorID)
                .Index(t => t.Administrator_AdministratorID);
            
            CreateTable(
                "dbo.Personals",
                c => new
                    {
                        PersonalID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(nullable: false),
                        Bonus = c.Int(),
                        Success = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Tenancy_EntrepriseID = c.Int(),
                        Tenancy_EntrepriseID1 = c.Int(),
                        Tenancy_EntrepriseID2 = c.Int(),
                    })
                .PrimaryKey(t => t.PersonalID)
                .ForeignKey("dbo.Tenancies", t => t.Tenancy_EntrepriseID)
                .ForeignKey("dbo.Tenancies", t => t.Tenancy_EntrepriseID1)
                .ForeignKey("dbo.Tenancies", t => t.Tenancy_EntrepriseID2)
                .Index(t => t.Tenancy_EntrepriseID)
                .Index(t => t.Tenancy_EntrepriseID1)
                .Index(t => t.Tenancy_EntrepriseID2);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        OfferID = c.Int(nullable: false, identity: true),
                        OfferName = c.String(),
                        Note = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Recruiter_PersonalID = c.Int(),
                        Reward_RewardID = c.Int(),
                    })
                .PrimaryKey(t => t.OfferID)
                .ForeignKey("dbo.Personals", t => t.Recruiter_PersonalID)
                .ForeignKey("dbo.Rewards", t => t.Reward_RewardID)
                .Index(t => t.Recruiter_PersonalID)
                .Index(t => t.Reward_RewardID);
            
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        ApplicationID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        CV = c.Binary(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.String(),
                        Offer_OfferID = c.Int(),
                        Referral_PersonalID = c.Int(),
                    })
                .PrimaryKey(t => t.ApplicationID)
                .ForeignKey("dbo.Offers", t => t.Offer_OfferID)
                .ForeignKey("dbo.Personals", t => t.Referral_PersonalID)
                .Index(t => t.Offer_OfferID)
                .Index(t => t.Referral_PersonalID);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackID = c.Int(nullable: false, identity: true),
                        Note = c.String(nullable: false),
                        Application_ApplicationID = c.Int(),
                    })
                .PrimaryKey(t => t.FeedbackID)
                .ForeignKey("dbo.Applications", t => t.Application_ApplicationID)
                .Index(t => t.Application_ApplicationID);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationID = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                        Date = c.DateTime(nullable: false),
                        Offer_OfferID = c.Int(),
                        Referral_PersonalID = c.Int(),
                    })
                .PrimaryKey(t => t.NotificationID)
                .ForeignKey("dbo.Offers", t => t.Offer_OfferID)
                .ForeignKey("dbo.Personals", t => t.Referral_PersonalID)
                .Index(t => t.Offer_OfferID)
                .Index(t => t.Referral_PersonalID);
            
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        RewardID = c.Int(nullable: false, identity: true),
                        Sharing = c.Int(nullable: false),
                        HRIntrvw = c.Int(nullable: false),
                        TechIntrvw = c.Int(nullable: false),
                        MnIntrvw = c.Int(nullable: false),
                        Hire = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RewardID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personals", "Tenancy_EntrepriseID2", "dbo.Tenancies");
            DropForeignKey("dbo.Personals", "Tenancy_EntrepriseID1", "dbo.Tenancies");
            DropForeignKey("dbo.Personals", "Tenancy_EntrepriseID", "dbo.Tenancies");
            DropForeignKey("dbo.Offers", "Reward_RewardID", "dbo.Rewards");
            DropForeignKey("dbo.Offers", "Recruiter_PersonalID", "dbo.Personals");
            DropForeignKey("dbo.Notifications", "Referral_PersonalID", "dbo.Personals");
            DropForeignKey("dbo.Notifications", "Offer_OfferID", "dbo.Offers");
            DropForeignKey("dbo.Applications", "Referral_PersonalID", "dbo.Personals");
            DropForeignKey("dbo.Applications", "Offer_OfferID", "dbo.Offers");
            DropForeignKey("dbo.Feedbacks", "Application_ApplicationID", "dbo.Applications");
            DropForeignKey("dbo.Tenancies", "Administrator_AdministratorID", "dbo.Administrators");
            DropIndex("dbo.Notifications", new[] { "Referral_PersonalID" });
            DropIndex("dbo.Notifications", new[] { "Offer_OfferID" });
            DropIndex("dbo.Feedbacks", new[] { "Application_ApplicationID" });
            DropIndex("dbo.Applications", new[] { "Referral_PersonalID" });
            DropIndex("dbo.Applications", new[] { "Offer_OfferID" });
            DropIndex("dbo.Offers", new[] { "Reward_RewardID" });
            DropIndex("dbo.Offers", new[] { "Recruiter_PersonalID" });
            DropIndex("dbo.Personals", new[] { "Tenancy_EntrepriseID2" });
            DropIndex("dbo.Personals", new[] { "Tenancy_EntrepriseID1" });
            DropIndex("dbo.Personals", new[] { "Tenancy_EntrepriseID" });
            DropIndex("dbo.Tenancies", new[] { "Administrator_AdministratorID" });
            DropTable("dbo.Rewards");
            DropTable("dbo.Notifications");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Applications");
            DropTable("dbo.Offers");
            DropTable("dbo.Personals");
            DropTable("dbo.Tenancies");
            DropTable("dbo.Administrators");
        }
    }
}

namespace TwitterClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TwitterFirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        user_id = c.String(nullable: false, maxLength: 25, unicode: false),
                        joined = c.DateTime(nullable: false),
                        password = c.String(nullable: false, maxLength: 50, unicode: false),
                        fullname = c.String(nullable: false, maxLength: 30, unicode: false),
                        email = c.String(nullable: false, maxLength: 50, unicode: false),
                        active = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.user_id);
            
            CreateTable(
                "dbo.Tweets",
                c => new
                    {
                        tweet_id = c.Int(nullable: false, identity: true),
                        user_id = c.String(nullable: false, maxLength: 25, unicode: false),
                        message = c.String(nullable: false, maxLength: 140, unicode: false),
                        created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.tweet_id)
                .ForeignKey("dbo.People", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        user_id = c.String(nullable: false, maxLength: 128),
                        following_id = c.String(nullable: false, maxLength: 128),
                        Follower_UserId = c.String(maxLength: 25, unicode: false),
                        User_UserId = c.String(maxLength: 25, unicode: false),
                    })
                .PrimaryKey(t => new { t.user_id, t.following_id })
                .ForeignKey("dbo.People", t => t.Follower_UserId)
                .ForeignKey("dbo.People", t => t.User_UserId)
                .Index(t => t.Follower_UserId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "User_UserId", "dbo.People");
            DropForeignKey("dbo.Followings", "Follower_UserId", "dbo.People");
            DropForeignKey("dbo.Tweets", "user_id", "dbo.People");
            DropIndex("dbo.Followings", new[] { "User_UserId" });
            DropIndex("dbo.Followings", new[] { "Follower_UserId" });
            DropIndex("dbo.Tweets", new[] { "user_id" });
            DropTable("dbo.Followings");
            DropTable("dbo.Tweets");
            DropTable("dbo.People");
        }
    }
}

namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantReview : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RestauranReviews", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.RestauranReviews", new[] { "Restaurant_Id" });
            RenameColumn(table: "dbo.RestaurantReviews", name: "Restaurant_Id", newName: "RestaurantId");
            CreateTable(
                "dbo.RestaurantReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            DropTable("dbo.RestauranReviews");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RestauranReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(),
                        RestaurantReview = c.Int(nullable: false),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.RestaurantReviews", new[] { "RestaurantId" });
            DropForeignKey("dbo.RestaurantReviews", "RestaurantId", "dbo.Restaurants");
            DropTable("dbo.RestaurantReviews");
            RenameColumn(table: "dbo.RestaurantReviews", name: "RestaurantId", newName: "Restaurant_Id");
            CreateIndex("dbo.RestauranReviews", "Restaurant_Id");
            AddForeignKey("dbo.RestauranReviews", "Restaurant_Id", "dbo.Restaurants", "Id");
        }
    }
}

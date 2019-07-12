namespace OdeToFood.Migrations
{
    using OdeToFood.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "OdeToFood.Models.OdeToFoodDb";
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = "Sabatino 's", City = "Baltimore", Country = "USA" },
                new Restaurant { Name = "Great Lake", City = "Chicago", Country = "USA" },
                new Restaurant
                {
                    Name = "Blue Parror",
                    City = "Athens",
                    Country = "Hellas",
                    Reviews = new List<RestaurantReview> {
                        new RestaurantReview {Rating = 9, Body ="Gread food!", ReviewerName="Nick", DateCreated = DateTime.Now }
                    }
                });
                
        }
    }
}

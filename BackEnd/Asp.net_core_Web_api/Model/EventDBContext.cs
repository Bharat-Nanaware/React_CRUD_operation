using Microsoft.EntityFrameworkCore;

namespace React_assignment_1_web_api.Model
{
    public class EventDBContext : DbContext
    {

      public EventDBContext(DbContextOptions<EventDBContext> options) : base(options)
        {
 
        }
 
        public DbSet<Event> Events { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserOrderedFood> UserOrderedFood { get; set; }
        public DbSet<MealSummery> MealSummery { get;set; }
    }
}

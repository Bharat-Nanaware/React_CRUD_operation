using React_assignment_1_web_api.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace React_assignment_1_web_api.Entity
{
    public class OrderFood
    {
        
            public List<FoodEntity> items { get; set; }
            public decimal totalAmount { get; set; }
            public User User { get; set; }
        
    }

    public class FoodEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodID { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}

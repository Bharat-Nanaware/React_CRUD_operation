using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace React_assignment_1_web_api.Model
{
    public class UserOrderedFood
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserOrderedFoodID { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public int FoodID { get; set; }

        [ForeignKey("FoodID")]
        public virtual Food Food { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace React_assignment_1_web_api.Model
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodID { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(400)]
        public string Info { get; set; }

        public decimal Price { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace React_assignment_1_web_api.Model
{
    public class MealSummery
    { 
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MealsummeryID { get; set; }

        public string MealSummeryTitle { get; set; }

        public string MealsummeryDescription_1 { get; set; }

        public string MealsummeryDescription_2 { get; set; }
    
    
    }
}

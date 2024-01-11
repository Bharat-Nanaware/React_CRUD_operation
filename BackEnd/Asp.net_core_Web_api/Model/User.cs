using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace React_assignment_1_web_api.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Street { get; set; }

        [StringLength(200)]
        public string PostalCode { get; set; }

        [StringLength(200)]
        public string City { get; set; }

        public decimal TotalAmount { get; set; }
    }
}

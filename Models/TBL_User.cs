using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCore.Models
{
    public class TBL_User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "User Id")]
        public int UserId { get; set; }
        [StringLength(100)]
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        [Display(Name = "Department")]
        public int? DepId { get; set; }
        [ForeignKey("DepId")]
        public virtual TBL_Department Department { get; set; }
        public virtual IList<TBL_Salary> Salary { get; set; }
    }
}

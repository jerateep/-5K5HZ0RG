using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCore.Models
{
    public class TBL_Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SId { get; set; }
        public DateTime? Dtm_Pay { get; set; }
        public decimal? Amount { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual TBL_User User { get; set; }
    }
}
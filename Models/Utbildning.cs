using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi_Uppgift.Models
{
    public class Utbildning
    {
        [Key]
        public int UtbildningsID { get; set; }

        public int StartDatum { get; set; }
        public int SlutDatum { get; set; }
        public int Examen { get; set; }

        [StringLength(20, MinimumLength =5)]
        public string Skola { get; set; }

        [ForeignKey("Person")]
        public int? PersonID_FK { get; set; }
    }
}

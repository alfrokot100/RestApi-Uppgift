using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestApi_Uppgift.DTOs.UtbildningDTO
{
    public class UtbildningCreateDTO
    {
        public int StartDatum { get; set; }
        public int SlutDatum { get; set; }
        public int Examen { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string Skola { get; set; }

        [ForeignKey("Person")]
        public int? PersonID_FK { get; set; }
    }
}

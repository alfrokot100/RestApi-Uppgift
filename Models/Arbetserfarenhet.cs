using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi_Uppgift.Models
{
    public class Arbetserfarenhet
    {
        
        [Key]
        public int ErfarenhetID { get; set; }
        public int Datum { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Jobbtitel { get; set; }

        [StringLength(50, MinimumLength =2)]
        public string Company { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Beskrivning { get; set; }

        public int PersonID_FK { get; set; }

        //[ForeignKey(nameof(PersonID_FK))]
        //public virtual Person Person { get; set; }
    }
}

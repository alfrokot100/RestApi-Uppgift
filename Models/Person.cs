using System.ComponentModel.DataAnnotations;

namespace RestApi_Uppgift.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        [StringLength(15)]
        public string TelefonNmr { get; set; }

        [EmailAddress]
        public string Epost { get; set; }

        [StringLength(20, MinimumLength = 2)]
        public string Namn { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string Beskrivning { get; set; }

        public virtual List<Arbetserfarenhet> Arbetserfarenheter { get; set; } = new List<Arbetserfarenhet>();
        public virtual List<Utbildning> Utbildningar { get; set; } = new List<Utbildning>();// Undviker Null

    }
}

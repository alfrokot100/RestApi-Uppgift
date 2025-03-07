namespace RestApi_Uppgift.DTOs.ErfarenhetDTO
{
    public class ErfarenhetDTOs
    {
        public int ErfarenhetID { get; set; }
        public int Datum { get; set; }
        public string Jobbtitel { get; set; }
        public string Company { get; set; }
        public string Beskrivning { get; set; }
        public int PersonID_FK { get; set; }
    }
}

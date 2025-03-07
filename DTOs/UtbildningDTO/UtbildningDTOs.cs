namespace RestApi_Uppgift.DTOs.UtbildningDTO
{
    public class UtbildningDTOs
    {
        public int UtbildningsID { get; set; }
        public int StartDatum { get; set; }
        public int SlutDatum { get; set; }
        public int Examen { get; set; }
        public string Skola { get; set; }
        public int? PersonID_FK { get; set; }


    }
}

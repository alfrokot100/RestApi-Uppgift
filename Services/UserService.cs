using Microsoft.EntityFrameworkCore;
using RestApi_Uppgift.Data;
using RestApi_Uppgift.DTOs.ErfarenhetDTO;
using RestApi_Uppgift.DTOs.PersonDTOs;
using RestApi_Uppgift.DTOs.UtbildningDTO;
using System.Linq.Expressions;

namespace RestApi_Uppgift.Services
{
    public class UserService 
    {
        private readonly WorkDBContext context;
        //Dependency injection
        public UserService(WorkDBContext _context)
        {
            context = _context;
        }

        public async Task<List<PersonDTO>> GetAllPersons()
        {
                var personList = await context.person.Select(s => new PersonDTO
                {
                    PersonID = s.PersonID,
                    PersonBeskrivning = s.Beskrivning,
                    PersonEpost = s.Epost,
                    PersonNamn = s.Namn

                }).ToListAsync();

                return personList;
            
            
        }

        public async Task<List<ErfarenhetDTOs>> GetErfarenheter()
        {
            var jobList = await context.erfarenheter.Select(e => new ErfarenhetDTOs
            {
                ErfarenhetID = e.ErfarenhetID,
                Datum = e.Datum,
                Jobbtitel = e.Jobbtitel,
                Company = e.Company,
                Beskrivning = e.Company,
                PersonID_FK = e.PersonID_FK
            }).ToListAsync();

            return jobList;
        }

        public async Task<List<UtbildningDTOs>> GetUtbildning()
        {
            var utbildningList = await context.utbildnings.Select(u => new UtbildningDTOs
            {
                UtbildningsID = u.UtbildningsID,
                StartDatum = u.StartDatum,
                SlutDatum = u.SlutDatum,
                Examen = u.Examen,
                Skola = u.Skola,
                PersonID_FK = u.PersonID_FK

            }).ToListAsync();
            return utbildningList;
        }


    }
}

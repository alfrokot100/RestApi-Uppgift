using Microsoft.EntityFrameworkCore;
using RestApi_Uppgift.Data;
using RestApi_Uppgift.DTOs.ErfarenhetDTO;
using RestApi_Uppgift.DTOs.GitDTO;
using RestApi_Uppgift.DTOs.PersonDTOs;
using RestApi_Uppgift.DTOs.UtbildningDTO;
using RestApi_Uppgift.Models;
using RestApi_Uppgift.Services;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text.Json;


namespace RestApi_Uppgift.Endpoints.StudentEnpoints
{
    public class StudentEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapGet("/person",async (UserService userservice) =>
            {
                var personer = await userservice.GetAllPersons();

                return personer;
            });

            app.MapGet("/erfarenheter", async (UserService userservice) => 
            {
                var erfarenhet = await userservice.GetErfarenheter();

                return erfarenhet;
            });

            app.MapGet("/utbildnings", async (UserService userservice) =>
            {
                var utbildning = await userservice.GetUtbildning();

                return utbildning;
            });

//--------------------------------------------------------------------------------------------------


            app.MapGet("/students/{id}", async (WorkDBContext context, int id) =>
            {
                var person = await context.person.FirstOrDefaultAsync(p => p.PersonID == id);

                if(person == null)
                {
                    return Results.NotFound("Personen hittas inte kompis!");
                }
                return Results.Ok(person);
            });            

            app.MapPost("/utbildning", async (WorkDBContext context, UtbildningCreateDTO newUtbildning) =>
            {
                var validationContext = new ValidationContext(newUtbildning);
                var validationResult = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(newUtbildning, validationContext, validationResult, true);

                if (!isValid)
                {
                    return Results.BadRequest();
                }

                var utbildning = new Utbildning
                {
                    StartDatum = newUtbildning.StartDatum,
                    SlutDatum = newUtbildning.SlutDatum,
                    Examen = newUtbildning.Examen,
                    Skola = newUtbildning.Skola,
                    PersonID_FK = newUtbildning.PersonID_FK
                };

                context.utbildnings.Add(utbildning);
                await context.SaveChangesAsync();

                return Results.Ok(utbildning);

            });
            
            //Uppdaterar i detta fall utbildnings tabell vissa rader
            app.MapPut("/erfarenhet/{id}", async (WorkDBContext context, ErfarenhetUpdateDTOs erfarenhet, int id) =>
            {
                var existingStudent = await context.erfarenheter.FirstOrDefaultAsync(s => s.ErfarenhetID == id);

                if(existingStudent == null)
                {
                    return Results.NotFound("ErfarenhetsID:et hittades ej!");
                }

                existingStudent.Jobbtitel = erfarenhet.updateJobbTitel;
                existingStudent.Company = erfarenhet.updateCompany;

                await context.SaveChangesAsync();
                return Results.Ok(existingStudent);
            });

            app.MapDelete("/utbildning/{id}", async (WorkDBContext context, int id) =>
            {
                var utbildning = await context.utbildnings.FindAsync(id);

                if(utbildning == null)
                {
                    return Results.NotFound("UtbildningsID:et hittades ej!");
                }

                context.Remove(utbildning);
                await context.SaveChangesAsync();

                return Results.NoContent();
            });

            app.MapGet("/githubdata{username}", async (HttpClient client, string username) =>
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("C# App");

                var response = await client.GetAsync($"https://api.github.com/users/{username}/repos");

                if (!response.IsSuccessStatusCode)
                {
                    return Results.BadRequest("Repot hittas inte!");
                }
                //Parse Data
                var json = await response.Content.ReadAsStringAsync();//Omvandlar till en JSON string

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };//Den ska inte vara CaseSensitive

                var repos = JsonSerializer.Deserialize<List<GitDTOs>>(json, options);

                // Hantera null-värden
                foreach (var repo in repos)
                {
                    //Kollar om värdet är null eller tomt
                    repo.Description ??= "Finns ingen beskrivning!";
                    repo.Language ??= "Finns inget språk!";
                }
                //Return Data
                return Results.Ok(repos);

            });
        }
    }
}

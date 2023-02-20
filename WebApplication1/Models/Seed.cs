using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class Seed
    {



        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApplication1Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebApplication1Context>>()))
            {
                // Chercher n'importe quelle voiture.
                if (context.Voitures.Any())
                {
                    return;   // la base de données est déjà peuplée
                }

                context.Voitures.AddRange(
                    new Voitures
                    {
                     
                        Nom = "Mustang",
                        Marque = "Ford",
                        Prix = 10000,
                        DateFabrication = DateTime.Parse("1966-1-12"),
                        Rating = "R"
                    },
                    new Voitures
                    {
                        
                        Nom = "T",
                        Marque = "Ford",
                        Prix = 10000,
                        DateFabrication = DateTime.Parse("1911-1-12"),
                        Rating = "R"
                    },
                    new Voitures
                    {
                       
                        Nom = "4L",
                        Marque = "Renault",
                        Prix = 10000,
                        DateFabrication = DateTime.Parse("1968-1-12"),
                         
                        Rating = "R"
                    },
                    new Voitures
                    {
                        Nom = "1000",
                        Marque = "Sicma",
                        Prix = 10000,
                       
                        DateFabrication = DateTime.Parse("1968-1-12")
                        ,
                        Rating = "Rati"
                    },
                    new Voitures
                    {
                        
                        Nom = "Traction",
                        Marque = "Citroen",
                        Prix = 10000,
                        DateFabrication = DateTime.Parse("1938-1-12"),
                         
                        Rating = "Rati"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
    
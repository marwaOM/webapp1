using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Models
{
    public class SearshVoiture
    {
        public List<Voitures>? Voitures { get; set; }
        public SelectList? Marque { get; set; }
        public string? VoitureMarque { get; set; }
        public string? SearchString { get; set; }
    }
}

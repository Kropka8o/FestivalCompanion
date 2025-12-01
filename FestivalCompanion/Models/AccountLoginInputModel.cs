using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels // Pas de namespace aan naar die van jouw project
{
    public class AccountLoginInputModel
    {
        // 1. Validatie voor Gebruikersnaam / UPN (Afbeelding 2)
        [Required(ErrorMessage = "De gebruikersnaam (UPN) is verplicht.")]
        [EmailAddress(ErrorMessage = "Ongeldig formaat voor UPN.")]
        [MaxLength(113, ErrorMessage = "De totale lengte van de gebruikersnaam mag niet langer zijn dan 113 tekens.")]

        // Controleert de regel: mag geen punt '.' direct voor het '@' symbool bevatten.
        // Deze reguliere expressie controleert of de hele string niet het patroon '*.@' bevat.
        [RegularExpression(@"^(?!.*\.@).*$",
            ErrorMessage = "Het '@'-symbool mag geen punt '.' direct voorafgaan. Controleer de invoer.")]
        public required string Email { get; set; } // We gebruiken Email omdat de UPN een e-mailachtig formaat heeft.


        // 2. Validatie voor Wachtwoord (Afbeelding 1)
        [Required(ErrorMessage = "Het wachtwoord is verplicht.")]

        // Lengtebeperking: Minimaal 8 en maximaal 256 tekens.
        [MinLength(8, ErrorMessage = "Wachtwoord moet minimaal 8 tekens bevatten.")]
        [MaxLength(256, ErrorMessage = "Wachtwoord mag maximaal 256 tekens bevatten.")]

        // Complexiteitsbeperking: Vereist drie van de vier typen tekens (Kleine letter, Hoofdletter, Cijfer, Symbool).
        [RegularExpression(
            // Dit is een complexe regex die de vier mogelijke combinaties van drie types afdwingt.
            @"^(?:(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])|(?=.*[a-z])(?=.*[A-Z])(?=.*[^A-Za-z0-9])|(?=.*[a-z])(?=.*[0-9])(?=.*[^A-Za-z0-9])|(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])).{8,256}$",
            ErrorMessage = "Wachtwoord moet voldoen aan 3 van de 4 typen tekens: kleine letter, hoofdletter, cijfer of symbool."
        )]
        public required string Password { get; set; }
    }
}

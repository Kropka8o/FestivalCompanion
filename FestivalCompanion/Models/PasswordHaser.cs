using Isopoh.Cryptography.Argon2;
using System.Text;

namespace FestivalCompanion.Models // Let op: De namespace is nu 'FestivalCompanion.Models'
{
    public class PasswordHasher // Let op: Classnaam is 'PasswordHasher', niet 'PasswordHaser'
    {
        // De beveiligingsparameters voor Argon2id (512MB, 3 iteraties, 4 threads)
        private readonly Argon2Config _configDefaults;

        public PasswordHasher()
        {
            // Configuratie gebaseerd op de gevraagde veilige parameters
            _configDefaults = new Argon2Config
            {
                Type = Argon2.Argon2Type.Id,     // Argon2id: Meest veilige variant
                Version = Argon2.Argon2Version.Version13,
                HashLength = 32,                // Output hash lengte (256-bit)

                // Custom Performance Parameters (tegen brute-force)
                TimeCost = 3,                   // Iteraties: Tijdskosten
                MemoryCost = 524288,            // Geheugenkosten: 512 * 1024 = 524288 KiB
                Lanes = 4,                      // Parallelisme: Hoeveel threads er werken
            };
        }

        /// <summary>
        /// Maakt een veilige, onomkeerbare hash van het wachtwoord.
        /// </summary>
        /// <param name="password">Het plaintext wachtwoord.</param>
        /// <returns>De volledige hashstring, inclusief salt en parameters.</returns>
        public string HashPassword(string password)
        {
            var config = (Argon2Config)_configDefaults.Clone();

            // Stel het wachtwoord in en genereer een unieke salt
            config.Password = Encoding.UTF8.GetBytes(password);
            config.Salt = Argon2.GenSalt();

            // Hash en retourneer de veilige string
            return Argon2.Hash(config);
        }

        /// <summary>
        /// Verifieert een plaintext wachtwoord tegen een bestaande Argon2 hash.
        /// </summary>
        /// <param name="password">Het plaintext wachtwoord dat de gebruiker heeft ingevoerd.</param>
        /// <param name="hash">De hashstring uit de database.</param>
        /// <returns>True als de wachtwoorden overeenkomen, anders False.</returns>
        public bool VerifyPassword(string password, string hash)
        {
            // De Argon2.Verify leest de parameters en salt automatisch uit de hashstring.
            return Argon2.Verify(hash, password);
        }
    }
}
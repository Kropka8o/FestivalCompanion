using Isopoh.Cryptography.Argon2;
using System.Text;
using System.Security.Cryptography;

namespace FestivalCompanion.Models
{
    public class PasswordHasher
    {
        private readonly Argon2Config _configDefaults;

        public PasswordHasher()
        {
            _configDefaults = new Argon2Config
            {
                // FIX: Gebruik de juiste enumwaarde voor Argon2Type
                Type = Argon2Type.HybridAddressing,
                Version = Argon2Version.Nineteen,
                HashLength = 32,                    // 256-bit output hash

                // Custom Performance Parameters
                TimeCost = 3,
                MemoryCost = 524288,                // 512 MB
                Lanes = 4,
            };
        }

        public string HashPassword(string password)
        {
            // FIX: Gebruik een object-initializer om de waarden van de defaults over te nemen
            var config = new Argon2Config
            {
                Type = _configDefaults.Type,
                Version = _configDefaults.Version,
                HashLength = _configDefaults.HashLength,
                TimeCost = _configDefaults.TimeCost,
                MemoryCost = _configDefaults.MemoryCost,
                Lanes = _configDefaults.Lanes,

                Password = Encoding.UTF8.GetBytes(password),
                // FIX: Maak een cryptografisch veilige salt (GenSalt is verwijderd/veranderd in v2.0.0)
                Salt = new byte[16]
            };
            RandomNumberGenerator.Fill(config.Salt); // Vul de salt met veilige willekeurige bytes

            return Argon2.Hash(config);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return Argon2.Verify(hash, password);
        }
    }
}
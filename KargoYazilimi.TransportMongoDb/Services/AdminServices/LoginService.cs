using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.AdminDtos;
using KargoYazilimi.TransportMongoDb.Entities;
using KargoYazilimi.TransportMongoDb.Settings;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using MongoDB.Driver;
using System.Security.Cryptography;

namespace KargoYazilimi.TransportMongoDb.Services.AdminServices
{
    public class LoginService : ILoginService
    {
        private readonly IMongoCollection<Admin> _adminCollection;

        public LoginService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _adminCollection = database.GetCollection<Admin>(_databaseSettings.AdminCollectionName);
        }

        public string HashPassword(string password)
        {
            // Şifreyi tuzlayıp (salt) hashler. 
            // Her seferinde farklı bir hash üretir ama doğrulamada şaşmaz!
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Girilen düz metin şifreyi (123456), DB'deki karmaşık hash ile kıyaslar
            try
            {
                return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
            }
            catch
            {
                // Eğer DB'de eski usul düz şifre kalmışsa patlamasın diye
                return false;
            }
        }

        public async Task<Admin> CheckUserAsync(LoginDto loginDto)
        {
            var admin = await _adminCollection.Find(x => x.Username == loginDto.Username && x.IsActive == true).FirstOrDefaultAsync();

            if (admin == null) return null;

            // İŞTE KRİTİK NOKTA: Hash kontrolü burada yapılıyor
            if (!VerifyPassword(loginDto.Password, admin.PasswordHash))
                return null;

            return admin;
        }
    }
}

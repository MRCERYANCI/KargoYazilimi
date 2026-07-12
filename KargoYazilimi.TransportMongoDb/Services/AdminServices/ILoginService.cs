using KargoYazilimi.TransportMongoDb.Dtos.AdminDtos;
using KargoYazilimi.TransportMongoDb.Entities;

namespace KargoYazilimi.TransportMongoDb.Services.AdminServices
{
    public interface ILoginService
    {
        Task<Admin> CheckUserAsync(LoginDto loginDto);
        string HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string storedHash);
    }
}

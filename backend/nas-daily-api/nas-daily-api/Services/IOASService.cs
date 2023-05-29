using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface IOASService
    {
        OASDto GetOASByUserId(string userId);
        OASDto GetOASByName(string name);
        string DeleteOASByUserId(string userId);
        string DelteOASByName(string name);

        // Add more method signatures as per your requirements
    }
}
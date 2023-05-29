using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface IOASService
    {
        OASDto GetOASByUserId(string userId);

        // Add more method signatures as per your requirements
    }
}
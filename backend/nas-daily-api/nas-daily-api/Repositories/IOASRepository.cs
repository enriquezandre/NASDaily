using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public interface IOASRepository
    {
        OASDto GetByUserId(string userId);

        // Add more method signatures as per your requirements
    }
}
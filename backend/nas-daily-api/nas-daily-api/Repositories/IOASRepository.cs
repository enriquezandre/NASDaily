using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public interface IOASRepository
    {
        OASDto GetByUserId(string userId);
        OASDto GetByName(string name);

        string DeleteByUserId(string userId);
        string DeleteByName(string name);

        OASDto Create(OASDto oas);
        OASDto Update(OASDto oas, string userId);
        List<OASDto> GetAllOAS();


        // Add more method signatures as per your requirements
    }
}
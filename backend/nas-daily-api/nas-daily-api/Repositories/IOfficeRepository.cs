using nas_daily_api.Dtos;

namespace nas_daily_api.Repositories
{
    public interface IOfficeRepository
    {
        OfficeDto GetByOfficeId(string officeId);
        List<OfficeDto> GetAllOffices();
        OfficeDto CreateOffice(OfficeDto office);
        void UpdateOffice(string officeId, OfficeDto office);
        void DeleteOffice(string officeId);
    }
}
using nas_daily_api.Dtos;

namespace nas_daily_api.Services
{
    public interface IOfficeService
    {
        OfficeDto GetOfficeByOfficeId(string officeId);
        List<OfficeDto> GetAllOffices();
        OfficeDto CreateOffice(OfficeDto office);
        void UpdateOffice(string officeId, OfficeDto office);
        void DeleteOffice(string officeId);
    }
}
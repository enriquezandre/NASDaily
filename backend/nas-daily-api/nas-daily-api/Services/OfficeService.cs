using nas_daily_api.Dtos;
using nas_daily_api.Repositories;
using System.Collections.Generic;

namespace nas_daily_api.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _officeRepository;

        public OfficeService(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        public OfficeDto GetOfficeByOfficeId(string officeId)
        {
            return _officeRepository.GetByOfficeId(officeId);
        }

        public List<OfficeDto> GetAllOffices()
        {
            return _officeRepository.GetAllOffices();
        }

        public OfficeDto CreateOffice(OfficeDto office)
        {
            return _officeRepository.CreateOffice(office);
        }

        public void UpdateOffice(string officeId, OfficeDto office)
        {
            _officeRepository.UpdateOffice(officeId, office);
        }

        public void DeleteOffice(string officeId)
        {
            _officeRepository.DeleteOffice(officeId);
        }
    }
}
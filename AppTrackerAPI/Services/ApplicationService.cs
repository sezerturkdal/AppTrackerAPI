using System;
using AppTrackerAPI.DTOs;
using AppTrackerAPI.Models;
using AppTrackerAPI.Repositories;

namespace AppTrackerAPI.Services
{
    public class ApplicationService
    {
        private readonly IRepositoryGet<ApplicationDto> _repository;
        private readonly IRepositorySave<Application> _appRepository;

        public ApplicationService(IRepositoryGet<ApplicationDto> repository, IRepositorySave<Application> appRepository)
        {
            _repository = repository;
            _appRepository = appRepository;
        }

        public async Task<IEnumerable<ApplicationDto>> GetAllApplications() => await _repository.GetAll();

        public async Task<ApplicationDto> GetApplicationById(int id) => await _repository.GetById(id);

        public async Task AddApplication(Application application) => await _appRepository.Add(application);

        public async Task UpdateApplication(Application application) => await _appRepository.Update(application);

        public async Task DeleteApplication(int id) => await _appRepository.Delete(id);
    }

}


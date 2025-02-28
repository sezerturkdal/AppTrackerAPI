using System;
using AppTrackerAPI.DTOs;
using AppTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTrackerAPI.Repositories
{
    public class ApplicationRepository : IRepositoryGet<ApplicationDto>, IRepositorySave<Application>
    {
        private readonly AppDbContext _context;

        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationDto>> GetAll()
        {
            return await _context.Applications
                .Include(a => a.StatusLevel)   
                .Include(a => a.Inquiries) 
                .Select(a => new ApplicationDto
                {
                    Id = a.Id,
                    AppStatus = a.AppStatus,
                    ProjectRef = a.ProjectRef,
                    ProjectName = a.ProjectName,
                    ProjectLocation = a.ProjectLocation,
                    OpenDt = a.OpenDt,
                    StartDt = a.StartDt,
                    CompletedDt = a.CompletedDt,
                    ProjectValue = a.ProjectValue,
                    StatusLevel = a.StatusLevel != null ? new StatusLevelDto
                    {
                        Id = a.StatusLevel.Id,
                        StatusName = a.StatusLevel.StatusName
                    } : null,
                    Inquiries = a.Inquiries != null ? a.Inquiries.Select(i => new InquiryDto
                    {
                        Id = i.Id,
                        ApplicationId = i.ApplicationId,
                        SendToPerson = i.SendToPerson,
                        SendToRole = i.SendToRole,
                        SendToPersonId = i.SendToPersonId,
                        Subject = i.Subject,
                        InquiryText = i.InquiryText,
                        Response = i.Response,
                        AskedDt = i.AskedDt,
                        CompletedDt = i.CompletedDt
                    }).ToList() : new List<InquiryDto>(),
                    StatusId = a.StatusId,
                    Notes = a.Notes,
                    Modified = a.Modified,
                    IsDeleted = a.IsDeleted
                })
                .ToListAsync();
        }


        public async Task<ApplicationDto> GetById(int id)
        {
            var application = await _context.Applications
                .Include(a => a.StatusLevel)   
                .Include(a => a.Inquiries)    
                .FirstOrDefaultAsync(a => a.Id == id);

            if (application == null)
            {
                return null; 
            }

            return new ApplicationDto
            {
                Id = application.Id,
                AppStatus = application.AppStatus,
                ProjectRef = application.ProjectRef,
                ProjectName = application.ProjectName,
                ProjectLocation = application.ProjectLocation,
                OpenDt = application.OpenDt,
                StartDt = application.StartDt,
                CompletedDt = application.CompletedDt,
                ProjectValue = application.ProjectValue,
                StatusLevel = application.StatusLevel != null ? new StatusLevelDto
                {
                    Id = application.StatusLevel.Id,
                    StatusName = application.StatusLevel.StatusName
                }:null,
                Inquiries = application.Inquiries != null ? application.Inquiries.Select(i => new InquiryDto
                {
                    Id = i.Id,
                    ApplicationId = i.ApplicationId,
                    SendToPerson = i.SendToPerson,
                    SendToRole = i.SendToRole,
                    SendToPersonId = i.SendToPersonId,
                    Subject = i.Subject,
                    InquiryText = i.InquiryText,
                    Response = i.Response,
                    AskedDt = i.AskedDt,
                    CompletedDt = i.CompletedDt
                }).ToList() : new List<InquiryDto>(),
                StatusId = application.StatusId,
                Notes = application.Notes,
                Modified = application.Modified,
                IsDeleted = application.IsDeleted
            };
        }

        public async Task Add(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Application application)
        {
            _context.Entry(application).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application != null)
            {
                _context.Applications.Remove(application);
                await _context.SaveChangesAsync();
            }
        }
    }

}


using System;
using System.Net.NetworkInformation;
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
                .AsNoTracking()
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
                .AsNoTracking()
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
            Application newApplication = new Application()
            {
                AppStatus = "New",
                ProjectRef = Guid.NewGuid().ToString("N").Substring(0, 6),   // Unique reference code for each application
                ProjectName = application.ProjectName,
                ProjectLocation = application.ProjectLocation,
                OpenDt = DateTime.Now,
                ProjectValue = application.ProjectValue,
                StatusId = 1,
                Notes = application.Notes,
                IsDeleted = false
            };
            _context.Applications.Add(newApplication);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Application application)
        {
            var app = await _context.Applications.FirstOrDefaultAsync(x=>x.Id==application.Id);
            if (app != null)
            {
                app.Modified = DateTime.Now;
                app.AppStatus = application?.StatusLevel != null
                                ? StatusHelper.GetStatusName(application.StatusLevel.Id)
                                : app.AppStatus;
                app.ProjectName = application?.ProjectName;
                app.ProjectLocation = application?.ProjectLocation;
                app.ProjectValue = application?.ProjectValue;
                app.Notes = application?.Notes;
                app.StartDt = application?.StatusLevel?.Id != 4 ? DateTime.Now : null; // When the status changes to 4 (In Progress), it indicates that the application has started
                app.StatusId = application?.StatusLevel?.Id ?? app.StatusId;
            }
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
            /*
             Codes for soft delete are here:

            var application = await _context.Applications.FindAsync(id);
            if (application != null)
            {
                application.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            */
        }
    }

}


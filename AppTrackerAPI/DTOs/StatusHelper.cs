using System;
namespace AppTrackerAPI.DTOs
{
    public static class StatusHelper
    {
        public static string GetStatusName(int statusId)
        {
            return Enum.GetName(typeof(StatusLevel), statusId) ?? "Unknown";
        }
    }

    public enum StatusLevel
    {
        New = 1,
        AwaitingPreChecks = 2,
        Approved = 3,
        InProgress = 4,
        Completed = 5,
        SiteIssues = 6,
        AdditionalDocumentsRequired = 7,
        NewQuotesRequired = 8,
        Closed = 9
    }

}


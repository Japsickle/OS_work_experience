using Microsoft.Graph;
using System;
using System.Collections.Generic;

namespace MeetingAvailabilityChecker
{
    public class CalendarViewerPort
    {
        private GraphServiceClient _graphServiceClient;
        public CalendarViewerPort(GraphServiceClient client)
        {
            _graphServiceClient = client;
        }

        public MeetingTimeSuggestionsResult GetMeetingTime(List<AttendeeBase> listOfAttendees, string earliestMeetingStartDateTime, string latestMeetingEndDateTime, string meetingDuration)
        {
            TimeZoneInfo currentTimeZone = TimeZoneInfo.Local;
            List<AttendeeBase> osEmployees = listOfAttendees;
            
            TimeConstraint timeConstraint = new TimeConstraint
            {
                ActivityDomain = ActivityDomain.Work,
                TimeSlots = new List<TimeSlot>()
                {
                    new TimeSlot
                    {
                        Start = new DateTimeTimeZone
                        {
                            DateTime = earliestMeetingStartDateTime,
                            TimeZone = "GMT Standard Time"
                        },
                        End = new DateTimeTimeZone
                        {
                            DateTime = latestMeetingEndDateTime,
                            TimeZone = "GMT Standard Time"
                        }
                    }
                }
            };

            Duration meetingTime = new Duration($"PT{meetingDuration}M");

            double minimumAttendeePercentage = (double)100;

            MeetingTimeSuggestionsResult response = _graphServiceClient.Me
            .FindMeetingTimes(attendees: osEmployees, timeConstraint: timeConstraint, meetingDuration: meetingTime, maxCandidates: 15, minimumAttendeePercentage: minimumAttendeePercentage)
            .Request()
            .Header("Prefer", $"outlook.timezone=\"GMT Standard Time\"")
            .PostAsync()
            .Result;

            return response;
        } 
    }
}

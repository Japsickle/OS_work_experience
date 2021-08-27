using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetingAvailabilityChecker
{
    public class MeetingCollection
    {
        public List<OSMeeting> ListOfMeetings { get; set; }

        public MeetingCollection(MeetingTimeSuggestionsResult response)
        {
            ListOfMeetings = TranslateMicrosoftMeetingsIntoOSMeetings(response);
        }

        private List<OSMeeting> TranslateMicrosoftMeetingsIntoOSMeetings(MeetingTimeSuggestionsResult response)
        {
            List<MeetingTimeSuggestion> microsoftMeetingTimes = response.MeetingTimeSuggestions.ToList();

            List<OSMeeting> listOfMeetings = new List<OSMeeting>();
            foreach (MeetingTimeSuggestion microsoftMeeting in microsoftMeetingTimes)
            {
                OSMeeting osMeeting = new OSMeeting(microsoftMeeting.MeetingTimeSlot.Start.DateTime, microsoftMeeting.MeetingTimeSlot.End.DateTime);

                listOfMeetings.Add(osMeeting);
            }
            return listOfMeetings;
        }
    }

    public class OSMeeting
    {
        public OSMeeting(string startTime, string endTime)
        {
            StartTime = DateTime.Parse(startTime);
            EndTime = DateTime.Parse(endTime);
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
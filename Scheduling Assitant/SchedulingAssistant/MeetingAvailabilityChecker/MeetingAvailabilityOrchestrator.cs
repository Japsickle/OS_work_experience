using Microsoft.Graph;
using System.Collections.Generic;

namespace MeetingAvailabilityChecker
{
	public class MeetingAvailabilityOrchestrator
	{
		public MeetingCollection GetMeetingAvailability(List<AttendeeBase> listOfAttendees, string earliestMeetingStartDateTime, string latestMeetingEndDateTime, string meetingDuration)
		{
            Authenticator authenticator = new Authenticator();
			GraphServiceClient client = authenticator.GetGraphServiceClient();
           
            CalendarViewerPort calendarViewerPort = new CalendarViewerPort(client);
			MeetingTimeSuggestionsResult response = calendarViewerPort.GetMeetingTime(listOfAttendees, earliestMeetingStartDateTime, latestMeetingEndDateTime, meetingDuration);

            MeetingCollection collection = new MeetingCollection(response);

			return collection;
		}
	}
}

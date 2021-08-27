using MeetingAvailabilityChecker;
using System;
using System.Collections.Generic;

namespace SchedulingAssistant
{
    class MoreMeetingTimes
    {
        public bool AskUserIfTheyWantMoreMeetingTimes()
        {
            Console.WriteLine("Would you like more meeting times to be presented?\nPress 'Y' for more meeting times\nOr press 'N' to exit\n-> ");
            string userChoice = Console.ReadLine().ToUpper();
            bool userWantsMoreMeetings = true;

            if (userChoice == "Y")
            {
                userWantsMoreMeetings = true;
            }
            else if (userChoice == "N")
            {
                userWantsMoreMeetings = false;
            }

            return userWantsMoreMeetings;
        }

        public void PresentMoreMeetingsToUser(bool userWantsMoreMeetings, List<OSMeeting> listOfMeetings)
        {

            if (userWantsMoreMeetings)
            {
                Console.WriteLine("The following meeting are also available ->\n");
                foreach (OSMeeting oSMeeting in listOfMeetings)
                {
                    Console.WriteLine($"starting time: {oSMeeting.StartTime}\nending time: {oSMeeting.EndTime}\n");
                }
            }
        }
    }
}

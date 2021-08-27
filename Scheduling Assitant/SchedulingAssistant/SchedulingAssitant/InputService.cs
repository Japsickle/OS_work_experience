using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SchedulingAssistant
{
    public class GetInitialUserInputsService
    {
        private DateTimeFormatter _dateTimeFormatter;
        private AttendeeHelper _attendeeHelper;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string MeetingDuration { get; private set; }
        public string EarliestMeetingStartDateTime { get; private set; }
        public string LatestMeetingEndDateTime { get; private set; }
        public GetInitialUserInputsService()
        {
            _dateTimeFormatter = new DateTimeFormatter();
            _attendeeHelper = new AttendeeHelper();
        }

        public void GetUserInputs()
        {
            Console.WriteLine("Press T to access calendar or M to input datetime for meeting");
            string loginChoice = Console.ReadLine().ToUpper();
            while (loginChoice != "T" && loginChoice != "M")
            {
                Console.WriteLine("Error. You haven't put in a T or an M\nPress T to access calendar or M to input datetime for meeting");
                loginChoice = Console.ReadLine().ToUpper();
            }
            if (loginChoice == "T")
            {
                string earliestMeetingStartDate = DateTime.Today.AddDays(7).ToString("dd/MM/yyyy");
                string earliestMeetingStartTime = "09:00";
                EarliestMeetingStartDateTime = _dateTimeFormatter.DateTimeFormat(earliestMeetingStartDate, earliestMeetingStartTime);
                string latestMeetingEndDate = DateTime.Today.AddDays(14).ToString("dd/MM/yyyy");
                string latestMeetingEndTime = "17:00";
                LatestMeetingEndDateTime = _dateTimeFormatter.DateTimeFormat(latestMeetingEndDate, latestMeetingEndTime);
                MeetingDuration = "60";
            }
            else if (loginChoice == "M")
            {
                GetMeetingDetailsFromConsoleInput();
            }

            DisplayInputs();
        }

        private void GetMeetingDetailsFromConsoleInput()
        {
            //Earliest Date and Time
            Console.WriteLine("When is the earliest date and time that the meeting could start?\n(e.g. 23/07/2021 13:00)\n-> ");
            string earliestMeetingStartDateTime = Console.ReadLine();

            DateTime earliestMeetingStartDateTimeResult;
            while (!DateTime.TryParse(earliestMeetingStartDateTime, out earliestMeetingStartDateTimeResult))
            {
                Console.WriteLine("Error. You have input the earliestMeetingStartDate in an invalid format (example of the correct format to use -> 23/07/2021 13:00\nWhen is the earlist date the meeting could start?\n(e.g. 23/07/2021)\n-> ");
                earliestMeetingStartDateTime = Console.ReadLine();
            }
            EarliestMeetingStartDateTime = _dateTimeFormatter.DateTimeFormat(earliestMeetingStartDateTimeResult.ToShortDateString(), earliestMeetingStartDateTimeResult.ToShortTimeString());

            //Latest Date and Time
            Console.WriteLine("When is the latest date and time that the meeting could end?\n(e.g. 23/07/2021 16:00)\n-> ");
            string latestMeetingEndDate = Console.ReadLine();

            DateTime latestMeetingEndDateResult;
            while (!DateTime.TryParse(latestMeetingEndDate, out latestMeetingEndDateResult))
            {
                Console.WriteLine("Error. You have input the latestMeetingEndDate in an invalid format (example of the correct format to use -> 23/07/2021\nWhen is the latest date the meeting could end?\n(e.g. 23/07/2021)\n->");
                latestMeetingEndDate = Console.ReadLine();
            }
            LatestMeetingEndDateTime = _dateTimeFormatter.DateTimeFormat(latestMeetingEndDateResult.ToShortDateString(), latestMeetingEndDateResult.ToShortTimeString());

            //Meeting Duration
            Console.WriteLine("How long do you want the meeting to last?\n(In minutes)\n-> ");
            MeetingDuration = Console.ReadLine();

            int MeetingDurationResult;
            while (!int.TryParse(MeetingDuration, out MeetingDurationResult))
            {
                Console.WriteLine("Error. You have written the meeting duration in an invalid format (example of the format that is valid -> 60)\nHow long do you want the meeting to last?\n(In minutes)\n->");
                MeetingDuration = Console.ReadLine();
            }
        }

        private void DisplayInputs()
        {
            Console.WriteLine($"Earliest date and time that the meeting can start is {EarliestMeetingStartDateTime}");
            Console.WriteLine($"Latest date and time that the meeting can end is {LatestMeetingEndDateTime}");
            Console.WriteLine($"Your meeting will be {MeetingDuration} minutes long");
        }

        public void AddMoreAttendeesToTheMeet()
        {
            char carryOn;
            do
            {
                try
                {
                    char loginchoice = Char.Parse(AskUser($"Press 'E' if you would like to enter a email\nPress 'N' if you would like to enter a first name and last name\n->", "upper"));
                    string email = getEmail(loginchoice);
                    if (EmailValidator(email))
                    {
                        _attendeeHelper.AddAttendee(email);
                    }
                    else
                    {
                        Console.WriteLine($"{email} is not valid\n");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid choice");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error - {e}");
                }
                Char.TryParse(AskUser($"Would you like to add another attendee? Press Y to carry on adding attendees, press N to stop adding attendees \n->", "upper"), out carryOn);
            } while( carryOn != 'N');
        }

        private string getEmail(char loginchoice)
        {
            if (loginchoice == 'E')
            {
                return AskUser("Supply a single email address\n->", "lower");
            }
            else if (loginchoice == 'N')
            {
                string firstname = AskUser("Supply a single first name\n->", "lower");
                string lastname = AskUser("Supply a single last name\n->", "lower");
                return $"{firstname}.{lastname}@os.uk";
            }
            return null;
        }

        private string AskUser(string prompt, string tocase)
        {
            Console.WriteLine(prompt);
            if (tocase == "upper")
            {
                return Console.ReadLine().ToUpper();
            }
            else if (tocase == "lower")
            {
                return Console.ReadLine().ToLower();
            }
            else
            {
                return Console.ReadLine();
            }
        }

        private bool EmailValidator(string email)
        {
            Regex regex = new Regex(@"^\w+\.\w+@os.uk$");
            return regex.Match(email).Success;
        }

        public List<AttendeeBase> GetListOfAttendees()
        {
            return _attendeeHelper.GetAttendees();
        }
    }
}
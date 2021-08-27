using Microsoft.Graph;
using System.Collections.Generic;

namespace SchedulingAssistant
{
    class AttendeeHelper
    {
        private List<AttendeeBase> _attendees;
        public AttendeeHelper()
        {
            _attendees = new List<AttendeeBase>();
        }

        public List<AttendeeBase> GetAttendees()
        {
            return _attendees;
        }

        public void AddAttendee(string email)
        {
            AttendeeBase thisAttendee = new AttendeeBase();
            EmailAddress thisEmail = new EmailAddress();
            thisEmail.Address = email;
            thisAttendee.EmailAddress = thisEmail;
            _attendees.Add(thisAttendee);
        }
    }
}

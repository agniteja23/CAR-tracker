using System;

namespace Car_Tracker
{
    public delegate void NotificationEventHandler(string message);

    public class Events
    {
        public event NotificationEventHandler? Event;

        protected void Notify(string message)
        {
            var handler = Event;
            if (handler != null)
            {
                handler(message);
            }
        }
    }
}
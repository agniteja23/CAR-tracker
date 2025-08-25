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

    public class Tasks : Events
    {
        public virtual int insert()
        {
            Notify("Insert operation not implemented.");
            return 0;
        }

        public virtual void GetCarsByYear(int year)
        {
            Notify("GetCarsByYear operation not implemented.");
        }

        public virtual void removeCar(string carName)
        {
            Notify("Remove operation not implemented.");
        }

        public virtual void details()
        {
            Notify("Details operation not implemented.");
        }

        public virtual void updateStatus(int statusOption, string carName)
        {
            Notify("Update status operation not implemented.");
        }

        public virtual void saveAndExit()
        {
            Notify("Save and exit operation not implemented.");
        }
    }
}


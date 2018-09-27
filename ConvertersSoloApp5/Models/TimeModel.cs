using System;
using System.ComponentModel;
using Windows.ApplicationModel;

namespace Models
{
    public class TimeModel : INotifyPropertyChanged
    {
        //Initialize someDateTime with a default value
        private DateTime someDateTime = DateTime.Parse("07/21/1969 2:56AM");
        public DateTime SomeDateTime
        {
            get { return someDateTime; }
            set
            {
                someDateTime = value;
                OnPropertyChanged("SomeDateTime");
            }
        }

        public TimeSpan SomeDateTimeTimeSpanProxy
        {
            get
            {
                //Extract timespan from orig datetime
                return someDateTime - someDateTime.Date;
            }
            set
            {
                //check if timespan is different from current value
                if (SomeDateTimeTimeSpanProxy != value)
                {
                    //If it is, set the original datetime
                    //to the original date, plus the new timespan value
                    SomeDateTime = someDateTime.Date.Add(value);
                    //Raise the PropertyChanged event for the timespan property
                    OnPropertyChanged("SomeDateTimeTimeSpanProxy");          
                }
            }
        }

        private string splayTime;
        public string sPlayTime
        {
            get
            {             
               return tsPlayTime.ToString("T");            
             }
            set
            {
                splayTime = value;
                OnPropertyChanged("sPlayTime");
            }
        }

        private TimeSpan tsplayTime;
        public TimeSpan tsPlayTime
        {        
            get
            {               
                return tsPlayTime;
            }
            set
            {
                tsplayTime = value;
                OnPropertyChanged("tsPlayTime");             
            }
        }

        public TimeModel()
        {
            TimeSpan ts = new TimeSpan(22, 54, 33);
            if (DesignMode.DesignModeEnabled)
            {
                tsPlayTime = ts;
                sPlayTime = ts.ToString("T");
            }
            sPlayTime = ts.ToString("T");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}

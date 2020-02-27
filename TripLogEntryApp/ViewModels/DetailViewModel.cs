using System;
using TripLogEntryApp.Interfaces;
using TripLogEntryApp.Models;

namespace TripLogEntryApp.ViewModels
{
    public class DetailViewModel:BaseViewModel<TripLogEntry>
    {
        TripLogEntry _entry;
        public TripLogEntry Entry
        {
            get => _entry;
            set
            {
                _entry = value;
                OnPropertyChanged();
                
            }
        }
        public DetailViewModel(INavService navService):base(navService)
        {
            //Entry = entry;
        }

        public override void Init(TripLogEntry parameter)
        {
            Entry = parameter;
        }
    }
}

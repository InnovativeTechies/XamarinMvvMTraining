﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TripLogEntryApp.Interfaces;

namespace TripLogEntryApp.ViewModels
{
    public class BaseViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected INavService NavService { get; set; }
        bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }
        public BaseViewModel(INavService navService)
        {
            NavService = navService;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Init()
        {

        }
    }
    public class BaseViewModel<TParameter> : BaseViewModel
    {
        protected BaseViewModel(INavService navService):base(navService)
        {
        }
        public override void Init()
        {
            Init(default(TParameter));
        }
        public virtual void Init(TParameter parameter)
        {
        }
    }
}

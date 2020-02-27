﻿using System;
using System.ComponentModel;
using System.Threading.Tasks;
using TripLogEntryApp.ViewModels;

namespace TripLogEntryApp.Interfaces
{
    public interface INavService
    {
        bool CanGoBack { get; }
        Task GoBack();
        Task NavigateTo<TVM>()
            where TVM : BaseViewModel;
        Task NavigateTo<TVM, TParameter>(TParameter parameter)
            where TVM : BaseViewModel;
        void RemoveLastView();
        void ClearBackStack();
        void NavigateToUri(Uri uri);
        event PropertyChangedEventHandler CanGoBackChanged;
    }
}

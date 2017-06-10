using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using UwpApp.DataAccess.Repositories;
using UwpApp.Models;
using UwpApp.Services;

namespace UwpApp.ViewModels
{
    public class DetailsPageViewModel : ViewModelBase
    {
        private readonly IDataProviderService<City> _dataProviderService;
        private readonly IRepository<City> _repository;
        private readonly INavigationService _navigationService;

        public City SelectedCity => _dataProviderService.SelectedCity != null ? _dataProviderService.SelectedCity : null;

        public ICommand TappedRatingCommand { get; private set; }

        public int StarsValue
        {
            get { return _startValue == 0 ? _dataProviderService.SelectedCity.Stars : _startValue; }
            set
            {
                _startValue = value;
                _dataProviderService.SelectedCity.Stars = value;
                RaisePropertyChanged("StarsValue");             
            }
        }

        private int _startValue;

        public string ImageSrc => GetImagePath(_dataProviderService.SelectedCity.Name);

        public DetailsPageViewModel(IDataProviderService<City> dataProviderService, IRepository<City> repository, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _dataProviderService = dataProviderService;
            _repository = repository;

            TappedRatingCommand = new RelayCommand(() =>
            {
                _repository.Update(SelectedCity);
                _startValue = 0;
                _navigationService.GoBack();
            });
        }      

        private string GetImagePath(string imageName)
        {
            return string.Format("/{0}.jpg", imageName);
        }

    }
}

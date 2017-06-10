using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using UwpApp.Models;
using UwpApp.Services;
using UwpApp.DataAccess.Repositories;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.Gaming.Input.ForceFeedback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using GalaSoft.MvvmLight.Views;

namespace UwpApp.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        private readonly IDataProviderService<City> _dataProviderService;
        private readonly IRepository<City> _reposiotry;
        private readonly INavigationService _navigationService;

        public StartPageViewModel(IDataProviderService<City> dataProviderService, IRepository<City> repository, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _dataProviderService = dataProviderService;
            _reposiotry = repository;
            ListOfCities = new ObservableCollection<City>();
            LoadingDataProgressRingVisibility = true;
            DownloadData();
            GetMoreCityDetailsCommand = new RelayCommand<TappedRoutedEventArgs>(GetMoreCityDeatailsAction);
        }

        public ICommand GetMoreCityDetailsCommand { get; private set; }

        private ObservableCollection<City> _listOfCities;
        public ObservableCollection<City> ListOfCities
        {
            get { return _listOfCities; }
            set {
                _listOfCities = value;
                RaisePropertyChanged("ListOfCities");
            }
        }

        private bool _errorInternetVisibility;
        public bool ErrorInternetVisibility
        {
            get { return _errorInternetVisibility; }
            set
            {
                _errorInternetVisibility = value;
                RaisePropertyChanged("ErrorInternetVisibility");
            }
        }


        private bool _loadingDataProgressRingVisibility;
        public bool LoadingDataProgressRingVisibility
        {
            get { return _loadingDataProgressRingVisibility; }
            set
            {
                _loadingDataProgressRingVisibility = value;
                RaisePropertyChanged("LoadingDataProgressRingVisibility");
            }
        }


        private async void DownloadData()
        {
            var listOfCities = await _dataProviderService.GetJson();
            await _reposiotry.Create(listOfCities);
            LoadListOfCities();
            DownloadImages(listOfCities);

        }

        private async void DownloadImages(List<City> listOfCities)
        {
            if (listOfCities == null)
                return;
            await _dataProviderService.DownloadImages(listOfCities);
        }

        private void GetMoreCityDeatailsAction(TappedRoutedEventArgs e)
        {
            dynamic listViewItem = e.OriginalSource as TextBlock;
            if (listViewItem == null)
                listViewItem = e.OriginalSource as ListViewItemPresenter;
            var city = listViewItem.DataContext as City;
            _dataProviderService.SelectedCity = _reposiotry.Read(city?.Id);
            _navigationService.NavigateTo("DetailsPage");
        }

        private async void LoadListOfCities()
        {
            var listOfCitiesFromRepo = await _reposiotry.ReadAll();
            ErrorInternetVisibility = listOfCitiesFromRepo.Count == 0;
            LoadingDataProgressRingVisibility = false;
            foreach (var city in listOfCitiesFromRepo)
            {
                ListOfCities.Add(city);
            }

        }

    }
}

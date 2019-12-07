using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Labb4_Nations
{
    class MainViewModel : SimpleViewModel
    {       
        private Country currentCountry;       
        private List<Country> Countries { get; }       
        public Country SelectedCountry
        {
            get => currentCountry;
            set => SetPropertyValue(ref currentCountry, value);
        }

        public ICommand NextButtonCommand { get; }
        public ICommand PreviousButtonCommand { get; }
        public MainViewModel()
        {
            CountryRepository countryRepository = new CountryRepository();
            Countries = countryRepository.GetCountries();
            int index = new int();
            SelectedCountry = Countries[index];
            
             NextButtonCommand = new Command(() =>
            {
                _ = index < Countries.Count-1 ? index++ : index = Countries.Count-1;
                SelectedCountry = Countries[index]; 
            });

            PreviousButtonCommand = new Command(() =>
            {
                _ = index < 1 ? index = 0 : index--;              
                SelectedCountry = Countries[index];               
            });
        }
    }
}

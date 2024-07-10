using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Net.Http;
using Newtonsoft.Json;
using Quezada_Evaluacion3P.Models;
using Quezada_Evaluacion3P.Services;
//using Android.Net;

namespace Quezada_Evaluacion3P.ViewModels
{
    public class AQGameViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<AQGame> games;
        public ObservableCollection<AQGame> Games
        {
            get => games;
            set
            {
                games = value;
                OnPropertyChanged();
            }
        }

        public AQGameViewModel()
        {
            LoadGames();
        }

        private async void LoadGames()
        {
            var apiService = new AQApiService();
            Games = new ObservableCollection<AQGame>(await apiService.GetGames());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

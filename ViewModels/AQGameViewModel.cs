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
using Microsoft.Maui.Controls;
using System.Windows.Input;
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

        private ObservableCollection<AQGame> savedGames;
        public ObservableCollection<AQGame> SavedGames
        {
            get => savedGames;
            set
            {
                savedGames = value;
                OnPropertyChanged();
            }
        }

        private AQGame selectedGame;
        public AQGame SelectedGame
        {
            get => selectedGame;
            set
            {
                selectedGame = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadGamesCommand { get; }
        public ICommand SaveGameCommand { get; }

        public AQGameViewModel()
        {
            LoadGamesCommand = new Command(LoadGames);
            SaveGameCommand = new Command(SaveGame, () => SelectedGame != null);
            LoadSavedGames();
        }

        private async void LoadGames()
        {
            var apiService = new AQApiService();
            Games = new ObservableCollection<AQGame>(await apiService.GetGames());
        }

        private async void SaveGame()
        {
            if (SelectedGame != null)
            {
                await App.Database.SaveGameAsync(SelectedGame);
                LoadSavedGames();
            }
        }

        private async void LoadSavedGames()
        {
            SavedGames = new ObservableCollection<AQGame>(await App.Database.GetGamesAsync());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
﻿using BoogleClient.BoggleServices;
using BoogleClient.Commands;
using BoogleClient.Services;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace BoogleClient.ViewModel
{
    internal class LobbyCreationViewModel : BoggleServiceCallback
    {
        private readonly NavigationService navigationService;
        private readonly AccountDTO userAccount;
        private LobbySettingsDTO lobbySettings;

        public LobbyCreationViewModel(
            NavigationService navigationService,
            AccountDTO userAccount, int[] roomSizes,
            string[] gameModes, string[] privacies)
        {
            this.navigationService = navigationService;
            this.userAccount = userAccount;


            LobbySettings = new LobbySettingsDTO
            {
                GameMode = gameModes[0],
                NumberOfPlayers = roomSizes[0],
                LobbyPrivacy = privacies[1],
                Language = GetCurrentLanguage(),
                CreatorUserName = userAccount.UserName
            };

            ScrollPreviousGameMode =
                new ScrollPreviousGameModeCommand(this, gameModes);
            ScrollNextGameMode =
                new ScrollNextGameModeCommand(this, gameModes);
            ScrollPreviousNumberOfPlayers =
                new ScrollPreviousNumberOfPlayersCommand(this, roomSizes);
            ScrollNextNumberOfPlayers =
                new ScrollNextNumberOfPlayersCommand(this, roomSizes);
            ChangeLobbyPrivacy =
                new ChangeLobbyCommand(this, privacies);
            CancelCommand =
                new NavigateCommand(navigationService, userAccount);
            CreateLobbyCommand =
                new CreateNewLobbyCommand(this);
        }

        private string GetCurrentLanguage()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            string currentLanguage = currentCulture.ToString();
            return currentLanguage;
        }

        public LobbySettingsDTO LobbySettings
        {
            get => lobbySettings;
            set
            {
                lobbySettings = value;
                OnPropertyChanged(nameof(LobbySettings));
            }
        }

        public ICommand CancelCommand { get; }

        public ICommand CreateLobbyCommand { get; }

        public ICommand ChangeLobbyPrivacy { get; }

        public ICommand ScrollPreviousGameMode { get; }

        public ICommand ScrollNextGameMode { get; }

        public ICommand ScrollPreviousNumberOfPlayers { get; }

        public ICommand ScrollNextNumberOfPlayers { get; }

        public override void JoinLobby()
        {
            MessageBox.Show("Lobby created successfuly", "It works!");
        }
    }
}
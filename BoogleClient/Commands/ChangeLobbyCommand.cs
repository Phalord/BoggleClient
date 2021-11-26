using BoogleClient.ViewModel;

namespace BoogleClient.Commands
{
    internal class ChangeLobbyCommand : BaseCommand
    {
        private readonly LobbyCreationViewModel lobbyCreationViewModel;
        private readonly string privatePrivacy;
        private readonly string publicPrivacy;

        public ChangeLobbyCommand(
            LobbyCreationViewModel lobbyCreationViewModel,
            string[] privacies)
        {
            this.lobbyCreationViewModel = lobbyCreationViewModel;
            privatePrivacy = privacies[1];
            publicPrivacy = privacies[0];
        }

        public override void Execute(object parameter)
        {
            if (lobbyCreationViewModel
                .LobbySettings.LobbyPrivacy.Equals(privatePrivacy))
            {
                lobbyCreationViewModel
                    .LobbySettings.LobbyPrivacy = publicPrivacy;
            }
            else
            {
                lobbyCreationViewModel
                    .LobbySettings.LobbyPrivacy = privatePrivacy;
            }
        }
    }
}

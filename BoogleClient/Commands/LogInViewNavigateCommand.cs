using BoogleClient.Stores;
using BoogleClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoogleClient.Commands
{
    internal class LogInViewNavigateCommand : BaseCommand
    {
        private readonly NavigationStore logInNavigationStore;
        private readonly Func<BaseViewModel> createViewModel;

        public LogInViewNavigateCommand(NavigationStore logInNavigationStore,
            Func<BaseViewModel> createViewModel)
        {
            this.logInNavigationStore = logInNavigationStore;
            this.createViewModel = createViewModel;
        }

        public override void Execute(object parameter)
        {
            logInNavigationStore.CurrentViewModel = createViewModel();
        }
    }
}

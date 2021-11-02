using BoogleClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoogleClient.Commands
{
    internal class NavigateCommand : BaseCommand
    {
        private MainViewModel mainViewModel;

        public NavigateCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}

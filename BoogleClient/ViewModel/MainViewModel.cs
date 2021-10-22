using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoogleClient.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            CurrentViewModel = new LogInViewModel();
            //CurrentViewModel = new MainMenuViewModel();
        }

        public BaseViewModel CurrentViewModel { get; set; }
    }
}

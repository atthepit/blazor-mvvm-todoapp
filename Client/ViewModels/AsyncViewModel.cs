using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoMvvmApp.Client.ViewModels
{
    public class AsyncViewModel : BaseViewModel
    {
        private int _asyncCount = 0;

        public bool Loading
        {
            get => _asyncCount > 0;
        }

        protected void StartAsyncOperation()
        {
            var cur = Loading;
            _asyncCount++;
            if (cur != Loading)
            {
                OnPropertyChanged(nameof(Loading));
            }
        }

        protected void EndAsyncOperation()
        {
            var cur = Loading;
            _asyncCount--;
            if (cur != Loading)
            {
                OnPropertyChanged(nameof(Loading));
            }
        }
    }
}

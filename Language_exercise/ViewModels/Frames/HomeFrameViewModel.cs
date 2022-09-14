using Language_exercise.Stores;

namespace Language_exercise.ViewModels.Frames
{
    public class HomeFrameViewModel : ViewModelBase
    {
        private NavigationStore store;

        public ViewModelBase CurrentViewModel => store.CurrentViewModel;

        public HomeFrameViewModel(NavigationStore store)
        {
            this.store = store;
        }
    }
}

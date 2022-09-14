using Language_exercise.Stores;

namespace Language_exercise.ViewModels.Frames
{
    public class SettingsFrameViewModel : ViewModelBase
    {
        private NavigationStore store;

        public ViewModelBase CurrentViewModel => store.CurrentViewModel;

        public SettingsFrameViewModel(NavigationStore store)
        {
            this.store = store;
        }
    }
}

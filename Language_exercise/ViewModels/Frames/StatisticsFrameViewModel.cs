using Language_exercise.Stores;

namespace Language_exercise.ViewModels.Frames
{
    public class StatisticsFrameViewModel : ViewModelBase
    {
        private NavigationStore store;

        public ViewModelBase CurrentViewModel => store.CurrentViewModel;

        public StatisticsFrameViewModel(NavigationStore store)
        {
            this.store = store;
        }
    }
}

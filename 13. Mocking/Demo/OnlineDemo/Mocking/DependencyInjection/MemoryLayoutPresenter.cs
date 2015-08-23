namespace DependencyInjection
{
    using DependencyInjection.Interfaces;

    public class MemoryLayoutPresenter : IPresenterBase
    {
        private IViewBase view;

        public MemoryLayoutPresenter(IViewBase view)
        {
            this.view = view;
        }
    }
}
namespace Blazor.Client.Services
{
    public class SideBarUpdateService
    {
        public event Action<bool>? OnSideBarUpdate;

        public void PublishSideBarUpdate(bool isActivateSideBar)
        {
            OnSideBarUpdate?.Invoke(isActivateSideBar);
        }
    }
}

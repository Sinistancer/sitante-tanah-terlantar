namespace Blazor.Client.Services
{
    public class BreadcrumbUpdateService
    {
        public event Action<string>? OnBreadcrumbUpdate;

        public void PublishBreadcrumbUpdate(string breadcrumb)
        {
            OnBreadcrumbUpdate?.Invoke(breadcrumb);
        }
    }
}

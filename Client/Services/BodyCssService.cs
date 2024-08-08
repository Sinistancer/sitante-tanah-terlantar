namespace Blazor.Client.Services
{
    public class BodyCssService
    {
        private HashSet<string> cssClasses = new HashSet<string>();

        public event Action? OnChange;

        public string CssClass
        {
            get { return string.Join(" ", cssClasses); }
        }

        public void AddClass(string className)
        {
            if (cssClasses.Add(className))
            {
                NotifyStateChanged();
            }
        }

        public void RemoveClass(string className)
        {
            if (cssClasses.Remove(className))
            {
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}

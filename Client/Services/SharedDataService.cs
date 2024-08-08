namespace Blazor.Client.Services
{
    public class SharedDataService
    {
        private bool _isActivateDropDownPPTT;
        private string _activeMenuItem;
        private string _activeMenuName;

        public bool IsActivateDropDownPPTT
        {
            get => _isActivateDropDownPPTT;
            set
            {
                _isActivateDropDownPPTT = value;
                NotifyActivateDropDownChanged?.Invoke(value);
            }
        }

        public event Action<bool> NotifyActivateDropDownChanged;

        public string ActiveMenuItem
        {
            get => _activeMenuItem;
            set
            {
                _activeMenuItem = value;
                NotifyActivateMenuItemChanged?.Invoke(value);
            }
        }

        public event Action<string> NotifyActivateMenuItemChanged;

        public string ActiveMenuName
        {
            get => _activeMenuName;
            set
            {
                _activeMenuName = value;
                NotifyActivateMenuNameChanged?.Invoke(value);
            }
        }

        public event Action<string> NotifyActivateMenuNameChanged;
    }
}

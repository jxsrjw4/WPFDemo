
using Prism.Regions;
using Refit;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using Unity;
using WPFDemo.Infrastructure;
using WPFDemo.Infrastructure.ServerInteraction;
using WPFDemo.ServerInteraction;

namespace WPFDemo
{
    public class LoginViewModel: ViewModelBase
    {
        private readonly INonAuthenticationApi _nonAuthenticationApi;
        private SignUpArgs _signUpArgs;
        private string _account;

        protected IConfigureFile ConfigureFile { get; }

        public string Account
        {
            get => _account;
            set => SetProperty(ref _account, value);
        }

        public IRegionManager _regionManager;
        public RelayCommand<PasswordBox> LoginInCommand { get; private set; }

        public LoginViewModel(IUnityContainer container,IRegionManager regionManager):base(container)
        {
            _regionManager = regionManager;
            _nonAuthenticationApi = Container.Resolve<INonAuthenticationApi>();
            ConfigureFile = Container.Resolve<IConfigureFile>();
            LoginInCommand = new RelayCommand<PasswordBox>(LoginIn, passwordBox => CanSignIn(Account, passwordBox.Password));

            EventAggregator.GetEvent<SignUpSuccessEvent>().Subscribe(signUpArgs => _signUpArgs = signUpArgs);
        }


        public async void LoginIn(PasswordBox password)
        {
            //var passwordMd5 = password.Password == ConfigureFile.GetValue<string>(ConfigureKeys.Password).DecryptByRijndael()
            //               ? password.Password
            //               : password.Password.ToMd5();
            var passwordMd5 = password.Password.ToMd5();
            await SignInAsync(Account, passwordMd5);
        }

        private async Task SignInAsync(string username, string passwordMd5)
        {
            EventAggregator.GetEvent<MainWindowLoadingEvent>().Publish(true);

            ShellSwitcher.Switch<LoginView, MainWindow>(_regionManager);
            return;
            if (!await AuthenticateAsync(username, passwordMd5))
            {
                EventAggregator.GetEvent<MainWindowLoadingEvent>().Publish(false);
                ConfigureFile.SetValue(ConfigureKeys.AutoSignIn, false);
                return;
            }

            //await Container.Resolve<ModuleResolver>().LoadAsync();

            // Saves data.
            ConfigureFile.SetValue(ConfigureKeys.Username, username);
            ConfigureFile.SetValue(ConfigureKeys.Password, string.Empty);
            ConfigureFile.SetValue(ConfigureKeys.AutoSignIn, false);

            // Launches main window and closes itself.
        }

        private async Task<bool> AuthenticateAsync(string username, string passwordMd5)
        {
            var result = await _nonAuthenticationApi.LoginAsync(new LoginArgs
            {
                Account = username,
                Password = passwordMd5
            }).RunApi();

            if (!result.Success) return false;

            var acceleriderApi = RestService.For<IAcceleriderApi>(AcceleriderUrls.ApiBaseAddress, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(result.AccessToken)
            });

            var user = await acceleriderApi.GetCurrentUserAsync().RunApi();

            if (user == null) return false;

            RegisterInstance(user, acceleriderApi);

            return true;
        }

        private void RegisterInstance(IAcceleriderUser user, IAcceleriderApi acceleriderApi)
        {
            Container.RegisterInstance(user);
            Container.RegisterInstance(acceleriderApi);
        }

        private static bool CanSignIn(string username, string password) => !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
    }
}

using BA.QLCN.Models;
using BA.QLCN.Service;
using BA.QLCN.Views.Layout;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Auth;
using Xamarin.Forms;

namespace BA.QLCN.ViewModels
{
    /// <summary>Viewmodel for login page</summary>
    /// <Modified>
    /// Name     Date         Comments
    /// quangnt2  16/03/2020   created
    /// </Modified>
    /// <seealso cref="BA.QLCN.ViewModels.BaseViewModel" />
    public class LoginViewModel : BaseViewModel
    {
        private IQuanLyService _quanlyService;
        private IPageService _pageService;
        public QuanLy QuanLy { get; set; }

        public ICommand LoginCommand { get; private set; }

        public LoginViewModel(IQuanLyService quanlyService, IPageService pageService)
        {
            _quanlyService = quanlyService;
            _pageService = pageService;

            LoginCommand = new Command(async () => await Login());
            QuanLy = new QuanLy();
        }


        /// <summary>Function for LoginCommand.</summary>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        private async Task Login()
        {
            if (string.IsNullOrEmpty(QuanLy.UserName) || string.IsNullOrEmpty(QuanLy.Password))
            {
                await _pageService.DisplayAlert("Cảnh báo", "Yêu cầu nhập đầy đủ thông tin.", "OK");
                return;
            }
            else
            {
                var result = _quanlyService.FindQuanLy(QuanLy.UserName, QuanLy.Password);

                if (result.Result != null)
                {
                    var quanly = new QuanLy()
                    {
                        ID = result.Result.ID,
                        UserName = result.Result.UserName,
                        Password = result.Result.Password
                    };
        
                    SaveCredentials(quanly.UserName, quanly.Password);
                    await _pageService.PushAsync(new _layout());
                }
                else
                {
                    await _pageService.DisplayAlert("Cảnh báo", "Sai thông tin đăng nhập.", "OK");
                    return;
                }
            }
        }


        /// <summary>Using xamarin.auth save login infomation</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public void SaveCredentials(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                Account account = new Account()
                {
                    Username = username
                };

                account.Properties.Add("password", password);
                AccountStore.Create().Save(account, Events.AppName);
            }
        }
    }
}

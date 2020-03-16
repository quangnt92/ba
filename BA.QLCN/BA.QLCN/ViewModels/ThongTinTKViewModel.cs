using BA.QLCN.Models;
using BA.QLCN.Service;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Auth;
using Xamarin.Forms;

namespace BA.QLCN.ViewModels
{
    /// <summary>Viewmodel for page ThongTinTK</summary>
    /// <Modified>
    /// Name     Date         Comments
    /// quangnt2  16/03/2020   created
    /// </Modified>
    public class ThongTinTKViewModel
    {
        public QuanLy QuanLy { get; set; }
        private IQuanLyService _quanlyService;
        private IPageService _pageService;
        public ICommand LogoutCommand { get; private set; }

        public ThongTinTKViewModel(IQuanLyService quanlyService, IPageService pageService)
        {
            _quanlyService = quanlyService;
            _pageService = pageService;
            var account = AccountStore.Create().FindAccountsForService(Events.AppName).FirstOrDefault();
            QuanLy = new QuanLy();

            if(account != null)
            {
                var data = _quanlyService.GetQuanLy(account.Username);

                QuanLy.UserName = data.Result.UserName;
                QuanLy.Password = data.Result.Password;
            }
            LogoutCommand = new Command(async () => await Logout());
        }

        private async Task Logout()
        {
            DeleteCredentials();
            await _pageService.PopAsync();
        }


        /// <summary>Deletes the credentials xamarin.auth.</summary>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public void DeleteCredentials()
        {
            var account = AccountStore.Create().FindAccountsForService(Events.AppName).FirstOrDefault();

            if (account != null)
            {
                AccountStore.Create().Delete(account, Events.AppName);
            }
        }
    }
}

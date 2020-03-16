using BA.QLCN.Persistence;
using BA.QLCN.Service;
using BA.QLCN.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BA.QLCN.Views.Layout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        /// <summary>Khởi tạo các service và viewmodel</summary>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public Login()
        {
            var quanlyService = new QuanLyService(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();

            ViewModel = new LoginViewModel(quanlyService, pageService);
            InitializeComponent();
        }    

        public LoginViewModel ViewModel
        {
            get { return BindingContext as LoginViewModel; }
            set { BindingContext = value; }
        }
    }
}
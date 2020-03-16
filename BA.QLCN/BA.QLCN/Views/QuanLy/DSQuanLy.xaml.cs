using BA.QLCN.Persistence;
using BA.QLCN.Service;
using BA.QLCN.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BA.QLCN.Views.QuanLy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DSQuanLy : ContentPage
    {
        /// <summary>Khởi tạo các service và viewmodel</summary>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>        
        public DSQuanLy()
        {
            var quanlyService = new QuanLyService(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();

            ViewModel = new DSQuanLyViewModel(quanlyService, pageService);

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }

        public DSQuanLyViewModel ViewModel
        {
            get { return BindingContext as DSQuanLyViewModel; }
            set { BindingContext = value; }
        }
    }
}
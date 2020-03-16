using BA.QLCN.Persistence;
using BA.QLCN.Service;
using BA.QLCN.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BA.QLCN.Views.QuanLy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThongTinTK : ContentPage
    {
        /// <summary>Khởi tạo các service và viewmodel</summary>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public ThongTinTK()
        {
            var quanlyService = new QuanLyService(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();

            ViewModel = new ThongTinTKViewModel(quanlyService, pageService);

            InitializeComponent();
        }

        public ThongTinTKViewModel ViewModel
        {
            get { return BindingContext as ThongTinTKViewModel; }
            set { BindingContext = value; }
        }
    }
}
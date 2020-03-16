using BA.QLCN.Persistence;
using BA.QLCN.Service;
using BA.QLCN.ViewModels;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BA.QLCN.Views.CongNhan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DSCongNhan : ContentPage
    {
        /// <summary>Khởi tạo các service và viewmodel</summary>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public DSCongNhan()
        {
            var congnhanService = new CongNhanService(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();

            ViewModel = new DSCongNhanViewModel(congnhanService, pageService);

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }

        public DSCongNhanViewModel ViewModel
        {
            get { return BindingContext as DSCongNhanViewModel; }
            set { BindingContext = value; }
        }

        #region SfListView
        internal int ItemIndex
        {
            get;
            set;
        }

        private void ListView_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            if (e.ItemIndex == 1)
                e.Cancel = true;
        }

        private void ListView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            if (e.SwipeOffset > 70)
                listView.ResetSwipe();
        }

        private void ListView_Swiping(object sender, SwipingEventArgs e)
        {
            if (e.ItemIndex == 1 && e.SwipeOffSet > 70)
                e.Handled = true;
        }
        #endregion

        #region Event Clicked
        private void btnRefresh_Clicked(object sender, System.EventArgs e)
        {
            keyword.Text = "";
            ViewModel.LoadDataCommand.Execute(null);
        }
        #endregion        
    }
}
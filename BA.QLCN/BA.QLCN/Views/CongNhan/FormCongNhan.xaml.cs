using BA.QLCN.Persistence;
using BA.QLCN.Service;
using BA.QLCN.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BA.QLCN.Views.CongNhan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormCongNhan : ContentPage
    {
        /// <summary>Khởi tạo các service và viewmodel</summary>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public FormCongNhan(CongNhanViewModel viewModel)
        {
            InitializeComponent();

            var congnhanService = new CongNhanService(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            Title = (viewModel.Phone == null) ? "Thêm mới công nhân" : "Sửa công nhân";
            BindingContext = new FormCongNhanViewModel(viewModel ?? new CongNhanViewModel(), congnhanService, pageService);
        }
    }
}
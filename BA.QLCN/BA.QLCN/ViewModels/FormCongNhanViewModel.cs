using System;
using BA.QLCN.Service;
using BA.QLCN.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace BA.QLCN.ViewModels
{
    /// <summary>Viewmodel for FormCongNhan page</summary>
    /// <Modified>
    /// Name     Date         Comments
    /// quangnt2  16/03/2020   created
    /// </Modified>
    public class FormCongNhanViewModel
    {
        private readonly ICongNhanService _congnhanService;
        private readonly IPageService _pageService;

        public CongNhan CongNhan { get; set; }
        public ICommand SaveCommand { get; set; }

        /// <summary>Initializes service, Command.</summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="congNhanService">The cong nhan service.</param>
        /// <param name="pageService">The page service.</param>
        /// <exception cref="ArgumentNullException">viewModel</exception>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public FormCongNhanViewModel(CongNhanViewModel viewModel, ICongNhanService congNhanService, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _congnhanService = congNhanService;

            SaveCommand = new Command(async () => await Save());

            CongNhan = new CongNhan()
            {
                ID = viewModel.Id,
                Name = viewModel.Name,
                Address = viewModel.Address,
                Phone = viewModel.Phone,
                Hobbit = viewModel.Hobbit,
                Birth = viewModel.Id > 0 ? viewModel.Birth : DateTime.Now,
                Gender = viewModel.Gender
            };
        }


        /// <summary>Function for SaveCommand: save item.</summary>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        async Task Save()
        {
            if (String.IsNullOrEmpty(CongNhan.Name))
            {
                await _pageService.DisplayAlert("Cảnh báo", "Yêu cầu nhập tên.", "OK");
                return;
            }
            if (CongNhan.ID == 0)
            {
                await _congnhanService.AddCongNhan(CongNhan);
                MessagingCenter.Send(this, Events.CongNhanAdded, CongNhan);
            }
            else
            {
                await _congnhanService.UpdateCongNhan(CongNhan);
                MessagingCenter.Send(this, Events.CongNhanUpdated, CongNhan);
            }

            await _pageService.PopAsync();
        }
    }
}

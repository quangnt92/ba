using BA.QLCN.Service;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using BA.QLCN.Views.CongNhan;
using BA.QLCN.Models;
using System.Linq;

namespace BA.QLCN.ViewModels
{
    /// <summary>Viewmodel for page DSCongNhan</summary>
    /// <Modified>
    /// Name     Date         Comments
    /// quangnt2  16/03/2020   created
    /// </Modified>
    /// <seealso cref="BA.QLCN.ViewModels.BaseViewModel" />
    public class DSCongNhanViewModel : BaseViewModel
    {
        private CongNhanViewModel _selected;
        private ICongNhanService _congnhanService;
        private IPageService _pageService;
        private bool _isDataLoaded;

        public ObservableCollection<CongNhanViewModel> CongNhans { get; private set; } = new ObservableCollection<CongNhanViewModel>();

        public CongNhanViewModel Selected
        {
            get { return _selected; }
            set { SetValue(ref _selected, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand SearchDataCommand { get; private set; }
        public ICommand AddCongNhanCommand { get; private set; }
        public ICommand SelectCongNhanCommand { get; private set; }
        public ICommand EditCongNhanCommand { get; private set; }
        public ICommand DeleteCongNhanCommand { get; set; }


        /// <summary>Initializes service, command, function for MessagingCenter.</summary>
        /// <param name="congnhanService">The congnhan service.</param>
        /// <param name="pageService">The page service.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public DSCongNhanViewModel(ICongNhanService congnhanService, IPageService pageService)
        {
            _congnhanService = congnhanService;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            SearchDataCommand = new Command<string>(async c => await SearchData(c));
            AddCongNhanCommand = new Command(async () => await AddCongNhan());
            SelectCongNhanCommand = new Command<CongNhanViewModel>(async c => await SelectCongNhan(c));
            DeleteCongNhanCommand = new Command<CongNhanViewModel>(async c => await DeleteCongNhan(c));

            MessagingCenter.Subscribe<FormCongNhanViewModel, CongNhan>
                (this, Events.CongNhanAdded, OnContactAdded);

            MessagingCenter.Subscribe<FormCongNhanViewModel, CongNhan>
            (this, Events.CongNhanUpdated, OnContactUpdated);
        }


        /// <summary>Subscribe message Events.CongNhanAdded from FormCongNhanViewModel.</summary>
        /// <param name="source">The source.</param>
        /// <param name="congnhan">The congnhan.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        private void OnContactAdded(FormCongNhanViewModel source, CongNhan congnhan)
        {
            CongNhans.Add(new CongNhanViewModel(congnhan));
        }

        /// <summary>Subscribe message Events.CongNhanUpdated from FormCongNhanViewModel.</summary>
        /// <param name="source">The source.</param>
        /// <param name="congnhan">The congnhan.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        private void OnContactUpdated(FormCongNhanViewModel source, CongNhan congnhan)
        {
            var item = CongNhans.Single(c => c.Id == congnhan.ID);

            item.Id = congnhan.ID;
            item.Name = congnhan.Name;
            item.Address = congnhan.Address;
            item.Phone = congnhan.Phone;
            item.Hobbit = congnhan.Hobbit;
            item.Birth = congnhan.Birth;
            item.Gender = congnhan.Gender;
        }


        /// <summary>Load data for BindingContext.</summary>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;
            var congnhans = await _congnhanService.GetCongNhansAsync("");

            foreach (var congnhan in congnhans)
            {
                CongNhans.Add(new CongNhanViewModel(congnhan));
            }
        }

        /// <summary>Get data by keyword.</summary>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        private async Task SearchData(string keyword)
        {
            CongNhans.Clear();

            var congnhans = await _congnhanService.GetCongNhansAsync(keyword);

            foreach (var congnhan in congnhans)
            {
                CongNhans.Add(new CongNhanViewModel(congnhan));
            }
        }

        /// <summary>Function for AddCongNhanCommand.</summary>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        private async Task AddCongNhan()
        {
            await _pageService.PushAsync(new FormCongNhan(new CongNhanViewModel()));
        }

        /// <summary>Function for SelectCongNhanCommand.</summary>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        private async Task SelectCongNhan(CongNhanViewModel congnhan)
        {
            if (congnhan == null)
                return;

            Selected = null;
            await _pageService.PushAsync(new FormCongNhan(congnhan));
        }

        /// <summary>Function for DeleteCongNhanCommand.</summary>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        private async Task DeleteCongNhan(CongNhanViewModel congnhanModel)
        {
            if(congnhanModel != null)
            {
                if (await _pageService.DisplayAlert("Cảnh báo", $"Bạn có chắc chắn muốn xóa công nhân {congnhanModel.Name}.", "Đồng ý", "Không"))
                {
                    CongNhans.Remove(congnhanModel);

                    var congnhan = await _congnhanService.GetCongNhan(congnhanModel.Id);
                    await _congnhanService.DeleteCongNhan(congnhan);
                }
            }            
        }
    }
}

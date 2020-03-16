using BA.QLCN.Models;
using BA.QLCN.Service;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BA.QLCN.ViewModels
{
    /// <summary>Viewmodel for page DSQuanLy</summary>
    /// <Modified>
    /// Name     Date         Comments
    /// quangnt2  16/03/2020   created
    /// </Modified>
    /// <seealso cref="BA.QLCN.ViewModels.BaseViewModel" />
    public class DSQuanLyViewModel : BaseViewModel
    {
        private IQuanLyService _quanlyService;
        private IPageService _pageService;
        private bool _isDataLoaded;
        public ObservableCollection<QuanLyViewModel> QuanLys { get; private set; } = new ObservableCollection<QuanLyViewModel>();
        public QuanLy QuanLy { get; set; }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddQuanLyCommand { get; private set; }
        public ICommand FindQuanLyCommand { get; private set; }

        /// <summary>Initializes service, command.</summary>
        /// <param name="congnhanService">The congnhan service.</param>
        /// <param name="pageService">The page service.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        public DSQuanLyViewModel(IQuanLyService quanlyService, IPageService pageService)
        {
            _quanlyService = quanlyService;
            _pageService = pageService;
            _isDataLoaded = false;

            LoadDataCommand = new Command(async () => await LoadData());
            AddQuanLyCommand = new Command(async () => await AddData());
            FindQuanLyCommand = new Command<string>(async c => await FindQuanLy(c));
            QuanLy = new QuanLy();
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
            var quanlys = await _quanlyService.GetQuanLysAsync();

            foreach (var quanly in quanlys)
            {
                QuanLys.Add(new QuanLyViewModel(quanly));
            }
        }

        /// <summary>Function for AddQuanLyCommand.</summary>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        private async Task AddData()
        {
            await _quanlyService.AddQuanLy(QuanLy);

            QuanLys.Add(new QuanLyViewModel(QuanLy));
        }

        /// <summary>Function for FindQuanLyCommand.</summary>
        /// <Modified>
        /// Name     Date         Comments
        /// quangnt2  16/03/2020   created
        /// </Modified>
        private async Task FindQuanLy(string userName)
        {
            await _quanlyService.GetQuanLy(userName);
        }
    }
}

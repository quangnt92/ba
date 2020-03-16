using BA.QLCN.Models;

namespace BA.QLCN.ViewModels
{
    /// <summary>Viewmodel for QuanLy</summary>
    /// <Modified>
    /// Name     Date         Comments
    /// quangnt2  16/03/2020   created
    /// </Modified>
    /// <seealso cref="BA.QLCN.ViewModels.BaseViewModel" />
    public class QuanLyViewModel : BaseViewModel
    {
        public int Id { get; set; }

        private string _username;
        public string UserName
        {
            get { return _username; }
            set
            {
                SetValue(ref _username, value);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                SetValue(ref _password, value);
            }
        }

        public QuanLyViewModel() { }

        public QuanLyViewModel(QuanLy quanly)
        {
            Id = quanly.ID;
            UserName = quanly.UserName;
            Password = quanly.Password;            
        }
    }
}

using BA.QLCN.Models;
using System;

namespace BA.QLCN.ViewModels
{
    /// <summary>Viewmodel for CongNhan</summary>
    /// <Modified>
    /// Name     Date         Comments
    /// quangnt2  16/03/2020   created
    /// </Modified>
    /// <seealso cref="BA.QLCN.ViewModels.BaseViewModel" />
    public class CongNhanViewModel : BaseViewModel
    {
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetValue(ref _name, value);
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                SetValue(ref _address, value);
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                SetValue(ref _phone, value);
            }
        }

        private string _hobbit;
        public string Hobbit
        {
            get { return _hobbit; }
            set
            {
                SetValue(ref _hobbit, value);
            }
        }

        private DateTime _birth;
        public DateTime Birth
        {
            get { return _birth; }
            set
            {
                SetValue(ref _birth, value);
            }
        }

        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set
            {
                SetValue(ref _gender, value);
            }
        }

        public CongNhanViewModel() { }

        public CongNhanViewModel(CongNhan congnhan)
        {
            Id = congnhan.ID;
            Name = congnhan.Name;
            Address = congnhan.Address;
            Phone = congnhan.Phone;
            Hobbit = congnhan.Hobbit;
            Birth = congnhan.Birth;
            Gender = congnhan.Gender;
        }
    }
}

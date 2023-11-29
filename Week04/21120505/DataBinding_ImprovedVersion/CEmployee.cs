using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingOneObject
{
    public class CEmployee : INotifyPropertyChanged, ICloneable
    {
        // properties
        private string _id; 
        private string _fullName;
        private string _email;
        private string _address;
        private string _phoneNumber;
        private string _avatar;

        public event PropertyChangedEventHandler? PropertyChanged;

        // others

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }

        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
            }
        }

        public string Avatar
        {
            get { return _avatar; }
            set
            {
                _avatar = value;
            }
        }

        // constructors
        public CEmployee ()
        {
            this._fullName = "";
            this._email = "";
            this._address = "";
            this._phoneNumber = "";
            this._avatar = "";
        }

        public CEmployee(string ID, string fullName, string email, string address, string phoneNumber, string avatar)
        {
            this._id = ID;
            this._fullName = fullName;
            this._email = email;
            this._address = address;
            this._phoneNumber = phoneNumber;
            this._avatar = avatar;
            
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

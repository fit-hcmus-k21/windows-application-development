using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingOneObject
{
    public class CPhone : INotifyPropertyChanged, ICloneable
    {
        //properties
        private string _id;
        private string _name;
        private string _img;
        private string _manufacturer;
        private int _price;

        public event PropertyChangedEventHandler? PropertyChanged;

        // others

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Image
        {
            get { return _img; }
            set { _img = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                _manufacturer = value;
            }
        }

        // constructors
        public CPhone()
        {
            this._name = "";
            this._img = "";
            this._manufacturer = "";
            this._price = 0;

        }

        public CPhone(string id, string name, string img, string manufacturer, int price)
        {
            _id = id;
            _name = name;
            _img = img;
            _manufacturer = manufacturer;
            _price = price;
           
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

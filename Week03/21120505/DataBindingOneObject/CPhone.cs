using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingOneObject
{
    internal class CPhone
    {
        //properties
        private string _name;
        private string _img;
        private string _manufacturer;
        private int _price;

        // others
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

        public CPhone(string name, string img, string manufacturer, int price)
        {
            _name = name;
            _img = img;
            _manufacturer = manufacturer;
            _price = price;
           
        }
    }
}

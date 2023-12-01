using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingOneObject
{
    public class CBook : INotifyPropertyChanged, ICloneable
    {
        // properties
        private int _id;
        private string _name;
        private string _coverImg;
        private string _author;
        private int _publishedYear;
        private int _price;

        public event PropertyChangedEventHandler? PropertyChanged;

        // others
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string CoverImg
        {
            get { return _coverImg; }
            set { _coverImg = value; }
        }

        public int PublishedYear
        {
            get { return _publishedYear; }
            set { _publishedYear = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Price { 
            get { return _price; }
            set { _price = value; }
       
        }

        // default constructor
        public CBook ()
        {
            _name = "";
            _coverImg = "assets/books/FileIcon.jpg";
            _author = "";
            _publishedYear = 2023; // default value
            _price = 0;
        }

        // constructor with params
        public CBook(int ID, string name, string coverImg, string author, int publishedYear, int price)
        {
            this._id = ID;
            this._name = name;
            this._coverImg = coverImg;
            this._author = author;
            this._publishedYear = publishedYear;
            this._price = price;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

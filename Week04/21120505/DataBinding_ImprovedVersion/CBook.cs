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
        private string _id;
        private string _name;
        private string _coverImg;
        private string _author;
        private int _publishedYear;

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

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        // default constructor
        public CBook ()
        {
            _id = "";
            _name = "";
            _coverImg = "";
            _author = "";
            _publishedYear = 2023; // default value
        }

        // constructor with params
        public CBook(string ID, string name, string coverImg, string author, int publishedYear)
        {
            this._id = ID;
            this._name = name;
            this._coverImg = coverImg;
            this._author = author;
            this._publishedYear = publishedYear;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

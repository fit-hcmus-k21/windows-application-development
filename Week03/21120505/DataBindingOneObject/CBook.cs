using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingOneObject
{
    internal class CBook
    {
        // properties
        private string _name;
        private string _coverImg;
        private string _author;
        private int _publishedYear;

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

        // default constructor
        public CBook ()
        {
            _name = "";
            _coverImg = "";
            _author = "";
            _publishedYear = 2023; // default value
        }

        // constructor with params
        public CBook(string name, string coverImg, string author, int publishedYear)
        {
            this._name = name;
            this._coverImg = coverImg;
            this._author = author;
            this._publishedYear = publishedYear;
        }
    }
}

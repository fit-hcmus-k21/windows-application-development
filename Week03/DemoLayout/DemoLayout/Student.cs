using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLayout
{
    public class Student : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        public string Avatar { get; set; }
        public int Tuition { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

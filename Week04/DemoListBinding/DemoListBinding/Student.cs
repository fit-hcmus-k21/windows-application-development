using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoListBinding
{
    public class Student : INotifyPropertyChanged, ICloneable
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int Credits { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            //var clone = new Student();
            //clone.ID = this.ID;
            //clone.Name = this.Name;
            //clone.Avatar = this.Avatar;

            return MemberwiseClone();
        }
    }
}

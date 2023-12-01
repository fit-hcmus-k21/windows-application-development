using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFraction
{
    public class FractionDao: IDao
    {
        private string _filename = "data.txt";
        public FractionDao() { }
        public override IDao CreateNew()
        {
            return new FractionDao();
        }

        public override BindingList<Fraction> GetAllFractions()
        {
            var result = new BindingList<Fraction>();

            var lines = File.ReadAllLines(_filename);

            for (int i = 1; i < lines.Length; i++)
            {
                Fraction f = Fraction.Parse(lines[i]);
                result.Add(f);
            }

            return result;
        }

        public override void Insert(Fraction f)
        {
            using (var writer = new StreamWriter(_filename, true))
            {
                writer.WriteLine(f.ToString());
            }
        }
    }
}

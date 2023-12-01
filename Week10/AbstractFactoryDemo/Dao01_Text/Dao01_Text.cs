using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using ThreeLayerContract;
using System.IO;

namespace DaoNamespace
{
    public class Dao01_Text : IDAO
    {
        public override List<Fraction> GetAll(string config)
        {
            var list = new List<Fraction>();
            var lines = File.ReadAllLines(config + ".txt");

            foreach (var line in lines)
            {
                if (line.Length > 0)
                {
                    list.Add(Fraction.Parse(line));
                }
            }

            return list;
        }

        public override bool Save(Fraction f, string config)
        {   
            File.AppendAllText(config + ".txt", "\r\n" + f.ToString() );

            return true;
        }

        public override string ToString()
        {
            return "Dao01 - Save Text";
        }
    }
}

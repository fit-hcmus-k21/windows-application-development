using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Entity;
using ThreeLayerContract;

namespace DaoNamespace
{
    public class Dao02_Xml : IDAO
    {
        public override List<Fraction> GetAll(string config)
        {
            var list = new List<Fraction>();

            var doc = XDocument.Load(config + ".xml");
            var root = doc.Element("Fractions");
            foreach (var node in root.Elements("Fraction"))
            {
                var f = Fraction.Parse(node.Value);
                list.Add(f);
            }

            return list;
        }

        public override bool Save(Fraction f, string config)
        {
            var filename = config + ".xml";
            var doc = XDocument.Load(filename);
            var root = doc.Element("Fractions");
            root.Add(new XElement("Fraction", f.ToString()));

            doc.Save(filename);

            return true;
        }

        public override string ToString()
        {
            return "Dao02 - Xml";
        }
    }
}

using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DemoFraction
{
    public class FractionXmlDao : IDao
    {
        private string _filename = "data.xml";
        public FractionXmlDao() { }

        public override IDao CreateNew()
        {
            return new FractionXmlDao();
        }

        public override BindingList<Fraction> GetAllFractions()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_filename);

            var result = new BindingList<Fraction>();
            var root = doc.DocumentElement;
            foreach ( XmlNode node in root.ChildNodes)
            {
                var text = node.InnerText;
                var f = Fraction.Parse(text);
                result.Add(f);
            }
            return result;
        }

        public override void Insert(Fraction f)
        {
            var doc = XDocument.Load(_filename);
            var root = doc.Element("Fractions");
            root.Add(new XElement("Fraction", f.ToString()));

            doc.Save(_filename);
        }
    }
}

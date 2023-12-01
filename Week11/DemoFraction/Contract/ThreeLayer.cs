
using System.ComponentModel;
using System.Windows.Controls;

namespace Contract
{
    public abstract class IGui
    {
        protected IBus _bus = null;
        public abstract UserControl GetMainWindow();
        public abstract IGui CreateNew(IBus bus);
    }

    public abstract class IBus
    {
        protected IDao _dao = null;

        public abstract BindingList<Fraction> GetAllFractions();
        public abstract void AddFraction(Fraction f);
        public abstract Fraction Add(Fraction a, Fraction b);

        public abstract IBus CreateNew(IDao dao);
    }

    public abstract class IDao
    {
        public abstract BindingList<Fraction> GetAllFractions();
        public abstract void Insert(Fraction f);
        public abstract IDao CreateNew();
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level02_AbstractFactoryPattern
{
    #region Machine
    abstract class IMachine
    {
        protected CPU _cpu;
        protected Ram _ram;
    }

    class NormalMachine : IMachine
    {
        public NormalMachine()
        {
            _cpu = CPUFactory.CreateCPU(Const.NORMAL);
            _ram = RamFactory.CreateRam(Const.NORMAL);
        }

        public override string ToString()
        {
            return "Normal machine. CPU: Normal, Ram: Normal";
        }
    }

    class HighEndMachine : IMachine
    {
        public HighEndMachine()
        {
            _cpu = CPUFactory.CreateCPU(Const.HIGHEND);
            _ram = RamFactory.CreateRam(Const.HIGHEND);
        }

        public override string ToString()
        {
            return "Highend machine. CPU: Highend, Ram: Highend";
        }
    }

    class MachineFactory
    {
        public static IMachine CreateMachine(int config)
        {
            if (config == Const.NORMAL) return new NormalMachine();
            return new HighEndMachine();
        }
    } 
    #endregion
    
    #region CPU
    abstract class CPU { }
    class NormalCPU : CPU { }
    class HighEndCPU : CPU { }
    class CPUFactory
    {
        public static CPU CreateCPU(int type)
        {
            if (type == Const.NORMAL) return new NormalCPU();
            return new HighEndCPU(); // (for short, should make switch) 
        }
    } 
    #endregion

    #region Ram
    abstract class Ram { }
    class NormalRam : Ram { }
    class HighEndRam : Ram { }
    class RamFactory
    {
        public static Ram CreateRam(int type)
        {
            if (type == Const.NORMAL) return new NormalRam();
            return new HighEndRam(); // (for short, should make switch) 
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {            
            Console.Write("Nhap cau hinh may muon tao, 1:NORMAL, 2: HIGHEND?");
            int config = int.Parse(Console.ReadLine());

            IMachine machine = MachineFactory.CreateMachine(config);
            Console.WriteLine(machine.ToString());
        }
    }
}

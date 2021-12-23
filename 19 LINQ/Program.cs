using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>()
            {
                new Computer(){Id=1,Mark="HP",Cpu="AMD",CpuFrequency=2.9,Ram=16,Rom=512,GpuMemory=4,Cost=70000,Count=1},
                new Computer(){Id=2,Mark="MSI",Cpu="Intel",CpuFrequency=4.2,Ram=32,Rom=2048,GpuMemory=8,Cost=120000,Count=3},
                new Computer(){Id=3,Mark="Lenovo",Cpu="Intel",CpuFrequency=2.3,Ram=16,Rom=512,GpuMemory=4,Cost=139990,Count=31},
                new Computer(){Id=4,Mark="ASUS",Cpu="AMD",CpuFrequency=3.1,Ram=16,Rom=1024,GpuMemory=4,Cost=161990,Count=12},
                new Computer(){Id=5,Mark="HP",Cpu="AMD",CpuFrequency=3.3,Ram=8,Rom=512,GpuMemory=4,Cost=104990,Count=29},
                new Computer(){Id=6,Mark="MSI",Cpu="Intel",CpuFrequency=2.7,Ram=8,Rom=512,GpuMemory=4,Cost=79990,Count=7},
            };
            Console.Write("Укажите процессор:");
            string whatCpu = Console.ReadLine();
            List<Computer> sameCpu = computers
                .Where(d => d.Cpu == whatCpu)
                .ToList();
            foreach (Computer t in sameCpu)
            {
                Console.WriteLine($"{t.Id}\t{t.Mark}\t{t.CpuFrequency}\t{t.Ram}\t{t.Rom}\t{t.GpuMemory}\t{t.Cost}\t{t.Count}");
            }
            Console.WriteLine();
            Console.Write("Укажите минимальное количество оперативной памяти:");
            double howRam = Convert.ToDouble(Console.ReadLine());
            List<Computer> moreRam = computers
                .Where(d => d.Ram >= howRam)
                .ToList();
            foreach (Computer t in moreRam)
            {
                Console.WriteLine($"{t.Id}\t{t.Mark}\t{t.Cpu}\t{t.CpuFrequency}\t{t.Ram}\t{t.Rom}\t{t.GpuMemory}\t{t.Cost}\t{t.Count}");
            }
            Console.WriteLine();
            List<Computer> byCost = computers
                .OrderBy(d => d.Cost)
                .ToList();
            Console.WriteLine("По цене:");
            foreach (Computer t in byCost)
            {
                Console.WriteLine($"{t.Id}\t{t.Mark}\t{t.Cpu}\t{t.CpuFrequency}\t{t.Ram}\t{t.Rom}\t{t.GpuMemory}\t{t.Cost}\t{t.Count}");
            }
            Console.WriteLine();
            var byCpu = computers
                .GroupBy(d => d.Cpu);
            foreach (IGrouping<string, Computer> g in byCpu)
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                    Console.WriteLine($"{t.Id}\t{t.Mark}\t{t.CpuFrequency}\t{t.Ram}\t{t.Rom}\t{t.GpuMemory}\t{t.Cost}\t{t.Count}");
                Console.WriteLine();
            }
            Computer maxCost = byCost.Last();
            Console.WriteLine($"Самый дорогой: {maxCost.Id}\t{maxCost.Mark}\t{maxCost.Cpu}\t{maxCost.CpuFrequency}\t{maxCost.Ram}\t{maxCost.Rom}\t{maxCost.GpuMemory}\t{maxCost.Cost}\t{maxCost.Count}");
            Computer minCost = byCost.First();
            Console.WriteLine($"Самый дешевый: {minCost.Id}\t{minCost.Mark}\t{minCost.Cpu}\t{minCost.CpuFrequency}\t{minCost.Ram}\t{minCost.Rom}\t{minCost.GpuMemory}\t{minCost.Cost}\t{minCost.Count}");
            Console.WriteLine();
            bool result = computers
                .Any(d => d.Count >= 30);
            if (result)
                Console.WriteLine("Есть компьютер с количеством 30");
            else
                Console.WriteLine("Всех компьютеров меньше 30");
            Console.ReadKey();
        }
    }
    class Computer
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Cpu { get; set; }
        public double CpuFrequency { get; set; }
        public double Ram { get; set; }
        public double Rom { get; set; }
        public double GpuMemory { get; set; }
        public decimal Cost { get; set; }
        public int Count { get; set; }
    }
}

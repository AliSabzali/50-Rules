using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule_1.classes
{
    class Basket
    {
        public Dictionary<Fruit, int> Fruits { get; private set; }
        public Basket()
        {
            Fruits = new Dictionary<Fruit, int>();
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var fruit in Fruits)
            {
                sb.AppendLine($"{fruit.Key.Name}: {fruit.Value}");
                sb.AppendLine("***************************************");
            }
            return sb.ToString();
        }
    }
}

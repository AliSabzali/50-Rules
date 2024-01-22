using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Rule_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var basket = new Basket();
            try
            {
                basket.Fruits.Add(new Apple() { Color = Color.Red }, 30);
                basket.Fruits.Add(new Orange() { Color = Color.Orange }, 16);
                Console.WriteLine(basket.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        interface IFruit
        {
            string Name { get; }
        }
        abstract class Fruit : IFruit
        {
            private object syncHandle = new object();
            private Color _color;
            public Color Color
            {
                get
                {
                    lock (syncHandle)
                        return _color;
                }
                set
                {
                    if (value == null) throw new ArgumentNullException("Color");
                    if (_color != value)
                    {
                        if (ColorValidation(value))
                        {
                            lock (syncHandle)
                                _color = value;
                        }
                        else throw new Exception($"The color is not valid for {Name}");
                    }
                }
            }
            public string Name { get; }

            public Fruit(string name)
            {
                _color = Color.Red;
                Name = name;
            }

            protected abstract bool ColorValidation(Color color);
        }
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
        class Apple : Fruit
        {
            public Apple() : base("Tart Apple")
            {

            }

            protected override bool ColorValidation(Color color)
            {
                return color == Color.Red || color == Color.Yellow || color == Color.Green;
            }
        }
        class Orange : Fruit
        {
            public Orange() : base("Sweet Orange")
            {
            }

            protected override bool ColorValidation(Color color)
            {
                return color == Color.Orange;
            }
        }
    }
}

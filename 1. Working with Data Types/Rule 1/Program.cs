using Rule_1.classes;
using Rule_1.Fruits;
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
                basket.Fruits.Add(new Apple() { Color = Color.Purple }, 44);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}

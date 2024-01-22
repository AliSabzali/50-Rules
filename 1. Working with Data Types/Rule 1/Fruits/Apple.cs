using Rule_1.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule_1.Fruits
{
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
}

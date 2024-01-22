﻿using Rule_1.classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule_1.Fruits
{
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
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule_1.Classes
{
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
                    else throw new Exception($"The {value} is not valid for '{Name}'");
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
}

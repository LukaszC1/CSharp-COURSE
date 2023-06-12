using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_tasks
{
    class Shape
    {
        public int x {  get; set; }
        public int y { get; set; }

        public virtual void Draw()
        {
            Console.WriteLine("Drawing shape!");
        }
    }

    class Circle : Shape {
        public override void Draw()
        {
            Console.WriteLine("Drawing Circle!");
        }
    }

    class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Triangle!");
        }
    }
}

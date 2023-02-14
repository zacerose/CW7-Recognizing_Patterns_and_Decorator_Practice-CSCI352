using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW7_Decorator_Practice_CSCI352
{
    interface Widget
    {
        void draw();
    }
    class TextField : Widget
    {
        private int width, height;
        public TextField(int w, int h)
        {
            width = w;
            height = h;
        }
        public void draw()
        {
            Console.WriteLine("I am a text field, holding a: width, height");
        }
    }
    abstract class Decorator : Widget
    {
        private Widget wid;
        public Decorator(Widget w)
        {
            wid = w;
        }
        public void draw()
        {
            wid.draw();
        }
    }
    class BorderDecorator : Decorator
    {
        public BorderDecorator(Widget w) : base(w)
        {
            
        }
        public void draw()
        {
            base.draw();
            Console.WriteLine("border decorator ");
        }
    }
    class ScrollDecorator : Decorator
    {
        public ScrollDecorator(Widget w) : base(w)
        {

        }
        public void draw()
        {
            base.draw();
            Console.WriteLine("scroll decorator ");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

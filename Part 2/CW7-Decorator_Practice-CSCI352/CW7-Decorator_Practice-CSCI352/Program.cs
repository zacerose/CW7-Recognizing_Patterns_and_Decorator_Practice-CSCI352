// Name: Zachary Rose
// Date: 2/15/23
// Class: CSCI352
// Decorator practice example. Several decorators implemented that can be applied to a Widget. Main trivially applies and displays results from decorated draw() function.
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
            Console.WriteLine("I am a text field, width: " + width
                + " and height: " + height);
        }
    }
    abstract class Decorator : Widget
    {
        private Widget wid;
        public Decorator(Widget w)
        {
            wid = w;
        }
        virtual public void draw()
        {
            wid.draw();
        }
    }
    class BorderDecorator : Decorator
    {
        public BorderDecorator(Widget w) : base(w)
        {
            
        }
        override public void draw()
        {
            base.draw();
            Console.WriteLine("Decorating border.");
        }
    }
    class ScrollDecorator : Decorator
    {
        public ScrollDecorator(Widget w) : base(w)
        {

        }
        override public void draw()
        {
            base.draw();
            Console.WriteLine("Adding Scrollbar.");
        }
    }
    class ColorDecorator : Decorator
    {
        private string color;

        public ColorDecorator(Widget w, string color) : base(w)
        {
            this.color = color;
        }
        override public void draw()
        {
            base.draw();
            Console.WriteLine("Coloring bar " + color +'.');
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TextField field = new TextField(10, 20);
            BorderDecorator decorator = new BorderDecorator(field);
            ScrollDecorator scroll = new ScrollDecorator(decorator);
            ColorDecorator fanciestTextbox = new ColorDecorator(scroll, "red");
            fanciestTextbox.draw();

            Console.ReadKey();
        }
    }
}

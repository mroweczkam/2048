using _2048.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace _2048.VM
{
    class Painter
    {

        private Canvas canvas;
        public Painter(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void draw(Model.Cell[][] cells, int boardSize)
        {
            clear();
            drawLines(boardSize);
            drawNumbers(cells, boardSize);

            //canvas.ActualHeight; - rozmiar tablicy
                //canvas.ActualWidth - rozmiar tablicy 
            
        }

        private void clear()
        {
            // ma czyscic canvas do pustej bialej przestrzeni.
        }

        private void drawLines(int size)
        {
            drawLine(10, 20, 10, 90);
            // ma rysowac siatke pol, jak do gry w kolko krzyzyk
            // musisz wyliczyc gdzie maja byc poziome i pionowe kreski i potem ja narysowac za pomoca metory drawline
        }

        private void drawLine(int x, int y, int x2, int y2)
        {
            Line line = new Line();
            line.X1 = x;
            line.Y1 = y;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = SystemColors.WindowFrameBrush;
            canvas.Children.Add(line);
        }

        private void drawNumbers(Cell[][] cells, int size)
        {
            // iterujesz po tablicy i rysujesz jezeli nie jest puste 
            // Musisz wyliczyc pozycje w ktorej chcesz wyswietlic liste na planszy (canvas).

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "2";
            textBlock.Foreground = SystemColors.WindowFrameBrush;
            canvas.Children.Add(textBlock);
        }



    }
}

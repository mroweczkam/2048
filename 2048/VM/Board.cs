using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _2048.VM
{
    class Board
    {


        public static Grid createGrid(int size)
        {

            Grid grid = new Grid();
            grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            grid.VerticalAlignment = VerticalAlignment.Stretch;
            grid.ShowGridLines = true;
            


            for (int i = 0; i < size; i++)
            {
                ColumnDefinition columnDefinition_i = new ColumnDefinition();
                columnDefinition_i.Width = new GridLength(1, GridUnitType.Star);
                
                grid.ColumnDefinitions.Add(columnDefinition_i);
            }

            for (int i = 0; i < size; i++)
            {
                RowDefinition rowDefinition_i = new RowDefinition();
                rowDefinition_i.Height = new GridLength(1, GridUnitType.Star);
                grid.RowDefinitions.Add(rowDefinition_i);
            }

            Rectangle rec = new Rectangle();
            rec.Stroke = Brushes.Green;
            rec.Fill = Brushes.LightYellow;
            rec.Height = 100.00;
            rec.Width = 100.00;
            Grid.SetRow(rec, 0);
            Grid.SetColumn(rec, 0);

            grid.Children.Add(rec);

            StackPanel stcPanel = new StackPanel();
            stcPanel.HorizontalAlignment = HorizontalAlignment.Center;
            stcPanel.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(stcPanel, 0);
            Grid.SetColumn(stcPanel, 0);

            TextBlock txtBlock = new TextBlock();
            txtBlock.Visibility = Visibility.Visible;
            txtBlock.Text = "2048";
            stcPanel.Children.Add(txtBlock);

            grid.Children.Add(stcPanel);

            return grid;

        }






    }
}

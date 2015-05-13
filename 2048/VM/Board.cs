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

        
        public static Grid createGrid()
        {

            Grid grid = new Grid();
            grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            grid.VerticalAlignment = VerticalAlignment.Stretch;
            grid.ShowGridLines = true;
            
            ColumnDefinition columnDefinition1 = new ColumnDefinition();
            ColumnDefinition columnDefinition2 = new ColumnDefinition();
            columnDefinition1.Width = new GridLength(100);
            columnDefinition2.Width = new GridLength(100);

            RowDefinition rowDefinition1 = new RowDefinition();
            RowDefinition rowDefinition2 = new RowDefinition();
            rowDefinition1.Height = new GridLength(100);
            rowDefinition2.Height = new GridLength(100);

            grid.ColumnDefinitions.Add(columnDefinition1);
            grid.ColumnDefinitions.Add(columnDefinition2);
            grid.RowDefinitions.Add(rowDefinition1);
            grid.RowDefinitions.Add(rowDefinition2);

            Rectangle rec = new Rectangle();
            rec.Stroke = Brushes.Yellow;
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

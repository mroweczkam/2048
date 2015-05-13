using _2048.Model;
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


        public static Grid createGrid(int size, Cell[][] board)
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

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {

                    if (!board[i][j].IsEmpty())
                    {
                        Rectangle rec = new Rectangle();
                        rec.Stroke = Brushes.Green;
                        rec.Fill = Brushes.LightYellow;
                        Grid.SetRow(rec, i);
                        Grid.SetColumn(rec, j);
                        grid.Children.Add(rec);


                        StackPanel stcPanel = new StackPanel();
                        stcPanel.HorizontalAlignment = HorizontalAlignment.Center;
                        stcPanel.VerticalAlignment = VerticalAlignment.Center;
                        Grid.SetRow(stcPanel, i);
                        Grid.SetColumn(stcPanel, j);

                        TextBlock txtBlock = new TextBlock();
                        txtBlock.Visibility = Visibility.Visible;
                        txtBlock.Text = board[i][j].ToString();
                        stcPanel.Children.Add(txtBlock);

                        grid.Children.Add(stcPanel);
                    }

                }
            }
      


           

           

            return grid;

        }






    }
}

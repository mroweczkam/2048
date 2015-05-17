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
        private static Dictionary<int, SolidColorBrush> colors = new Dictionary<int, SolidColorBrush>(){
            {2, Brushes.LightBlue},
            {4, Brushes.LightYellow},
            {8, Brushes.LightGreen},
            {16, Brushes.LightCyan},
            {32, Brushes.LightPink},
            {64, Brushes.LightGray},
            {128, Brushes.LightCoral},
            {256, Brushes.LightSeaGreen},
            {512, Brushes.Green},
            {1024, Brushes.Blue},
            {2048, Brushes.Brown},
            {4096, Brushes.Magenta},
            {2*4096, Brushes.Magenta},
            {2*2*4096, Brushes.Moccasin},
            {2*2*2*4096, Brushes.MistyRose}
    };

        private static SolidColorBrush getColor (int a){
            if (!colors.ContainsKey(a))
                return Brushes.MediumVioletRed;
           return colors[a];
        }



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
                        rec.Fill = getColor(board[i][j].value);
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
                        txtBlock.FontSize = 30.00;

                        stcPanel.Children.Add(txtBlock);

                        grid.Children.Add(stcPanel);
                    }

                }
            }







            return grid;

        }






    }
}

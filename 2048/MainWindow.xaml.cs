﻿using _2048.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2048
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //var gameVM = new GameVM(canvas);
            Grid GridTest = Board.createGrid();
           
            GridMain.Children.Add(GridTest);
            Grid.SetColumn(GridTest, 2);
            Grid.SetRow(GridTest, 2);

            var gameVM = new GameVM();
            this.DataContext = gameVM;

           // var gamewm2 = new GameVM(canvas);        

        }
    }
}

using _2048.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _2048.VM
{
    public class GameVM : INotifyPropertyChanged
    {
        private Game game;
        private Grid gridMain;
        public GameVM(Grid GridMain)
        {
            game = new Game();
            gridMain = GridMain;
            ResetCmd = new RelayCommand(pars => Reset());
            MoveLeftCmd = new RelayCommand(pars => MoveLeft());
            MoveRightCmd = new RelayCommand(pars => MoveRight());
            MoveUpCmd = new RelayCommand(pars => MoveUp());
            MoveDownCmd = new RelayCommand(pars => MoveDown());
            
            drawBoard();
        }


        private string _boardSize;

        public string boardSize
        {
            get { return _boardSize; }
            set
            {

                if (_boardSize != value)
                {
                    _boardSize = value;
                    game.size = Int32.Parse(value);
                    Reset();
                    OnPropertyChanged("boardSize");
                }

            }
        }

        private string[] sizes = new string[] { "4", "5", "6", "7", "8", "9", "10" };
        public string[] boardSizes
        {
            get
            {
                return sizes;
            }
            set{}
        }



        private int _score;
        public int Score {
            get { return _score; }
            set {
                _score = value;
                OnPropertyChanged("Score");
            }
        }

        public ICommand ResetCmd { get; set; }
        public ICommand MoveLeftCmd { get; set; }
        public ICommand MoveRightCmd { get; set; }
        public ICommand MoveUpCmd { get; set; }
        public ICommand MoveDownCmd { get; set; }

        private void Reset()
        {
            game.reset();
            Score = game.score;
            drawBoard();
        }

        private void MoveLeft()
        {
            game.moveLeft();
            Score = game.score;
            drawBoard();
            CheckEnd();

        }

        private void MoveRight()
        {
            game.moveRight();
            Score = game.score;
            drawBoard();
            CheckEnd();

        }

        private void MoveUp()
        {
            game.moveUp();
            Score = game.score;
            drawBoard();
            CheckEnd();

        }

        private void MoveDown()
        {
            game.moveDown();
            Score = game.score;
            drawBoard();
            CheckEnd();
        }

        private void CheckEnd(){
            if (game.IsEnd())
            {
                System.Windows.MessageBox.Show("Przegrałeś :(");
            }
        }






        private void drawBoard(){
            int intTotalChildren = gridMain.Children.Count - 1;
            for (int intCounter = intTotalChildren; intCounter > 0; intCounter--)
            {
                if (gridMain.Children[intCounter].GetType() == typeof(Grid))
                {
                    Grid ucCurrentChild = (Grid)gridMain.Children[intCounter];
                    gridMain.Children.Remove(ucCurrentChild);
                }
            }
            Grid GridTest = Board.createGrid(game.getBoardSize(), game.getBoard());

            gridMain.Children.Add(GridTest);
            Grid.SetColumn(GridTest, 1);
            Grid.SetRow(GridTest, 1);
        }
        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }


        public event PropertyChangedEventHandler PropertyChanged = null;
    }
}

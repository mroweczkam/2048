using _2048.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            drawBoard();
            
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
            //painter.draw(game.getBoard(), game.getBoardSize());
        }
        // Dodaj jeszcze 4 przyciski na ruch w lewo, prawo, gore i dol bazujac na tym co masz dla Reset. 
        // po kliknieciu wywolujesz odpowiednia metode na obj game, np. moveLeft, aktualizujesz property Score i przerysowywujesz plansze. 


        private void drawBoard(){
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

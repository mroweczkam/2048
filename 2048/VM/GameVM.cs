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
        private Painter painter;
        public GameVM()
        {
            game = new Game();
            ResetCmd = new RelayCommand(pars => Reset());
            MoveLeftCmd = new RelayCommand(pars => MoveLeft());
            //painter = new Painter(canvas);
          //  painter.draw(game.getBoard(), game.getBoardSize());
        }

        public GameVM(DataGridCell datagrid)
        {
            game = new Game();
            ResetCmd = new RelayCommand(pars => Reset());
            MoveLeftCmd = new RelayCommand(pars => MoveLeft());
            datagrid.Content = "abbb";

            //painter = new Painter(datagrid);
            //painter.draw(game.getBoard(), game.getBoardSize());
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
        }

        private void MoveLeft()
        {
            game.moveLeft();
            Score = game.score;
            //painter.draw(game.getBoard(), game.getBoardSize());
        }
        // Dodaj jeszcze 4 przyciski na ruch w lewo, prawo, gore i dol bazujac na tym co masz dla Reset. 
        // po kliknieciu wywolujesz odpowiednia metode na obj game, np. moveLeft, aktualizujesz property Score i przerysowywujesz plansze. 

        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }


        public event PropertyChangedEventHandler PropertyChanged = null;
    }
}

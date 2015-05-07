using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Model
{
    class Game
    {
        private const int size = 4;

        Cell[][] board;


        public void reset()
        {
            board = new Cell[size][];

            for (int i = 0; i < size; i++)
            {
                board[i] = new Cell[size];

                for (int j = 0; j < size; j++)
                {
                    board[i][j] = new Cell(0);
                }

            }
            populate();
            populate();

        }


        private void populate()
        {
            Random rnd = new Random();
            int value = (rnd.Next(2) + 1) * 2;
            int i, j;

            while (true)
            {
                i = rnd.Next(4);
                j = rnd.Next(4);

                if (board[i][j].IsEmpty())
                {
                    board[i][j].value = value;
                    break;
                }

            }
        }

        public void moveLeft()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    if (board[i][j].IsEmpty())
                        continue;

                    for (int k = j - 1; k > -1; k--)
                    {
                        if (board[i][k].IsEmpty())
                        {
                            board[i][k] = board[i][k+1];
                            board[i][k+1].value = 0 ;
                            continue;
                        }

                        if (board[i][k].dirty)
                            break;

                        if (!board[i][k].dirty && board[i][k].value == board[i][k + 1].value)
                        {
                            board[i][k] = board[i][k+1];
                            board[i][k].dirty = true;
                            board[i][k+1].value = 0;
                            break;                                                  
                        
                        }
                    


                    }

                }
            
            }
        }


        public void moveRight()
        {

        }

        public void moveDown()
        {
        }

        public void moveUp()
        {
        }





    }
}

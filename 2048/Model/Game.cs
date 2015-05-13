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

      public  Cell[][] board;
        // score moze byc zmieniany tylko wewnatrz klasy, a odczytywany z zewnatrz.
        public int score { get; set; }

        public Game()
        {
            reset();
        }
        public void reset()
        {
            Random rnd = new Random(); // do usuniecia, tylko do testow 
            score = rnd.Next(100);
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
            int i;

            List<Cell> tmp = new List<Cell>();

            for (int k = 0; k < size; k++)
            {
                for (int l = 0; l < size; l++)
                {
                    if (board[k][l].IsEmpty())
                    {
                        tmp.Add(board[k][l]);
                    }
                }
            }

            i = rnd.Next(tmp.Count());
            tmp[i].value =value;
            tmp.Clear();
        }

        public bool isEnd()
        {
            return false;
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
                            board[i][k] = board[i][k + 1];
                            board[i][k + 1].value = 0;
                            continue;
                        }

                        if (board[i][k].dirty)
                            break;

                        if (!board[i][k].dirty && board[i][k] == board[i][k + 1])
                        {
                            board[i][k] = board[i][k + 1];
                            board[i][k].dirty = true;
                            board[i][k + 1].value = 0;
                            break;
                        }
                        if (!board[i][k].dirty && board[i][k] != board[i][k + 1])
                            break;
                    }
                }
            }
            clearBoard();
        }


        public void moveRight()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = size - 2; j > -1; j--)
                {
                    if (board[i][j].IsEmpty())
                        continue;

                    for (int k = j + 1; k < size; k++)
                    {
                        if (board[i][k].IsEmpty())
                        {
                            board[i][k] = board[i][k - 1];
                            board[i][k - 1].value = 0;
                            continue;
                        }

                        if (board[i][k].dirty)
                            break;

                        if (!board[i][k].dirty && board[i][k] == board[i][k - 1])
                        {
                            board[i][k] = board[i][k - 1];
                            board[i][k].dirty = true;
                            board[i][k - 1].value = 0;
                            break;
                        }
                        if (!board[i][k].dirty && board[i][k] != board[i][k - 1])
                            break;
                    }
                }
            }
            clearBoard();
        }

        public void moveDown()
        {
            for (int j = 0; j < size; j++)
            {
                for (int i = size - 2; i > -1; i--)
                {
                    if (board[i][j].IsEmpty())
                        continue;

                    for (int k = i + 1; k < size; k++)
                    {
                        if (board[k][j].IsEmpty())
                        {
                            board[k][j] = board[k - 1][j];
                            board[k - 1][j].value = 0;
                            continue;
                        }

                        if (board[k][j].dirty)
                            break;

                        if (!board[k][j].dirty && board[k][j] == board[k - 1][j])
                        {
                            board[k][j] = board[k - 1][j];
                            board[k][j].dirty = true;
                            board[k - 1][j].value = 0;
                            break;
                        }
                        if (!board[k][j].dirty && board[k][j] != board[k - 1][j])
                            break;
                    }
                }
            }
            clearBoard();
        }

        public void moveUp()
        {
            for (int j = 0; j < size; j++)
            {
                for (int i = 1; i < size; i++)
                {
                    if (board[i][j].IsEmpty())
                        continue;

                    for (int k = i - 1; k > -1; k--)
                    {
                        if (board[k][j].IsEmpty())
                        {
                            board[k][j] = board[k + 1][j];
                            board[k + 1][j].value = 0;
                            continue;
                        }

                        if (board[k][j].dirty)
                            break;

                        if (!board[k][j].dirty && board[k][j] == board[k + 1][j])
                        {
                            board[k][j] = board[k + 1][j];
                            board[k][j].dirty = true;
                            board[k + 1][j].value = 0;
                            break;
                        }
                        if (!board[k][j].dirty && board[k][j] != board[k + 1][j])
                            break;
                    }
                }
            }
            clearBoard();
        }

        private void clearBoard()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i][j].Clear();
                }
            }
        }


        public Cell[][] getBoard()
        {
            return board;
        }

        public int getBoardSize()
        {
            return size;
        }
    }
}

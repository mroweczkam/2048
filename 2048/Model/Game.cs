﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2048.Model
{
    class Game
    {
        public int size  { get; set;}

        public Cell[][] board;
        public int score { get; set; }

        public Game()
        {
            reset();
        }


        public Game(int size)
        {
            this.size = size;
            reset();
        }

        public void reset()
        {

            score = 0;

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

            if (tmp.Count() > 0)
            {
                var i = rnd.Next(tmp.Count());
                tmp[i].value = value;
                //tmp.Clear();
            }

        }



        public bool IsEnd()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i][j].IsEmpty())
                        return false;

                    if (j - 1 > 0 && board[i][j] == board[i][j - 1])
                    { return false; }

                    if (j + 1 < size && board[i][j] == board[i][j + 1])
                    { return false; }

                    if (i - 1 > 0 && board[i][j] == board[i - 1][j])
                    { return false; }

                    if (i + 1 < size && board[i][j] == board[i + 1][j])
                    { return false; }
                }
            }

            return true;
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
                            board[i][k].value = board[i][k + 1].value;
                            board[i][k + 1].makeEmpty();
                            continue;
                        }

                        if (board[i][k].dirty)
                            break;

                        if (!board[i][k].dirty && board[i][k] == board[i][k + 1])
                        {
                            board[i][k] = board[i][k + 1] + board[i][k];
                            board[i][k].dirty = true;
                            board[i][k + 1].makeEmpty();
                            score += board[i][k].value;
                            break;
                        }
                        if (!board[i][k].dirty && board[i][k] != board[i][k + 1])
                            break;
                    }
                }
            }
            clearBoard();
            populate();
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
                            board[i][k].value = board[i][k - 1].value;
                            board[i][k - 1].makeEmpty();
                            continue;
                        }

                        if (board[i][k].dirty)
                            break;

                        if (!board[i][k].dirty && board[i][k] == board[i][k - 1])
                        {
                            board[i][k] = board[i][k] + board[i][k - 1];
                            board[i][k].dirty = true;
                            board[i][k - 1].makeEmpty();
                            score += board[i][k].value;
                            break;
                        }
                        if (!board[i][k].dirty && board[i][k] != board[i][k - 1])
                            break;
                    }
                }
            }
            clearBoard();
            populate();
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
                            board[k][j].value = board[k - 1][j].value;
                            board[k - 1][j].makeEmpty();
                            continue;
                        }

                        if (board[k][j].dirty)
                            break;

                        if (!board[k][j].dirty && board[k][j] == board[k - 1][j])
                        {
                            board[k][j] = board[k][j] + board[k - 1][j];
                            board[k][j].dirty = true;
                            board[k - 1][j].makeEmpty();
                            score += board[k][j].value;
                            break;
                        }
                        if (!board[k][j].dirty && board[k][j] != board[k - 1][j])
                            break;
                    }
                }
            }
            clearBoard();
            populate();
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
                            board[k][j].value = board[k + 1][j].value;
                            board[k + 1][j].makeEmpty();
                            continue;
                        }

                        if (board[k][j].dirty)
                            break;

                        if (!board[k][j].dirty && board[k][j] == board[k + 1][j])
                        {
                            board[k][j] = board[k][j] + board[k + 1][j];
                            board[k][j].dirty = true;
                            board[k + 1][j].makeEmpty();
                            score += board[k][j].value;
                            break;
                        }
                        if (!board[k][j].dirty && board[k][j] != board[k + 1][j])
                            break;
                    }
                }
            }
            clearBoard();
            populate();
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

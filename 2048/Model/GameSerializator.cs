using _2048.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class GameSerializator
    {

        public static string serialize(Game game)
        {
            string output = "";

            output += game.score.ToString() + ";";
            output += game.size.ToString() + ";";

            for (int i = 0; i < game.size; i++)
            {
                for (int j = 0; j < game.size; j++)
                {
                    output += game.board[i][j].value.ToString() + ";";
                }
            }

            return output;

        }

        public static Game deserialize(string input)
        {

          List<string> GameFromFile =  new List<string>(input.Split(';'));
          

            Game game = new Game(Int32.Parse(GameFromFile[1]));
            game.score = Int32.Parse(GameFromFile[0]);
            
         
                for (int i = 0; i < game.size; i++) {
                    for (int j = 0; j < game.size; j++) {
                        game.board[i][j].value = Int32.Parse(GameFromFile[ 2 + game.size * i + j]);
                    }
                }
            
            return game;

        }
    }
}

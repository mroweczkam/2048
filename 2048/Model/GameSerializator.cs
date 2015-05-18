using _2048.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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

            List<string> GameFromFile = new List<string>(input.Split(';'));


            Game game = new Game(Int32.Parse(GameFromFile[1]));
            game.score = Int32.Parse(GameFromFile[0]);


            for (int i = 0; i < game.size; i++)
            {
                for (int j = 0; j < game.size; j++)
                {
                    game.board[i][j].value = Int32.Parse(GameFromFile[2 + game.size * i + j]);
                }
            }

            return game;

        }


        public static void serializeToXml(Game game, string fileName)
        {
            XmlTextWriter output = new XmlTextWriter(fileName, Encoding.Unicode);
            output.WriteStartDocument();
            output.WriteStartElement("game");
            output.WriteAttributeString("score", game.score.ToString());
            output.WriteAttributeString("size", game.size.ToString());


            for (int i = 0; i < game.size; i++)
            {
                for (int j = 0; j < game.size; j++)
                {

                    output.WriteStartElement("board");
                    output.WriteString(game.board[i][j].value.ToString());
                    output.WriteEndElement();

                }
            }

            output.WriteEndElement();
            output.WriteEndDocument();
            output.Close();
        }


        public static Game deserializeFromXML(string fileName)
        {
            XDocument xdoc = XDocument.Load(fileName);

            List<string> GameFromFile = new List<string>();
            int gameSize,gameScore;



            var lv1s = from lv1 in xdoc.Descendants("game")
                       select new
                       {
                           Score = lv1.Attribute("score").Value,
                           Size  = lv1.Attribute("size").Value,
                           
                           Children = lv1.Descendants("board")
                       };

            foreach (var lv1 in lv1s)
            {
               GameFromFile.Add(lv1.Size);
               GameFromFile.Add(lv1.Score);

                foreach (var lv2 in lv1.Children)
                { GameFromFile.Add(lv2.Value);}
            }

            Game game = new Game(Int32.Parse(GameFromFile[0]));
            game.score = Int32.Parse(GameFromFile[1]);

            for (int i = 0; i < game.size; i++)
            {
                for (int j = 0; j < game.size; j++)
                {
                    game.board[i][j].value = Int32.Parse(GameFromFile[2 + game.size * i + j]);
                }
            }

            return game;

        }





    }
}

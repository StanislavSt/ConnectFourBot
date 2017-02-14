using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using FourInARow.Strategies;

namespace FourInARow
{
    /// <summary>
    /// Class Session handles the whole communication with the game
    /// using the Console
    /// </summary>
    public class Session
    { 
        //Example input from the game 

        //settings timebank 10000
        //settings time_per_move 500
        //settings player_names player1,player2
        //settings your_bot player1
        //settings your_botid 1
        //settings field_columns 7
        //settings field_rows 6
        //update game field 0,0,0,0,0,0,2;0,0,0,0,0,2,2;0,1,0,1,1,1,1;0,2,0,1,1,2,2;0,1,1,2,2,2,1;0,1,1,2,2,1,2
        //action move 10000

        /// <summary>
        /// Runs the engine
        /// </summary>
        public void Run()
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(512)));
            string line;
            
            Board board = new Board();
            IStrategy strategy = new Strategy();

            while ((line = Console.ReadLine()) != null)
            {
                //If the line is empty continue to the next one
                if (line == String.Empty) continue;

                //split the line into separate strings 
                var parts = line.Split(' ');

                //Switch the strings
                switch (parts[0])
                {
                    //Setting up game information 
                    case "settings":
                        switch (parts[1])
                        {
                            case "your_botid":
                                var myBotId = int.Parse(parts[2]);
                                board.SetMyBotId(myBotId);
                                break;
                        }
                        break;
                    //Updating the board
                    case "update":
                        switch (parts[1])
                        {
                            case "game":
                                switch (parts[2])
                                {
                                    case "field":
                                        var boardArray = 
                                            parts[3].Split(';')
                                            .Select(x => x.Split(',').
                                                Select(int.Parse).ToArray())
                                                .ToArray();
                                        board.Update(boardArray);
                                    break;
                                }
                            break;
                        }
                        break;
                    //Making a move 
                    case "action":
                        var move = strategy.NextMove(board);
                        Console.WriteLine("place_disc {0}", move);
                        break;
                }
            }
        }
    }
}
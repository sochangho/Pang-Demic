using System.Collections.Generic;
using UnityEngine;
namespace GameVanilla.Game.Common
{

    public class TwobytwoMatchDetector : MatchDetector
    {

        public override List<Match> DetectMatches(GameBoard board)
        {
            var matches = new List<Match>();
            var checkList = new List<GameObject>();
            

            for (int j = 0; j < board.level.height - 1; j++)
            {
                for (int i = 0; i < board.level.width - 1; i++)
                {
                    var tile = board.GetTile(i, j);
                    if (tile != null && tile.GetComponent<Candy>() != null)
                    {
                        if (board.GetTile(i + 1, j) != null && board.GetTile(i + 1, j).GetComponent<Candy>() != null && board.GetTile(i + 1, j).GetComponent<Candy>().color == tile.GetComponent<Candy>().color
                     && board.GetTile(i, j + 1) != null && board.GetTile(i, j + 1).GetComponent<Candy>() != null && board.GetTile(i, j + 1).GetComponent<Candy>().color == tile.GetComponent<Candy>().color
                    && board.GetTile(i + 1, j + 1) != null && board.GetTile(i + 1, j + 1).GetComponent<Candy>() != null && board.GetTile(i + 1, j + 1).GetComponent<Candy>().color == tile.GetComponent<Candy>().color
                     )
                        {
                            var match = new Match();


                            for (int x = 0; x < 2; x++)
                            {
                                for (int y = 0; y < 2; y++)
                                {
                                    if (!checkList.Contains(board.GetTile(i + x, j + y)))
                                    {
                                        match.AddTile(board.GetTile(i + x, j + y));
                                        checkList.Add(board.GetTile(i + x, j + y));
                                    }
                                }
                            }
                            matches.Add(match);
                        }

                    }
                }
                
            }

            return matches;
        }
    }
}
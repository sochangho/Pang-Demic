﻿// Copyright (C) 2017-2018 gamevanilla. All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement,
// a copy of which is available at http://unity3d.com/company/legal/as_terms.

using System.Collections.Generic;

using UnityEngine;

using GameVanilla.Core;

namespace GameVanilla.Game.Common
{
    /// <summary>
    /// The class used for the color bomb + candy combo.
    /// </summary>
    public class ColorBombWithCandyCombo : ColorBombCombo
    {
        /// <summary>
        /// Resolves this combo.
        /// </summary>
        /// <param name="board">The game board.</param>
        /// <param name="tiles">The tiles destroyed by the combo.</param>
        /// <param name="fxPool">The pool to use for the visual effects.</param>
        public override void Resolve(GameBoard board, List<GameObject> tiles, FxPool fxPool)
        {
            base.Resolve(board, tiles, fxPool);

            var candy = tileA.GetComponent<Candy>() != null ? tileA : tileB;

            for(int i =0; i< tiles.Count; i++)
            {
                if (tiles[i] != null && tiles[i].GetComponent<Candy>() != null &&
                    tiles[i].GetComponent<Candy>().color == candy.GetComponent<Candy>().color)
                {
                    board.ExplodeTileNonRecursive(tiles[i]);
                }
            }

            SoundManager.instance.PlaySound("ColorBomb");

            board.ApplyGravity();
        }
    }
}

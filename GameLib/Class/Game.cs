using System;
using GameLib;

namespace LogicGame
{
    class ClGame
    {
        public void Game()
        {
            library.Score = 0;
            library.Matrix = new ulong[4, 4];
            library.Rows = library.Matrix.GetLength(0);
            library.Cols = library.Matrix.GetLength(1);
        }
        
    }
}

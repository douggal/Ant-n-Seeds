using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ant_n_Seeds
{
    public class AntGrid
    {

        int _numRows;
        int _numCols;
        int _maxRow;
        int _maxCol;

        // we need an ant
        Ant _ant;

        // and a grid
        int[,] _grid;
        List<AntGridSquare> _gridRow;


        // create a random number - we do this here because want differnt numbers each run.
        // if the method creates a random number, it tends to generate same numbers over and over.
        Random _rnd;


        public AntGrid(int numRows, int numCols)
        {
            _numRows = numRows;
            _numCols = numCols;
            _maxRow = numRows - 1;
            _maxCol = numCols - 1;
            _grid = new int[numRows, numCols];
            //_grid2 = new List<AntGridSquare>();
            _rnd = new Random(DateTime.Now.Millisecond);
            _ant = new Ant();
        }

        public double RunSimulation()
        {
            double maxNbrAntMovesAllowed = 1e4;  // max moves
            double loopCnt = 0;
            int numMoves = 0;

            //Console.WriteLine("Run = {0}", numMoves+1);

            do
            {
                loopCnt += 1;
                MoveAntOnGrid(_ant);
                numMoves += 1;
                //Console.WriteLine("Ant position is ({0},{1})", ant.AntRow, ant.AntCol);

                if (_ant.HasSeed == false && _ant.AntRow != 0 && _grid[_ant.AntRow, _ant.AntCol] == 1)
                {
                    // pick up seed
                    _ant.HasSeed = true;
                    _grid[_ant.AntRow, _ant.AntCol] = 0;
                }

                if ((_ant.HasSeed == true) && (_ant.AntRow == 0) && (_grid[_ant.AntRow, _ant.AntCol] == 0))
                {
                    // drop seed
                    _grid[_ant.AntRow, _ant.AntCol] = 1;
                    _ant.HasSeed = false;
                }
            } while (loopCnt < maxNbrAntMovesAllowed && !Done());

            if (loopCnt >= maxNbrAntMovesAllowed)
            {
                Console.WriteLine("Exceeded max number of moves allowed, {0}.", maxNbrAntMovesAllowed);
            }

            //Console.WriteLine();

            return numMoves;
        }

        private bool Done()
        {
            for (int i = 0; i < _numCols; i++)
            {
                if (_grid[0, i] != 1)
                {
                    return false;
                }
            }
            return true;
        }

        public void DisplayGrid()
        {
            Console.WriteLine("View of grid:");
            for (int i = 0; i < _numRows; i++)
            {
                for (int j = 0; j < _numCols; j++)
                {
                    if (_ant.AntRow == i && _ant.AntCol == j)
                    {
                        Console.Write("A");
                        Console.Write(_grid[i, j].ToString() + " ");
                    }
                    else
                    {
                        Console.Write(" " + _grid[i, j].ToString() + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void InitializeGrid()
        {
            // initialize the ant's grid
            // 0 = no seed in this cell, 1 = seed here
            for (int i = 0; i < _numRows - 1; i++) //each row
            {
                for (int j = 0; j < _numCols; j++)
                {
                    _grid[i, j] = 0;
                }
            }

            // all the seeds start at the bottom of the grid
            for (int j = 0; j < _numCols; j++)
            {
                _grid[_maxRow, j] = 1;
            }

            // place the ant in the middle
            _ant.AntRow = _maxRow / 2;
            _ant.AntCol = _maxCol / 2;
        }


        public void MoveAntOnGrid(Ant ant)
        {

            // the ant lives on a grid
            // we move the ant by generating a random number between 1 and 4 inclusive (passed as parameter).
            // Ant may only move to an adjacent cell - no diagonal moves.

            int oldRow = ant.AntRow;
            int oldCol = ant.AntCol;

            int nextCell = 0;

            // find the next cell, working clockwise, 1 = square above, 2 = square to right, etc.
            if (ant.AntRow > 0 && ant.AntCol > 0 && ant.AntRow < _maxRow && ant.AntCol < _maxCol)
            {
                nextCell = _rnd.Next(1, 4 + 1);
            }
            else if (ant.AntRow == 0 && ant.AntCol == 0)
            {
                nextCell = _rnd.Next(2, 3 + 1);
            }
            else if (ant.AntRow == 0 && ant.AntCol > 0 && ant.AntCol < _maxCol)
            {
                nextCell = _rnd.Next(2, 4 + 1);
            }
            else if (ant.AntRow == 0 && ant.AntCol == _maxCol)
            {
                nextCell = _rnd.Next(3, 4 + 1);
            }
            else if (ant.AntRow > 0 && ant.AntCol == _maxCol && ant.AntRow < _maxRow)
            {
                // can be 1, 3, or 4, not contiguous.
                nextCell = _rnd.Next(2, 4 + 1);
                if (nextCell == 2)
                {
                    nextCell = 1;
                }
            }
            else if (ant.AntRow == _maxRow && ant.AntCol == _maxCol)
            {
                // can be 1, or 4, not contiguous. 
                nextCell = _rnd.Next(3, 4 + 1);
                if (nextCell == 3)
                {
                    nextCell = 1;
                }
            }
            else if (ant.AntRow == _maxRow && ant.AntCol > 0 && ant.AntCol < _maxCol)
            {
                nextCell = _rnd.Next(1, 3 + 1);
                // can be 1, 2, or 4, not contiguous. 
                if (nextCell == 3)
                {
                    nextCell = 4;
                }
            }
            else if (ant.AntRow == _maxRow && ant.AntCol == 0)
            {
                nextCell = _rnd.Next(1, 2 + 1);
            }
            else
            {
                nextCell = _rnd.Next(1, 3 + 1);
            }

            switch (nextCell)
            {
                case 1:
                    ant.AntRow -= 1;
                    break;
                case 2:
                    ant.AntCol += 1;
                    break;
                case 3:
                    ant.AntRow += 1;
                    break;
                case 4:
                    ant.AntCol -= 1;
                    break;
                default:
                    break;
            }

            //Console.WriteLine("Move = {0}, ant now at cell ({1},{2})",nextCell,AntRow, AntCol);
        }





    }
}



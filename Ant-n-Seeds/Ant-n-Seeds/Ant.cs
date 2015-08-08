using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ant_n_Seeds
{
    public class Ant
    {
        // Project Euler Problem 280 Ant and Seeds
        // Author:  D. 
        // Date: 11/26/2014
        //
        // https://projecteuler.net/problem=280
        // Ant and seeds
        // Problem 280

        // the ant is simply a position on the grid (row, col) and bool status if has seed or not

        private int _antRow;  //ant's current vertical position
        private int _antCol; // ant's current horizontal position
        private bool _hasSeed; // true if the ant has a picked up a seed

        public Ant()
        {
            AntRow = 0;
            AntCol = 0;
            HasSeed = false;
        }

        public int AntRow
        {
            get { return _antRow; }
            set { _antRow = value; }
        }

        public int AntCol
        {
            get { return _antCol; }
            set { _antCol = value; }
        }

        public bool HasSeed {
            get { return _hasSeed; } 
            set { 
                _hasSeed = value; 
            } 
        }

    }
}

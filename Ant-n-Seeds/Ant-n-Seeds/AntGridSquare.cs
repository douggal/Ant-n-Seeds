using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ant_n_Seeds
{
    public class AntGridSquare
    {
        // Project Euler Problem 280 Ant and Seeds
        // Author:  D. 
        // Date: 11/26/2014
        //
        // https://projecteuler.net/problem=280
        // Ant and seeds
        // Problem 280

        // this is  a square on the ant's grid

        bool _hasSeed;
        bool _hasAnt;

        int _nbrTimesAntWasHere;

        public AntGridSquare()
        {
            _hasAnt = false;
            _hasSeed = false;
            _nbrTimesAntWasHere = 0;
        }

        public bool HasSeed {
            get { return _hasSeed; }
            set { _hasSeed = value; }
        }

        public int NbrTimesAntWasHere {
            get { return _nbrTimesAntWasHere; }
            set {_nbrTimesAntWasHere = value; }
        }
    }
}

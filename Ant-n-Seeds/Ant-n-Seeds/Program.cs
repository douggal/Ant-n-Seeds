using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ant_n_Seeds
{
    class Program
    {
        static void Main(string[] args)
        {
            // Project Euler Problem 280 Ant and Seeds
            // Author:  D. 
            // Date: 11/26/2014
            //
            // https://projecteuler.net/problem=280
            // Ant and seeds
            // Problem 280:
            // "A laborious ant walks randomly on a 5x5 grid. The walk starts from the central square. 
            //  At each step, the ant moves to an adjacent square at random, without leaving the grid; thus there 
            //  are 2, 3 or 4 possible moves at each step depending on the ant's position.
            //  At the start of the walk, a seed is placed on each square of the lower row. When the ant 
            //  isn't carrying a seed and reaches a square of the lower row containing a seed, it 
            //  will start to carry the seed. The ant will drop the seed on the first empty square of 
            //  the upper row it eventually reaches.
            //  What's the expected number of steps until all seeds have been dropped in the top row? 
            //  Give your answer rounded to 6 decimal places."

            // Windows .NET console application in C#.
            // Created with Windows 10, .NET framework 4.6, and Visual Studio Community Edition 2015

            // Solution - Brute force approach:  run a set of simulations keeping track of number
            // of moves required to move all the seeds to their final position.
            // When all the simulations have been run, find the average number of moves
            // and display on screen.

            // Assumptions or inferences from the problem statement:
            // "Ant can only move to adjacent square" - must mean no diagonal moves.
            // Ant can only carry one seed at a time.
            // Ant may only drop seed in top row.
            // Ant can move to cell containing a seed, even if it already has a seed.
            // The grid has 'walls' - the ant never tries to move to a cell outside the grid.

            // This was an exercise in C# development.  
            // Solution was not checked against official number on Project Euler site.

            Console.WriteLine("Project Euler Problem 280: Ant and Seeds");

            const int numRows = 5; //num rows in the grid
            const int numCols = 5; //num cols in the grid

            //create an array to hold the count of moves from each simulation run.  Array size = number of simulations to run.
            const double nbrSimulationsToRun = 1000;
            double nbrMoves;

            // create the ant and place it in the grid on which the ant moves in the simulations
            AntGrid antGrid = new AntGrid(numRows, numCols);

            Accumulator sumOfMoves = new Accumulator();

            for (int i = 0; i < nbrSimulationsToRun; i++)
            {
                // initialize and center the ant on the grid
                antGrid.InitializeGrid();
                //antGrid.DisplayGrid(numRows, numCols, grid, ant);

                // run a simulation
                nbrMoves = antGrid.RunSimulation();
                sumOfMoves.AddDataValue(nbrMoves);
            };

            Console.WriteLine("The average number of moves in {0} simulations was:  {1:f6}", nbrSimulationsToRun, sumOfMoves.Mean());

            //antGrid.DisplayGrid(numRows, numCols, grid, ant);

            // keep console window open until user is ready to close out.
            Console.WriteLine("Complete.  Press any key to exit.");
            Console.ReadKey();


        }
    }
}

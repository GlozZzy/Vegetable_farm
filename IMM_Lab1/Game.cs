using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMM_Lab1
{
    class Game
    {
        private int balance;


        public Game(int val)
        {
            balance = val;
        }

        public int get_balance()
        {
            return balance;
        }

        public bool Plant() 
        {
            if (balance >= 2) balance -= 2;
            else return false;
            return true;
        }

        public bool Harvest(Cell tem)
        {
            if (tem.state == CellState.Immature) balance += 3;
            else if (tem.state == CellState.Mature) balance += 5;
            else if (tem.state == CellState.Planted || tem.state == CellState.Green) return true;
            else if (tem.state == CellState.Overgrown && balance > 0) balance -= 1;
            else if (balance == 0) return false;
            return true;
        }
    }
}

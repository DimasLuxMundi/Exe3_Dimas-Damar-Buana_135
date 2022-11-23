using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe3_Dimas_Damar_Buana_135
{
    class Node
    {
        /*creates Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;
        public CircularList()
        {
            LAST = null;
        }

        /*Searches for the specified node*/
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true); //Returns true if the node is found
            }
            if (rollNo == LAST.rollNumber)//if the node is present at the end
                return true;
            else
                return false;//return false if the node is not found
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

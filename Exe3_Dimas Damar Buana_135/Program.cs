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
        public Node prev;
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

        public void traverse() //Traverses all nodes of the list
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are:\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + "  " + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + "  " + LAST.name + "\n");
            }
        }

        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is: \n\n " + LAST.next.rollNumber + "  " + LAST.next.name);
        }
        public void addNode()
        {
            int rollNo;
            string nm;
            Console.Write("\nEnter the roll number of the students: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student: ");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = rollNo;
            newnode.name = nm;
            Node currentNode;
            currentNode = LAST.next;

            if (currentNode == LAST) {
                newnode.next = LAST;
                LAST.next = newnode;

            }
            else
            {
                newnode.next = currentNode;
                LAST.next = newnode;
                
            }
            return;
        }
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            if (current == LAST)
            {
                LAST = LAST.next;
                if (LAST != null)
                    LAST.prev = null;
                return true;

            }
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }



        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n Menu" +
                        "\n 1. View all the records in the list" +
                        "\n 2. Search for a record in the list" +
                        "\n 3. Display the first record in the list" +
                        "\n 4. Add a node" +
                        "\n 5. Delete a node" +
                        "\n 6. Exit" +
                        
                        "\n Enter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("Enter the roll number of the students whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number " + curr.rollNumber);
                                    Console.WriteLine("\nName " + curr.name);


                                }
                            }
                            break;
                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '4':
                            {
                                obj.addNode();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("Enter the roll number of the students" + " whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number " + rollNo + " deleted \n");
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }


            }
        }

        
            


    }

}

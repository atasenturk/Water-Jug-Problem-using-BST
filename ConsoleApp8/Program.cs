using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp8
{
    class Node
    {
        public int first;
        public int second;
        public string solution = "";
        public Node(int first = 0, int second = 0)
        {
            this.first = first;
            this.second = second;
        }
    };
    class Program
    {
        static int firstCapacity = 4, secondCapacity = 3;

        static void Main(string[] args)
        {
            Node init = new Node(0, 0);
            //initial is (0,0)
            init.solution = init.first + "," + init.second;
            solveJugProblem(init, 2);
        }
        
        public static void solveJugProblem(Node initial, int target)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(initial);
            Node jug;

            while (q.Count != 0)
            {
                jug = q.Peek(); //returns the first node (beginning of the queue)

                if (jug.first == target)
                {
                    Console.WriteLine(jug.solution);
                    break;
                }

                //fill first jug
                if (jug.first < firstCapacity)
                {
                    Node newState = new Node(firstCapacity, jug.second);
                    newState.solution = jug.solution + " " + newState.first + "," + newState.second;
                    q.Enqueue(newState);
                }

                //fill second jug
                if (jug.second < secondCapacity)
                {
                    Node newState = new Node(jug.first, secondCapacity);
                    newState.solution = jug.solution + " " + newState.first + "," + newState.second;
                    q.Enqueue(newState);
                }

                //empty first jug
                if (jug.first > 0)
                {
                    Node newState = new Node(0, jug.second);
                    newState.solution = jug.solution + " " + newState.first + "," + newState.second;
                    q.Enqueue(newState);
                }

                //empty second jug
                if (jug.second > 0)
                {
                    Node newState = new Node(jug.first, 0);
                    newState.solution = jug.solution + " " + newState.first + "," + newState.second;
                    q.Enqueue(newState);
                }


                //pour water in first jug to the second jug until its full
                if (jug.first > 0 && jug.second + jug.first >= secondCapacity)
                {
                    Node newState = new Node(jug.first - (secondCapacity - jug.second), secondCapacity);
                    newState.solution = jug.solution + " " + newState.first + "," + newState.second;
                    q.Enqueue(newState);
                }

                //pour water in first jug to the second jug until its full
                if (jug.second > 0 && jug.first + jug.second >= firstCapacity)
                {
                    Node newState = new Node(firstCapacity, jug.second - (firstCapacity - jug.first));
                    newState.solution = jug.solution + " " + newState.first + "," + newState.second;
                    q.Enqueue(newState);
                }

                //pour all water in first jug to the second jug
                if (jug.first > 0 && jug.first + jug.second <= secondCapacity)
                {
                    Node newState = new Node(0, jug.first + jug.second);
                    newState.solution = jug.solution + " " + newState.first + "," + newState.second;
                    q.Enqueue(newState);
                }

                //pour all water in second jug to the first jug
                if (jug.second > 0 && jug.second + jug.first <= firstCapacity)
                {
                    Node newState = new Node(jug.second + jug.first, 0);
                    newState.solution = jug.solution + " " + newState.first + "," + newState.second;
                    q.Enqueue(newState);
                }
                q.Dequeue();
            }
        }
    }
}

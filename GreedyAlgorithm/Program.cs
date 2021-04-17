using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    public class Program
    {
        public static void Main(string[] pArguments)
        {
            // 1. Create the binary tree
            // 2. Create a list of tuples to store results (node value and node weighted value)
            // 3. Print out the results to the output

            BinaryTree              binaryTree  = new BinaryTree();
            List<Tuple<int, int>>   pathList    = new List<Tuple<int, int>>();
            int                     total       = 0;
            string                  finalValue  = string.Empty;

            // Root of tree
            binaryTree.Root = new BinaryTree.Node(27);

            // Left side of tree
            binaryTree.Root.Left        = new BinaryTree.Node(14);
            binaryTree.Root.Left.Left   = new BinaryTree.Node(10);
            binaryTree.Root.Left.Right  = new BinaryTree.Node(19);

            // Right side of tree
            binaryTree.Root.Right       = new BinaryTree.Node(35);
            binaryTree.Root.Right.Left  = new BinaryTree.Node(31);
            binaryTree.Root.Right.Right = new BinaryTree.Node(42);

            // Run greedy algorithm
            Program.GreedyAlgorithm(binaryTree.Root, pathList, 1);

            // Print results
            Console.WriteLine("Printing results:");
            Console.WriteLine("");

            // Check each pair and print node value and node weight
            foreach (Tuple<int, int> tuple in pathList)
            {
                total += tuple.Item2;
                Console.WriteLine("Node value: " + tuple.Item1 + "\tWeight Value: " + tuple.Item2);
                finalValue += tuple.Item2 + "+";
            }

            // Print final results
            Console.WriteLine();
            Console.WriteLine("Final value: " + finalValue.TrimEnd('+') + " = " + total);

        }

        public static void GreedyAlgorithm(BinaryTree.Node node, List<Tuple<int, int>> pathList, int currentLevel)
        {
            // End recursion if null
            if (node != null)
            {
                // Get the value from each child node
                int leftValue   = node.Left == null ? 0 : node.Left.Data;
                int rightValue  = node.Right == null ? 0 : node.Right.Data;

                // Add the two values (node value and weighted value) to the list
                pathList.Add(new Tuple<int, int>(node.Data, node.Data * currentLevel));
                currentLevel++;

                // Decide which direction down the tree to go next
                if (leftValue > rightValue)
                    Program.GreedyAlgorithm(node.Left, pathList, currentLevel);
                else
                    Program.GreedyAlgorithm(node.Right, pathList, currentLevel);
            }
            else
                return;
        }
    }

    // BinaryTree data structure
    public class BinaryTree
    {
        private Node m_root;

        public BinaryTree()
        {
        }

        public Node Root
        {
            get { return this.m_root; }
            set { this.m_root = value; }
        }

        public class Node
        {
            private Node    m_right;
            private Node    m_left;
            private int     m_data;

            public Node(int data)
            {
                this.m_data     = data;
                this.m_right    = null;
                this.m_left     = null;
            }

            public Node Right
            {
                get { return this.m_right; }
                set { this.m_right = value; }
            }

            public Node Left
            {
                get { return this.m_left; }
                set { this.m_left = value; }
            }

            public int Data
            {
                get { return this.m_data; }
                set { this.m_data = value; }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_Project_4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            AVLTreeOlustur();

            DijkstraShortestPath();

            PrimMinimumSpanningTree();

            DeepthFirstTraverse();

            Console.ReadKey();

        }

        /*
         * 2. soruda istenen AVL Tree işlemini yapan metot.
         */
        static void AVLTreeOlustur()
        {
            // AVL Tree olustur.
            AVLTree tree = new AVLTree();

            // ELeman ekle.
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(2);

            // 7'yi sil.
            tree.Delete(7);

            tree.Add(3423);
            tree.Add(11);
            tree.Add(6);

            // Ekrana yazdir.
            tree.DisplayTree();

            Console.WriteLine();
        }

        /*
         * 3. sorunun a şıkkında istenen işlemi yapan metot.
         */
        static void DijkstraShortestPath()
        {
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                    { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                    { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                    { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                    { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                    { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                    { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                    { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                    { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            Dijkstra t = new Dijkstra();
            t.dijkstra(graph, 0);

            Console.WriteLine();
        }

        /*
         * 3. sorunun b şıkkında istenen işlemi yapan metot.
         */
        static void PrimMinimumSpanningTree()
        {
            int[,] graph = new int[,] { { 0, 2, 0, 6, 0 },
                                      { 2, 0, 3, 8, 5 },
                                      { 0, 3, 0, 0, 7 },
                                      { 6, 8, 0, 0, 9 },
                                      { 0, 5, 7, 9, 0 } };

            MST.primMST(graph);

            Console.WriteLine();
        }

        /*
         * 3. sorunun c şıkkında istenen işlemi yapan metot.
         */
        static void DeepthFirstTraverse()
        {
            DFT g = new DFT(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine("Following is Depth First Traversal (starting from vertex 2)");

            g.DFS(2);
        }
    }
}

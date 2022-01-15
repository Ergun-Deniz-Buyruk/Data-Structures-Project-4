using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_Project_4
{
    internal class DFT
    {
        private int V;

        // Komşuluk Listeyi temsil etmek için liste dizisi
        private List<int>[] adj;

        // Constructor
        public DFT(int v)
        {
            V = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();
        }

        // Grapha kenar ekleyen metot.
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w); // Add w to v's list.
        }

        // DFS tarasından kullanılan fonksiyon.
        void DFSUtil(int v, bool[] visited)
        {
            // Mevcut düğümü ziyaret edildi olarak işaretle ve yazdır.
            visited[v] = true;
            Console.Write(v + " ");

            // Bu köşeye bitişik tüm köşeler için yinele.
            List<int> vList = adj[v];
            foreach (var n in vList)
            {
                if (!visited[n])
                    DFSUtil(n, visited);
            }
        }

        // DFS geçişi yapma işlevi. Özyinelemeli DFSUtil() kullanır.
        public void DFS(int v)
        {
            // Tüm köşeleri ziyaret edilmedi olarak işaretle. (c#'ta varsayılan olarak false olarak ayarlar.)
            bool[] visited = new bool[V];

            // DFS geçişini yazdırmak için özyinelemeli yardımcı işlevi çağır.
            DFSUtil(v, visited);
        }
    }
}

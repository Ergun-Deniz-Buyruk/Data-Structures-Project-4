using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_Project_4
{
    // Prim'in Minimum Spanning Tree (MST) algoritması için bir C# programı.
    // Program, grafiğin komşuluk matris gösterimi içindir.
    using System;
    class MST
    {

        // Graphtaki köşe sayısı
        static int V = 5;

        // Henüz MST'ye dahil edilmemiş köşeler kümesinden minimum
        // anahtar değerine sahip tepe noktasını bulmak için bir yardımcı metot.
        static int minKey(int[] key, bool[] mstSet)
        {

            // Initialize min value
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    min_index = v;
                }

            return min_index;
        }

        // Parent[] içinde depolanan oluşturulmuş MST'yi yazdırmak için bir yardımcı metot.
        static void printMST(int[] parent, int[,] graph)
        {
            Console.WriteLine("Edge \tWeight");
            for (int i = 1; i < V; i++)
                Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i, parent[i]]);
        }

        // Bitişik matris gösterimi kullanılarak temsil edilen bir graph için MST oluşturma ve yazdırma metodu.
        public static void primMST(int[,] graph)
        {

            int[] parent = new int[V];

            // Kesimde minimum ağırlık kenarı seçmek için kullanılan anahtar değerler.
            int[] key = new int[V];

            // MST'de bulunan köşe kümesini temsil etmek için
            bool[] mstSet = new bool[V];

            // Itüm anahtarları başta sonsuz yap.
            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            // MST'ye her zaman ilk 1. tepe noktasını dahil edin. 0 anahtarını yap,
            // böylece bu tepe noktası ilk tepe noktası düğümü olarak seçilir,
            // ve her zaman MST'nin kökü olur
            key[0] = 0;
            parent[0] = -1;

            // MST V kenara sahip olacak.
            for (int count = 0; count < V - 1; count++)
            {

                // Henüz MST'ye dahil edilmeyen köşeler kümesinden minimum anahtar tepe noktasını seç.
                int u = minKey(key, mstSet);

                // Bu tepe noktasını set et.
                mstSet[u] = true;

                // Seçilen tepe noktasının bitişik tepe noktalarının anahtar değerini ve üst dizinini güncelle.
                // Yalnızca  MST'ye dahil edilmemiş olan köşeleri göz önünde bulundur.
                for (int v = 0; v < V; v++)

                    // Graph[u][v] yalnızca m'nin bitişik köşeleri için sıfır değildir
                    // mstSet[v] henüz MST'ye dahil edilmemiş köşeler için yanlıştır.
                    // Anahtarı yalnızca grafik[u][v], [v] anahtarından küçükse güncelle.
                    if (graph[u, v] != 0 && mstSet[v] == false
                        && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
            }

            // Olusturulan MST'yi yazdir.
            printMST(parent, graph);
        }

    }
}

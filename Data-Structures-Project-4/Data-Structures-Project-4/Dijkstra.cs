using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_Project_4
{
    internal class Dijkstra
    {


		// En kısa yol algoritması.
		// Program, grafiğin komşuluk matrisi gösterimi içindir.

		static int V = 9;
		int minDistance(int[] dist,
						bool[] sptSet)
		{
			// Initialize min value
			int min = int.MaxValue, min_index = -1;

			for (int v = 0; v < V; v++)
				if (sptSet[v] == false && dist[v] <= min)
				{
					min = dist[v];
					min_index = v;
				}

			return min_index;
		}

		// Oluşturulan mesafe dizisini yazdırmak için bir yardımcı metot.
		void printSolution(int[] dist, int n)
		{
			Console.Write("Vertex	 Distance "
						+ "from Source\n");
			for (int i = 0; i < V; i++)
				Console.Write(i + " \t\t " + dist[i] + "\n");
		}

		/*
		 * Bitişik matris gösterimi kullanılarak temsil edilen bir grafik için 
		 * Dijkstra'nın en kısa yol algoritmasını uygulayan metot.
		 */
		public void dijkstra(int[,] graph, int src)
		{
			int[] dist = new int[V]; // Çıkış dizisi. dist[i] src ile i
									 // arasındaki en kısa mesafeyi tutacaktır

			// i köşesi en kısa yol ağacına dahil edilirse veya
			// src'den i'ye en kısa mesafe kesinleştirilirse sptSet[i] doğru olur.
			bool[] sptSet = new bool[V];

			// Tüm mesafeleri INFINITE ve stpSet[] olarak false olarak başlat.
			for (int i = 0; i < V; i++)
			{
				dist[i] = int.MaxValue;
				sptSet[i] = false;
			}

			// Kaynak tepe noktasının kendisinden uzaklığı her zaman 0'dır.
			dist[src] = 0;

			// Tüm köşeler için en kısa yolu bul
			for (int count = 0; count < V - 1; count++)
			{
				// Henüz işlenmemiş köşeler kümesinden minimum uzaklık köşesini seç.
				// u, ilk yinelemede her zaman src'ye eşittir.
				int u = minDistance(dist, sptSet);

				// Alınan tepe noktasını işlendi olarak işaretle.
				sptSet[u] = true;

				// Seçilen tepe noktasının bitişik tepe noktalarının dist değerini güncelle.
				for (int v = 0; v < V; v++)

					// dist[v]'yi yalnızca sptSet'te değilse,
					// u'dan v'ye bir kenar varsa ve src'den v'ye ve u'ya kadar olan yolun toplam ağırlığı,
					// dist[v]'nin mevcut değerinden küçükse güncelle.
					if (!sptSet[v] && graph[u, v] != 0 &&
						dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
						dist[v] = dist[u] + graph[u, v];
			}
			printSolution(dist, V);
		}
	}
}


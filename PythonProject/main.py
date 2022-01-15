import networkx as nx
import matplotlib.pyplot as plt

# Directed Graphı olustur.
DG = nx.DiGraph()

# Directed grapha raporda istenen şekildeki gibi edgeleri ekle.
DG.add_edge(0, 1, weight=5.0)
DG.add_edge(0, 2, weight=3.0)
DG.add_edge(0, 4, weight=2.0)
DG.add_edge(1, 2, weight=2.0)
DG.add_edge(1, 3, weight=6.0)
DG.add_edge(2, 1, weight=1.0)
DG.add_edge(2, 3, weight=2.0)
DG.add_edge(4, 1, weight=6.0)
DG.add_edge(4, 2, weight=10.0)
DG.add_edge(4, 3, weight=4.0)

# Graphi cizdir.
plt.figure(figsize=(6, 6))
nx.draw_shell(DG, nlist=[range(5, 10), range(5)], with_labels=True)
plt.show()

#4 nol node'dan diger node'lara giden en yakın yol uzunlugunu bul ve ekrana yazdir.
# 0. node yol olmadigindan eklenmedi eklenirse hata verir.
sp2 = nx.dijkstra_path(DG, source=4, target=1)
sp3 = nx.dijkstra_path(DG, source=4, target=2)
sp4 = nx.dijkstra_path(DG, source=4, target=3)

# Bulunan en kısa yollari ekrana yazdir.
print("4. düğümden 1 düğüme en yakın yol:", sp2)
print("4. düğümden 2 düğüme en yakın yol:", sp3)
print("4. düğümden 3 düğüme en yakın yol:", sp4)

# 4 nolu node'u sil.
DG.remove_node(4)

# Olusan yeni graphi ekrana bir daha yazdir.
plt.figure(figsize=(6, 6))
nx.draw_shell(DG, nlist=[range(5, 10), range(5)], with_labels=True)
plt.show()

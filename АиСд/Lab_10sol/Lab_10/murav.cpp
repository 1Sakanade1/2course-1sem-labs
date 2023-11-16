/* Муравьиный алгоритм для решения задачи коммивояжёра */

#include <locale>
#include <stdlib.h>
#include <iostream>
#include <malloc.h>

using namespace std;

#define TOP_MIN	3						// минимальное количество вершин
#define TOP_MAX	30						// максимальное количество вершин

#define ALPHA	1						// вес фермента
#define BETTA	3						// коэффициент эвристики

#define COLONIES_LIFETIME	100			// время жизни колонии
#define ANTNUM_COLON		20			// количество муравьев в колонии
#define ANT_NUMALL			100			// количество
#define VAPORIZE_COEF		0.5			// коэффициент испарения феромона

// структура ПУТЬ (кол-во вершин, длинна, массив вершин) vertex - вершина 
struct WAY_TYPE {
	int vertex_kolvo;
	int length;
	int* vertex_array;
};

// вероятность перехода муравья ant в вершину to
double probability(int to, WAY_TYPE ant, double** pheromone, double** distance, int vertex) {
	// если вершина уже посещена, возвращаем 0
	for (int i = 0; i < ant.vertex_kolvo; ++i) if (to == ant.vertex_array[i]) return 0;

	double sum = 0.0;
	int from = ant.vertex_array[ant.vertex_kolvo - 1];
	// считаем сумму в знаминателе
	for (int j = 0; j < vertex; ++j) {
		int flag = 1;
		// проверяем, посещал ли муравей j вершину
		for (int i = 0; i < ant.vertex_kolvo; ++i) if (j == ant.vertex_array[i]) flag = 0;
		// если нет, тогда прибавляем к общей сумме
		if (flag) sum += pow(pheromone[from][j], ALPHA) * pow(distance[from][j], BETTA);
	}
	// возвращаем значение вероятности
	return pow(pheromone[from][to], ALPHA) * pow(distance[from][to], BETTA) / sum;
}

// основная функция алгоритма поиска
WAY_TYPE AntColonyOptimization(double** distance0, int vertex, int start, int finish) {
	// инициализация данных о лучшем маршруте
	WAY_TYPE way;
	way.vertex_kolvo = 0;
	way.length = -1;
	way.vertex_array = (int*)malloc(sizeof(int) * vertex);
	// инициализация данных о расстоянии и количестве феромона
	double** distance = NULL, ** pheromone = NULL;
	distance = (double**)malloc(sizeof(double*) * vertex);
	pheromone = (double**)malloc(sizeof(double*) * vertex);
	for (int i = 0; i < vertex; ++i) {
		distance[i] = (double*)malloc(sizeof(double) * vertex);
		pheromone[i] = (double*)malloc(sizeof(double) * vertex);
		for (int j = 0; j < vertex; ++j) {
			pheromone[i][j] = 1.0 / vertex;
			if (i != j) distance[i][j] = 1.0 / distance0[i][j];
		}
	}
	// инициализация муравьев
	WAY_TYPE ants[ANTNUM_COLON];
	for (int k = 0; k < ANTNUM_COLON; ++k) {
		ants[k].vertex_kolvo = 0;
		ants[k].length = 0.0;
		ants[k].vertex_array = (int*)malloc(sizeof(int) * vertex);
		ants[k].vertex_array[ants[k].vertex_kolvo++] = start;
	}

	// основной цикл
	for (int t = 0; t < COLONIES_LIFETIME; ++t) {
		// цикл по муравьям
		for (int k = 0; k < ANTNUM_COLON; ++k) {
			// поиск маршрута для k-го муравья
			do {
				int j_max = -1;
				double p_max = 0.0;
				for (int j = 0; j < vertex; ++j) {
					// Проверка вероятности перехода в вершину j
					if (ants[k].vertex_array[ants[k].vertex_kolvo - 1] != j) {
						double p = probability(j, ants[k], pheromone, distance, vertex);
						if (p && p >= p_max) {
							p_max = p;
							j_max = j;
						}
					}
				}
				ants[k].length += distance0[ants[k].vertex_array[ants[k].vertex_kolvo - 1]][j_max];
				ants[k].vertex_array[ants[k].vertex_kolvo++] = j_max;
			} while (ants[k].vertex_array[ants[k].vertex_kolvo - 1] != finish);
			// оставляем феромон на пути муравья
			for (int i = 0; i < ants[k].vertex_kolvo - 1; ++i) {
				int from = ants[k].vertex_array[i % ants[k].vertex_kolvo];
				int to = ants[k].vertex_array[(i + 1) % ants[k].vertex_kolvo];
				pheromone[from][to] += ANT_NUMALL / ants[k].length;
				pheromone[to][from] = pheromone[from][to];
			}
			// проверка на лучшее решение
			if (ants[k].length < way.length || way.length < 0) {
				way.vertex_kolvo = ants[k].vertex_kolvo;
				way.length = ants[k].length;
				for (int i = 0; i < way.vertex_kolvo; ++i) way.vertex_array[i] = ants[k].vertex_array[i];
			}
			// обновление муравьев
			ants[k].vertex_kolvo = 1;
			ants[k].length = 0.0;
		}
		// цикл по ребрам
		for (int i = 0; i < vertex; ++i)
			for (int j = 0; j < vertex; ++j)
				// обновление феромона для ребра (i, j)
				if (i != j) pheromone[i][j] *= (1 - VAPORIZE_COEF);
	}
	// возвращаем кратчайший маршрут
	return way;
}

int main(int argc, char* argv[]) {
	setlocale(LC_ALL, "Russian");

	double** D = NULL;
	int N = 0, A = 0, B = 0;
	// инициализация матрицы расстояний
	while (N < TOP_MIN || N > TOP_MAX) {
		cout << "Введите количество вершин [" << TOP_MIN << ", " << TOP_MAX << "]: "; cin >> N;
	}
	cout << "Введите матрицу расстояний" << endl;
	D = (double**)malloc(sizeof(double*) * N);
	for (int i = 0; i < N; ++i) {
		D[i] = (double*)malloc(sizeof(double) * N);
		for (int j = 0; j < N; ++j) cin >> D[i][j];
	}
	// инициализация начальной и конечной точек
	while (A < 1 || A > N) {
		cout << "Введите начальную вершину от 1 до " << N << ": "; cin >> A;
	}
	while (B < 1 || B > N || B == A) {
		cout << "Введите конечную вершину от 1 до " << N << " исключая " << A << ": "; cin >> B;
	}

	// запускаем алгоритм
	WAY_TYPE way = AntColonyOptimization(D, N, --A, --B);

	// выводим результат
	cout << "Длинна пути: " << way.length << endl;
	cout << "Путь: " << ++way.vertex_array[0];
	for (int i = 1; i < way.vertex_kolvo; ++i) cout << " -> " << ++way.vertex_array[i];

	return 0;
}
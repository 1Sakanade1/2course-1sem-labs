#include <iostream>
#include<vector>
#include<algorithm>
#include <limits.h>
using namespace std;

#define V 5

#define CHILD 3
#define GENES ABCDE

#define START 0

#define POP_SIZE 5


int map[V][V] = { { INT_MAX, 25, 40, 31, 27},
				{ 5, INT_MAX, 17, 30, 25},
				{ 19, 15, INT_MAX, 6, 1},
				{ 9, 50, 24, INT_MAX, 6 },
				{ 22, 8, 7, 10, INT_MAX } };

struct individual {
	string doroga;
	int fitness;
};


int rand_num(int start, int end)
{
	int r = end - start;
	int rnum = start + rand() % r;
	return rnum;
}


bool repeat(string s, char ch)
{
	for (int i = 0; i < s.size(); i++) {
		if (s[i] == ch)
			return true;
	}
	return false;
}


string mutatedGene(string doroga)
{
	while (true) {
		int r = rand_num(1, V);
		int r1 = rand_num(1, V);
		if (r1 != r) {
			char temp = doroga[r];
			doroga[r] = doroga[r1];
			doroga[r1] = temp;
			break;
		}
	}
	return doroga;
}

string create_doroga()
{
	string doroga = "0";
	while (true) {
		if (doroga.size() == V) {
			doroga += doroga[0];
			break;
		}
		int temp = rand_num(1, V);
		if (!repeat(doroga, (char)(temp + 48)))
			doroga += (char)(temp + 48);
	}
	return doroga;
}

int s4itat_kilometri(string doroga)
{

	int f = 0;
	for (int i = 0; i < doroga.size() - 1; i++) {
		if (map[doroga[i] - 48][doroga[i + 1] - 48] == INT_MAX)
			return INT_MAX;
		f += map[doroga[i] - 48][doroga[i + 1] - 48];
	}
	return f;
}

int cooldown(int temp)
{
	return (90 * temp) / 100;
}

bool lessthan(struct individual t1,
	struct individual t2)
{
	return t1.fitness < t2.fitness;
}

void TSPUtil(int map[V][V])
{
	int gen = 1;
	int gen_thres = 15;

	vector<struct individual> population;
	struct individual temp;

	for (int i = 0; i < POP_SIZE; i++) {
		temp.doroga = create_doroga();
		temp.fitness = s4itat_kilometri(temp.doroga);
		population.push_back(temp);
	}

	cout << "\nНачальная популяция: " << endl
		<< "Гены   Цена\n";
	for (int i = 0; i < POP_SIZE; i++)
		cout << population[i].doroga << " "
		<< population[i].fitness << endl;
	cout << "\n";

	int temperature = 10000;

	sort(population.begin(), population.end(), lessthan);

	while (temperature > 100 && gen <= gen_thres) {
		cout << endl << "Путь: " << population[0].doroga << endl;
		cout << endl << "лучшая стоимость пути поколения : " << population[0].fitness << endl;
		cout << "\n================================\n";
		cout << "\nТекущая температура: " << temperature << "\n";
		vector<struct individual> new_population;

		for (int i = 0; i < CHILD; i++) {

			struct individual p1 = population[i];

			while (true)
			{
				string new_g = mutatedGene(p1.doroga);
				struct individual new_doroga;
				new_doroga.doroga = new_g;
				new_doroga.fitness = s4itat_kilometri(new_doroga.doroga);

				if (new_doroga.fitness <= population[i].fitness) {
					new_population.push_back(new_doroga);
					break;
				}
				else {
					new_doroga.fitness = INT_MAX;
					new_population.push_back(new_doroga);
					break;
				}
			}
		}

		temperature = cooldown(temperature);
		for (int i = 0; i < CHILD; i++)
		{
			population.push_back(new_population[i]);
		}
		sort(population.begin(), population.end(), lessthan);

		for (int i = 0; i < CHILD; i++)
		{
			population.pop_back();
		}

		cout << "Генерация номер = " << gen << " \n";
		cout << "Гены   Цена\n";

		for (int i = 0; i < POP_SIZE; i++)
			cout << population[i].doroga << " "
			<< population[i].fitness << endl;
		gen++;
	}
}

int main()
{
	setlocale(LC_ALL, "rus");

	TSPUtil(map);
}


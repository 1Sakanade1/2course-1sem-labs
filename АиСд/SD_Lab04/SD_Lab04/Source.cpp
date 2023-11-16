#include <iostream>
#define INF 999999

using namespace std;


int main()
{
	setlocale(LC_ALL, "rus");
	int d[6][6] = { 
		{0, 28, 21, 59, 12, 27},	
		{7, 0, 24, INF, 21, 9},
		{9, 32, 0, 13, 11, INF},
		{8, INF, 5, 0, 16, INF},
		{14, 13, 15, 10, 0, 22},
		{15, 18, INF, INF, 6, 0} };

	int s[6][6] = {
		{0, 2, 3, 4, 5, 6},
		{1, 0, 3, 4, 5, 6},
		{1, 2, 0, 4, 5, 6},
		{1, 2, 3, 0, 5, 6},
		{1, 2, 3, 4, 0, 6},
		{1, 2, 3, 4, 5, 0}
	};

	for (int m = 0; m < 6; m++)
		for (int i = 0; i < 6; i++)
			for (int j = 0; j < 6; j++)
			{
				if (i == j || i == m || j == m) continue;	
				if (d[i][j] > d[i][m] + d[m][j])
				{
					d[i][j] = d[i][m] + d[m][j];
					s[i][j] = m + 1;
				}
			}

	cout << "Преобразованная матрица D: \n";
	for (int i = 0; i < 6; i++) 
	{
		for (int j = 0; j < 6; j++)
		{
			cout << d[i][j] << " ";
		}
		cout << "\n";
	}

	cout << "\nПреобразованная матрица S: \n";
	for (int i = 0; i < 6; i++)
	{
		for (int j = 0; j < 6; j++)
		{
			cout << s[i][j] << " ";
		}
		cout << "\n";
	}

	return 0;
}
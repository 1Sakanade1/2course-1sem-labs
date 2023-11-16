//алгоритм Прима
#include <iostream>
#include <cstring>
using namespace std;

#define V 8

void Prime(int G[8][8]) //O(n^2)
{
    int edge = 0;            // номер ребра
    int m = 0;
    int n = V;
    int c = 0;
    //подсчет кол-ва ребер
    for (int i = 0; i < V; i++) {
        for (int j = 0; j < V; j++) {
            if (G[i][j] > 0)
                m++;
        }
    }
    m = m / 2;
    //цикломатическое число(сколько нужно удалить ребер)
    c = m - n + 1;
    // посещение
    int visit[V];
    for (int i = 0; i < V; i++) {
        visit[i] = false;
    }

    visit[0] = true;

    int x;
    int y;

    cout << "Вершина 1 | Вершина 2 | Вес";
    cout << endl;
    while (edge < m - c) {
        int min = INT_MAX;
        x = 0;
        y = 0;
        for (int i = 0; i < V; i++) {
            if (visit[i]) {
                for (int j = 0; j < V; j++) {
                    if (!visit[j] && G[i][j]) {
                        if (min > G[i][j]) {
                            min = G[i][j];
                            x = i;
                            y = j;
                        }

                    }
                }
            }
        }
        cout << x + 1 << "|" << y + 1 << "|" << G[x][y];
        cout << endl;
        visit[y] = true;
        edge++;
    }
}

void Kraskal(int massiv[][3], int x,int versh)//O(n^2+n)  //O(n*log(n)) 
{
    int* addedversh = new int[versh];

    for (int i = 0; i < versh; i++)
    {
        addedversh[i] = 0;
    }


    //сортировка массива
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < x; j++)
        {
            if (massiv[i][2] < massiv[j][2])
            {
                int tmp[3] = { massiv[i][0],massiv[i][1],massiv[i][2] };

                massiv[i][0] = massiv[j][0];
                massiv[i][1] = massiv[j][1];
                massiv[i][2] = massiv[j][2];

                massiv[j][0] = tmp[0];
                massiv[j][1] = tmp[1];
                massiv[j][2] = tmp[2];
            }
        }



    }
    cout << "Отсортированный массив" << "\n";

    for (int i = 0; i < x; i++)
    {
        cout << massiv[i][0] << '|' << massiv[i][1] << '|' << massiv[i][2] << "\n";

    }



    cout << "--------------------\n";
    cout << " результирующий массив: \n";

    for (int i = 0; i < x; i++)
    {
        if (addedversh[massiv[i][0] - 1] == 1 && addedversh[massiv[i][1] - 1] == 1)
        {
        }
        else
        {
            addedversh[massiv[i][0] - 1] = 1;
            addedversh[massiv[i][1] - 1] = 1;

            cout << massiv[i][0] << '|' << massiv[i][1] << '|' << massiv[i][2] << "\n";
        }
    }
    delete[] addedversh;
}

int main() {

    setlocale(LC_ALL, "rus");

    int G[V][V] = {           { 0, 2, 0, 8, 2, 0, 0, 0 },
                              { 2, 0, 3, 10, 5, 0, 0, 0 },
                              { 0, 3, 0, 0, 12, 0, 0, 7 },
                              { 8, 10, 0, 0, 14, 3, 1, 0 },
                              { 2, 5, 12, 14, 0, 11, 4, 8 },
                              { 0, 0, 0, 3, 11, 0, 6, 0 },
                              { 0, 0, 0, 1, 4, 6, 0, 9 },
                              { 0, 0, 7, 0, 8, 0, 9, 0 } };

    int G2[16][3] = {
                           { 1, 2, 2},
                           { 1, 4, 8},
                           { 1, 5, 2},
                           { 2, 3, 3},
                           { 2, 4, 2},
                           { 2, 5, 5},
                           { 3, 5, 12},
                           { 3, 8, 7},
                           { 4, 5, 14},
                           { 4, 6, 3},
                           { 4, 7, 1},
                           { 5, 6, 11},
                           { 5, 7, 4},
                           { 5, 8, 8},
                           { 6, 7, 6},
                           { 7, 8, 9}

    };

    

  
    Prime(G);
    cout << "---------------------\n";
    Kraskal(G2, 16, 8);
    

    return 0;
}
#include <iostream>
#include <stack>
#include <queue> 
#include <cstdlib>


using namespace std;
int main()
{
    setlocale(LC_ALL, "rus");
    stack<int> Stack;
    queue<int> Queue;

    int SpisReb[20][2] =
    { {1,5},{5,1},
        {2,7},{7,2},{2,8},{8,2},
        {7,8},{8,7},{8,3},{3,8},
        {5,6},{6,5},{6,4},{4,6},
        {6,9},{9,6},{4,9},{9,4},
        {9,10},{10,9} };// Список рёбер


    // Матрица смежности
    int MatSmezh[10][10] = {
    { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
    { 0, 0, 0, 0, 0, 1, 0, 0, 1, 0},
    { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
    { 0, 0, 0, 1, 1, 0, 0, 0, 1, 0 },
    { 0, 1, 0, 0, 0, 0, 0, 1, 0, 0 },
    { 0, 1, 1, 0, 0, 0, 1, 0, 0, 0 },
    { 0, 0, 0, 1, 0, 1, 0, 0, 0, 1 },
    { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }, };




    // Список смежности
    int SpisSmesh[10][3] = { {5}, {7, 8}, {8}, {6, 9}, {1, 6}, {4, 5, 9}, {2, 8}, {2, 3, 7}, {4, 6, 10 }, {9} };//Спискок смежных вершин для каждой вершины графа
    int k;
    cout << "BFS(1) или DFS(2): " << endl;
    cin >> k;

    int nodes[10] = { 0,0,0,0,0,0,0,0,0,0 }; //Вершинам присвоено значение 0, так как мы их ещё не посещали

    int s = 0;
    switch (k)
    {
    case 1:
    {
        cout << "Проход в ширину(BFS): " << endl;
        Queue.push(0);
        while (!Queue.empty())
        {
            int node = Queue.front();
            Queue.pop();
            s++;
            cout << s << "-ый ход, вершина: ";
            nodes[node] = 1;
            for (int j = 0; j < 10; j++)
            {
                if (MatSmezh[node][j] == 1 && nodes[j] == 0)
                {
                    Queue.push(j);
                    nodes[j] = 1;
                }
            }
            cout << node + 1 << endl;
        }
        for (int i = 0; i < 10; i++)
        {
            if (nodes[i] == 2)
            {
                cout << nodes[i] << endl;

            }
            else
            {
                Queue.push(nodes[i]);
                while (!Queue.empty())
                {
                    int node = Queue.front();
                    Queue.pop();
                    s++;
                    cout << s << "-ый ход, вершина: ";
                    nodes[node] = 1;
                    for (int j = 0; j < 10; j++)
                    {
                        if (MatSmezh[node][j] == 1 && nodes[j] == 0)
                        {
                            Queue.push(j);
                            nodes[j] = 1;
                        }
                    }
                    cout << node + 1 << endl;

                }
                break;

            }
        }
        break;
    }
    case 2:
    {
        cout << "Проход в ширину(DFS): " << endl;
        Stack.push(0);
        while (!Stack.empty())
        {
            int node = Stack.top();
            Stack.pop();
            s++;
            cout << s << "-ый ход, вершина: ";
            nodes[node] = 1;
            for (int j = 9; j >= 0; j--)
            {
                if (MatSmezh[node][j] == 1 && nodes[j] == 0)
                {
                    Stack.push(j);
                    nodes[j] = 1;
                }
            }
            cout << node + 1 << endl;
        }
        for (int i = 0; i < 10; i++)
        {
            if (nodes[i] == 1)
            {
                Stack.push(nodes[i]);
                while (!Stack.empty())
                {
                    int node = Stack.top();
                    Stack.pop();
                    s++;
                    cout << s << "-ый ход, вершина: ";
                    nodes[node] = 1;
                    for (int j = 9; j >= 0; j--)
                    {
                        if (MatSmezh[node][j] == 1 && nodes[j] == 0)
                        {
                            Stack.push(j);
                            nodes[j] = 1;
                        }
                    }
                    cout << node + 1 << endl;
                }
                break;
            }
        }
        break;
    }
    default:
        break;
    }

    system("pause");
    return 0;
}
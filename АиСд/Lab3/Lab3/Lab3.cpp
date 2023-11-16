#include <iostream>
#include <iomanip>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
    vector<int> parent(9, -1);    // объявили вектор с размером 9 и сразу заполнили -1-цами
    int big_num(10000);           
    int matrix[9][9] = { {0,7,10,0,0,0,0,0,0},
                        {7,0,0,0,0,9,27,0,0},
                        {10,0,0,0,31,8,0,0,0},
                        {0,0,0,0,32,0,0,17,21},
                        {0,0,31,32,0,0,0,0,0},
                        {0,9,8,0,0,0,0,11,0},
                        {0,27,0,0,0,0,0,0,15},
                        {0,0,0,17,0,11,0,0,15},
                        {0,0,0,21,0,0,15,15,0} };

    int pos[9], node[9], min = 0, index_min = 0;      
    for (int i = 0; i < 9; ++i) {
        pos[i] = big_num;
        node[i] = 0;
    }
    for (int i = 0; i <9; ++i) {                      //выводим матрицу смежности
        for (int j = 0; j < 9; ++j) {
            cout << setw(4) << matrix[i][j];
        }
        cout << "\n";
    }
    cout << ("enter start node :");
    int startvershina;
    cin >> startvershina;
    pos[startvershina - 1] = 0;            // наш узел назначаем его началом алгоритма находим вершину с минимальным к ней расстоянием, на первом шаге это будет узел
    cout << "\n";
    for (int i = 0; i < 8; ++i) {
        min = big_num;
        for (int j = 0; j < 8; ++j) {
            if (!node[j] && pos[j] < min) {
                min = pos[j];
                index_min = j;
            }
        }
        node[index_min] = true;          // помечаем выбранную вершину как пройденную
        for (int j = 0; j < 9; ++j) {    // цикл, в котором мы даем всем вершинам, смежным с выбранной вес пути к ней


            if (!node[j] && matrix[index_min][j] > 0 &&         //если эта вершина не пройденна
                pos[index_min] != big_num &&                    //эта вершина смежна с выбранной
                pos[index_min] + matrix[index_min][j] < pos[j]) //если сумма веса выбранной вершины и ребра к текущей будет меньше, чем вес текущей на данный момент
            {
                pos[j] = pos[index_min] + matrix[index_min][j];                 //меняем значение веса текущей вершины.
                parent.at(j) = index_min;    // запоминаем предка вершины j
            }
        }
    }

    for (int i = 1; i < 10; ++i) //вывод информации
    {
        int n(0);
        cout << "\n node number #" << i;  

        n = i;

        cout << "\nWeight : " << pos[n - 1] << "\n";                       //выводим путь

        cout << endl;
    }
    return 0;
}
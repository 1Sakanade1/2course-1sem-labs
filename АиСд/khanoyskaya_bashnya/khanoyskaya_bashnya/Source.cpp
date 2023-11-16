#include <iostream>

using namespace std;

void move(int point1, int point2)
{
	cout << "ѕереместить диск со стержн€ " << point1 << " на стержень " << point2 << endl;
}

void moveTower(int amount, int point1, int point2, int temp)
{
	if (amount == 0)
	{
		return;
	}

	moveTower(amount - 1, point1, temp, point2);

	move(point1, point2);

	moveTower(amount - 1, temp, point2, point1);
}

void main()
{
	setlocale(LC_ALL, "rus");
	int amount, pointTo, temp;
	cout << "¬ведите кол-во дисков и на какой стержень передвинуть(2 или 3): ";
	cin >> amount >> pointTo;
	switch (pointTo)
	{
	case(2):
		temp = 3;
		break;
	case(3):
		temp = 2;
		break;
	}
	moveTower(amount, 1, pointTo, temp);
}
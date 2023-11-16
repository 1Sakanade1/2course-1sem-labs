#include <iostream>

using namespace std;

void move(int point1, int point2)
{
	cout << "����������� ���� �� ������� " << point1 << " �� �������� " << point2 << endl;
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
	cout << "������� ���-�� ������ � �� ����� �������� �����������(2 ��� 3): ";
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
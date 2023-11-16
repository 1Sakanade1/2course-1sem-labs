#include <iostream>
#include <fstream>

using namespace std;

#define WCHAR_T 2;
#define INT 4;

int main()
{
	setlocale(LC_ALL, "rus");

	ofstream serFile("serialization.txt", ios::binary);
	cout << "¬водите значени€ дл€ INT, когда закончите введите 0: ";
	int elemInt = 1;

	while (elemInt != 0)
	{
		cin >> elemInt;

		if (elemInt == 0) break;
		
		serFile << INT;
		serFile << sizeof(int);
		serFile << elemInt;
		serFile << " ";
	}

	cout << "\n¬водите значени€ дл€ WCHAR_T, когда закончите введите 0: ";
	wchar_t symbsIn = '1';
	
	while (symbsIn != '0')
	{
		wcin >> symbsIn;
		
		if (symbsIn == '0') break;
		
		serFile << WCHAR_T;
		serFile	<< sizeof(wchar_t);
		serFile << symbsIn;
		serFile << " ";
	}


	serFile.close();
}
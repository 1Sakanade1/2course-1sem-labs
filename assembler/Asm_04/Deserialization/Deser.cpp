#include <iostream>
#include <fstream>
#include <string>

using namespace std;

#define WCHAR_T 2
#define INT 4
#define HEADER ".586\n.MODEL FLAT, STDCALL\nincludelib kernel32.lib\nExitProcess PROTO : DWORD\n.STACK 4096\n\n.CONST\n"
#define DATA "\n.DATA\n"
#define FOOTER "\n\n.CODE\nmain PROC\nSTART :\npush - 1\ncall ExitProcess\nmain ENDP\nend main\n"

int main()
{
	ifstream readSer("..\\Asm_04\\serialization.txt", ios::binary);
	ofstream writeCode("..\\Asm_04\\Deserialization.asm");
	string str, words[128];
	getline(readSer, str);
	int q = 0;

	for (int w = 0; w < str.length(); w++)
	{
		if (str[w] == ' ')
		{
			q++;
			continue;
		}
		words[q] += str[w];

	}


	int temp;
	if (readSer.is_open())
	{
		writeCode << HEADER;
		bool flag = true;
		
		for (int i = 0; i < q + 1; i++)
		{
			switch (words[i][1])
			{
			case '2':
				if (flag)
				{
					writeCode << DATA;
					flag = false;
				}
				writeCode << "wchar_t";
				writeCode << i;
				writeCode << " WORD ";
				temp = stoi(words[i].substr(2));
				writeCode << static_cast<char>(temp);
				writeCode << "\n";
				break;
			case '4':
				writeCode << "int";
				writeCode << i;
				writeCode << " DWORD ";
				writeCode << words[i].substr(2);
				writeCode << "\n";
				break;
			default:
				break;
			}
		}
				writeCode << FOOTER;
	}
		
		readSer.close();
		writeCode.close();

}
#include "stdafx.h"
#include "In.h"
#include "Error.h"
#define STRING_END_ZERO '\0'
using namespace std;

namespace In
{
	IN getin(wchar_t infile[])
	{
		IN in;
		in.size = 0;
		in.lines = 1;
		in.ignor = 0;
		char* line = new char[IN_MAX_LEN_TEXT];;
		int cols = 0;

		unsigned char* text = new unsigned char[IN_MAX_LEN_TEXT];

		ifstream fin(infile);
		if (fin.fail()) 
			throw ERROR_THROW(110);		//если не нашло файл

		while (in.size < IN_MAX_LEN_TEXT)  //пока размер не превышает
		{
			char k;
			fin.get(k);
			unsigned char uc = k;

			if (fin.eof())		//если данные в источнике закончились
			{
				text[in.size] = STRING_END_ZERO;
				break;
			}
			if (in.code[uc] == in.T || in.code[uc] == in.D || in.code[uc] == in.O)		//если символ == T/D/O из таблицы
			{
				text[in.size] = uc;//присваиваем символ для его печати
				in.size++;		//кол-во символов++
				cols++;			//позиция++
			}
			else if (in.code[uc] == in.I)		//если символ ==I из таблицы
			{
				in.ignor++;		// увеличиваем счетчик проигнорированных символов
			}
			else if (in.code[uc] == in.F)		//если символ ==F из таблицы
			{
				throw ERROR_THROW_IN(111, in.lines, cols);		//выводит ошибку,указывает строку и поозицию
			}
			else	//если данные в источнике не закончились
			{
				text[in.size] = in.code[uc];
				in.size++;
				cols++;
			}
			if (uc == IN_CODE_ENDL)			//если символ = \n
			{
				in.lines++;			//новая строка
				cols = 0;			//позиция  = 0
			}
		}
		in.text = text;//присваиваем значению из структуры значение массива чаров
		return in;
	}
}
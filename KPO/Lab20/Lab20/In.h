#pragma once
#define IN_MAX_LEN_TEXT 1024*1024	
#define IN_CODE_ENDL '\n'

//задаем таблицу,в которой присваиваем значение для 255 символов(набор символов Windows-1251 (T - введен I - игнорируем , F - генерация ошибки)
#define IN_CODE_TABLE {\
	IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T,  '|' , IN::T, IN::T,	IN::I, IN::T, IN::T/*15*/,\
	IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T/*31*/,\
	IN::D,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::D, IN::D,	IN::D, IN::O, IN::O, IN::D,	IN::O, IN::T, IN::O/*47*/,\
	IN::T,	IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::D, IN::T,	IN::O, IN::T, IN::T/*63*/,\
	IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T/*79*/,\
	IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::I,	IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T/*95*/,\
	IN::T,  IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T/*111*/,\
	IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::D, IN::T, IN::D, IN::T, IN::T/*127*/,\
																													\
	IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T/*143*/,\
	IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T/*159*/,\
	IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T/*175*/,\
	IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T/*191*/,\
    IN::T,  IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T/*207*/,\
	IN::T,  IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T/*223*/,\
    IN::T,	IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T,  IN::T, IN::T, IN::T, IN::T, IN::T/*239*/,\
    IN::T,  IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T, IN::T,	IN::T, IN::T, IN::T/*255*/\
					}

namespace In
{
	struct IN
	{
		enum { T = 1024, F = 2048, I = 4096, D = 8192, O = 16384 };
		int size;		//размер исходного кода
		int lines;		//количество строк
		int ignor;		//сколько символов игнорит
		unsigned char* text;	//исходный код в Windows-1251
		int code[256] = IN_CODE_TABLE;  //значение таблицы проверки
	};
	IN getin(wchar_t infile[]);		// Используется для ввода и проверки информации из файла с исходными кодами.
}
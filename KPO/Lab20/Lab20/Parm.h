//обработка входных параметров

#pragma once            
#include "stdafx.h" 
#define PARM_IN		L"-in:"   //ключ для файла исходного кода
#define	PARM_OUT	L"-out:"  //ключ для файла объектного кода
#define	PARM_LOG	L"-log:"  //ключ для файла с логами отработанной проги
#define	PARM_MAX_SIZE	300   //макс размер строки параметра
#define	PARM_OUT_DEFAULT_EXIT	L".out" //расширение файла лбъектного кода 
#define	PARM_LOG_DEFAULT_EXIT	L".log" //расширение файла с логами

namespace Parm
{
	struct PARM       //структура,содержащая входные параметры
	{
		wchar_t in[PARM_MAX_SIZE];       // -in:name        //имена файлов исходного,объектного кодов, файла,в который запишется лог
		wchar_t out[PARM_MAX_SIZE];      // -out:name
		wchar_t log[PARM_MAX_SIZE];      // -log:name
	};

	PARM getparm(int argc, wchar_t* argv[]);                //сформировать struct PARM на основе параметров,переданных в ф-ю main()                                                        //int wmain(int argc, wchar_t* argv[])
}
}
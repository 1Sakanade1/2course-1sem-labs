#pragma once
#include "stdafx.h"

namespace Log		//работа с протоколом
{
	struct LOG		//протокол
	{
		wchar_t logfile[PARM_MAX_SIZE];		//имя файла
		std::ofstream* stream;				
	};

	static const LOG INITLOG = { L"", NULL };       //структура для начальной инициализации LOG
	LOG getlog(wchar_t logfile[]);                  //сформировать структуру LOG
	void WriteLine(LOG log, const char* c, ...);    //вывести в протокол конкатенацию строк
	void WriteLine(LOG log, const wchar_t* c, ...); //вывести в протокол конкатенацию строк
	void WriteLog(LOG log);                         //вывести заголовок
	void WriteParm(LOG log, Parm::PARM parm);       //вывести инфу о входных параметрах
	void WriteIn(LOG log, In::IN in);               //и о входном потоке
	void WriteError(LOG log, Error::ERROR error);   //вывести в протокол инфу об ошибке
	void Close(LOG log);
}

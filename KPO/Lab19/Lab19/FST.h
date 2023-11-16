#pragma once
#include "stdafx.h"

namespace FST
{
	struct RELATION
	{
		char symbol;	//символ перехода
		short nnode;	// номер смежной вершины
		RELATION(
			char c = 0x00,		//символ перехода
			short nn = NULL		//новое состояние
		);
	};

	struct NODE		//вершина графа переходов
	{
		short n_relation;	// количество инцидентных ребер
		RELATION* relations;	//инцидентные ребра
		NODE();
		NODE(
			short n,		//кол-во инц. ребер
			RELATION rel, ...	//список ребер
		);
	};

	struct FST		//недетерминированный конечный автомат
	{
		char* string;		//цепочка (строка, завершается 0x00)
		short position;		//текущая позиция в цепочке
		short nstates;		//количество состояний автомата
		NODE* nodes;		//граф переходов [0] - начальное состояние, [nstates-1 ] - конечное
		short* rstates;		//возможные состояния автомата на данной позиции
		FST(
			char* s,		//цепочка
			short ns,		//количество состояний
			NODE n, ...		//список состояний
		);
	};

	bool execute(		//выполнить распознавание цепочки
		FST& fst		//недет. конечный автомат
	);
};

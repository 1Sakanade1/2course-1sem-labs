#include "stdafx.h"
#include <fstream>
namespace LT
{
	LT::LexTable::LexTable()
	{
		this->maxsize = LT_MAXSIZE;
		this->size = 0;
		this->table = new Entry[LT_MAXSIZE];
	}

	void Add(LexTable& lextable, Entry entry)
	{
		if (lextable.size < lextable.maxsize)
			lextable.table[lextable.size++] = entry;
		else
			throw ERROR_THROW(120);
	}
	Entry LexTable::GetEntry(int n)
	{
		if (n < this->maxsize && n >= 0)
			return this->table[n];
	}
	void Delete(LexTable& lextable)
	{
		delete[] lextable.table;
		lextable.table = nullptr;
	}
	void PrintLexTable(LexTable& lextable, IT::IdTable& idtable, const wchar_t* in)
	{

		std::ofstream* lex_stream = new std::ofstream;
		lex_stream->open(in);
		(*lex_stream) << "##########################################################################################################################" << std::endl;
		(*lex_stream) << "-------— Лексемы —-------";

		if (lex_stream->is_open())
		{
			int num_string = 0;
			for (int i = 0; i < lextable.size;)
			{
				if (num_string == lextable.table[i].sn)
					(*lex_stream) << lextable.table[i++].lexema;
				else
				{
					num_string++;
					if (lextable.table[i].sn != num_string)
					{
						continue;
					}
					(*lex_stream) << '\n' << num_string << ".\t";

					if (num_string == lextable.table[i].sn)
						(*lex_stream) << lextable.table[i++].lexema;
				}
			}
			(*lex_stream) << "\n##########################################################################################################################" << std::endl;
			(*lex_stream) << "\n-------— Таблица лексем —-------" << std::endl;
			(*lex_stream) << "Лексема:" << " " << "Номер строки:" << " " << "Позиция в таблице лексем" << " " << "Позиция в таблице индетификаторов:" << " " << "Имя по таблице индитификаторов:" << std::endl;
			for (int i = 0; i < lextable.size; i++) {
				if (lextable.table[i].idxTI != TI_NULLIDX)
					(*lex_stream) << lextable.table[i].lexema << std::setw((11 - 1) + (sizeof(lextable.table[i].sn) / sizeof(int))) << lextable.table[i].sn << std::setw(16 - (sizeof(lextable.table[i].sn) / sizeof(int)) + sizeof(i) / sizeof(int)) << i << std::setw(27 - (sizeof(i) / sizeof(int)) + (sizeof(lextable.table[i].idxTI) / sizeof(int))) << lextable.table[i].idxTI << std::setw(37 - (sizeof(lextable.table[i].idxTI) / sizeof(int)) + std::strlen(idtable.GetEntry(lextable.table[i].idxTI).id)) << idtable.GetEntry(lextable.table[i].idxTI).id << std::endl;
				else (*lex_stream) << lextable.table[i].lexema << std::setw((11 - 1) + (sizeof(lextable.table[i].sn) / sizeof(int))) << lextable.table[i].sn << std::setw(16 - (sizeof(lextable.table[i].sn) / sizeof(int)) + sizeof(i) / sizeof(int)) << i << std::endl;
			}

		}
		else
			throw ERROR_THROW(131);
		lex_stream->close();
		delete lex_stream;

	}
	LT::Entry::Entry()
	{
		this->lexema = '\0';
		this->sn = LT_TI_NULLXDX;
		this->idxTI = LT_TI_NULLXDX;
	}

	LT::Entry::Entry(const char lex, int str_n, int idxTI)
	{
		this->lexema = lex;
		this->sn = str_n;
		this->idxTI = idxTI;
	}
}
#pragma once
#include "stdafx.h"

namespace FST
{
	struct RELATION
	{
		char symbol;	//������ ��������
		short nnode;	// ����� ������� �������
		RELATION(
			char c = 0x00,		//������ ��������
			short nn = NULL		//����� ���������
		);
	};

	struct NODE		//������� ����� ���������
	{
		short n_relation;	// ���������� ����������� �����
		RELATION* relations;	//����������� �����
		NODE();
		NODE(
			short n,		//���-�� ���. �����
			RELATION rel, ...	//������ �����
		);
	};

	struct FST		//������������������� �������� �������
	{
		char* string;		//������� (������, ����������� 0x00)
		short position;		//������� ������� � �������
		short nstates;		//���������� ��������� ��������
		NODE* nodes;		//���� ��������� [0] - ��������� ���������, [nstates-1 ] - ��������
		short* rstates;		//��������� ��������� �������� �� ������ �������
		FST(
			char* s,		//�������
			short ns,		//���������� ���������
			NODE n, ...		//������ ���������
		);
	};

	bool execute(		//��������� ������������� �������
		FST& fst		//�����. �������� �������
	);
};

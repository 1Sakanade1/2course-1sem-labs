#pragma once

#define LEXEMA_FIXSIZE  1			//������������� ������ �������
#define	LT_MAXSIZE		4096		// ������������ ���������� ����� � ������� ������	
#define	LT_TI_NULLXDX	-1	// ��� �������� ������� ���������������				
#define	LEX_INTEGER		't'			// ������� ��� integer
#define	LEX_STRING		't'			// ������� ��� string
#define	LEX_ID			'i'			// ������� ��� ��������������
#define	LEX_LITERAL		'l'			// ������� ��� ��������
#define	LEX_FUNCTION	'f'			// ������� ��� function
#define	LEX_DECLARE		'd'			// ������� ��� declare
#define	LEX_RETURN		'r'			// ������� ��� return
#define	LEX_PRINT		'p'			// ������� ��� print
#define	LEX_STRLEN		'e'			// ������� ��� strlen
#define	LEX_SEMICOLON	';'			// ������� ��� ;
#define	LEX_COMMA		','			// ������� ��� ,
#define	LEX_LEFTBRACE	'{'			// ������� ��� {
#define	LEX_RIGHTBRACE	'}'			// ������� ��� }
#define	LEX_LEFTHESIS	'('			// ������� ��� (
#define	LEX_RIGHTHESIS	')'			// ������� ��� )
#define	LEX_PLUS		'+'			// ������� ��� +
#define	LEX_MINUS		'-'			// ������� ��� -
#define	LEX_STAR		'*'			// ������� ��� *
#define	LEX_DIRSLASH	'/'			// ������� ��� /
#define	LEX_EQUAL_SIGN	'='			// ������� ��� =

#define PLUS '+'
#define MINUS '-'
#define STAR '*'
#define DIRSLASH '/'


namespace LT									// ������� ������
{
	struct Entry								// ������ ������� ������
	{
		char lexema;							// �������
		int sn;									// ����� ������ � �������� ������
		int idxTI;								// ������ � ������� ��������������� ��� LT_TI_NULLIDX
		Entry();
		Entry(const char lex, int str_n, int idxTI);
	};

	struct LexTable								// �������� ������� ������
	{
		int maxsize;							// ������� ������� ������ < LT_MAXSIZE
		int size;								// ������� ������ ������� ������ < maxsize
		Entry* table;							// ������ ����� ������� ������


		Entry GetEntry(								// �������� ������ ������� ������
			int n									// ����� ���������� ������
		);

		LexTable();
	};

	void Add(									// �������� ������ � ������� ������
		LexTable& lextable,						// ��������� ������� ������
		Entry entry								// ������ ������� ������
	);
	void PrintLexTable(LexTable& lextable, IT::IdTable& idtable, const wchar_t* in);
	void Delete(LexTable& lextable);			// ������� ������� ������ (���������� ������)
};
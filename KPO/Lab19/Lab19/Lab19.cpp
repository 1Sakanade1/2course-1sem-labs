#include "stdafx.h"
#include "FST.h"

//int _tmain(int argc, TCHAR* argv[])
//{
//	setlocale(LC_ALL, "rus");
//
//	char str1[] = "aaabbbaba";
//	char str2[] = "aaabbbabba";
//
//	FST::FST fst1(
//		str1,
//		4,
//		FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
//		FST::NODE(1, FST::RELATION('b', 2)),
//		FST::NODE(1, FST::RELATION('a', 3)),
//		FST::NODE()
//	);
//
//	if (FST::execute(fst1))
//		std::cout << "Цепочка " << fst1.string << " распознана" << std::endl;
//	else std::cout << "Цепочка " << fst1.string << " не распознана" << std::endl;
//
//	FST::FST fst2(
//		str2,
//		4,
//		FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
//		FST::NODE(1, FST::RELATION('b', 2)),
//		FST::NODE(1, FST::RELATION('a', 3)),
//		FST::NODE()
//	);
//
//	if (FST::execute(fst2))
//		std::cout << "Цепочка " << fst2.string << " распознана" << std::endl;
//	else std::cout << "Цепочка " << fst2.string << " не распознана" << std::endl;
//
//
//
//	system("pause");
//	return 0;
//}


int _tmain(int argc, TCHAR* argv[])
{
	setlocale(LC_ALL, "rus");
	//return - a ; space - b; calc - c; print - d;end - e



	//return; ??? calc; ??end;
	//return; ? calc; print; calc; ?end;
	//return; ?????print; ?????end;
	//return; ??print; ??end;
	//return; calc; ?? end;
	//return; ?print; calc; ?end;
	//return; ?calc; calc; ?end;





	char str1[] = "abbbccdcdbe";
	char str2[] = "abbbcbbe";
	char str3[] = "abcdcbe";
	char str4[] = "abbbdbbbe";
	char str5[] = "abbdbbe";
	char str6[] = "acbbe";
	char str7[] = "abdcbe";
	char str8[] = "abccbe";
	//задание 9 
	char str9[] = "abccb";
	//задание 10
	char str10[] = "abbceb";
	char str11[] = "abbcdcb";

	FST::FST fst1(
		str9,
		5,
		FST::NODE(1, FST::RELATION('a', 1)),
		FST::NODE(3, FST::RELATION('b', 1), FST::RELATION('c', 2), FST::RELATION('d', 2)),
		FST::NODE(3, FST::RELATION('c', 2), FST::RELATION('d', 2), FST::RELATION('b', 3)),
		FST::NODE(2, FST::RELATION('b', 3), FST::RELATION('e', 4)),
		FST::NODE()
	);

	if (FST::execute(fst1))
		std::cout << "Цепочка " << fst1.string << " распознана" << std::endl;
	else std::cout << "Цепочка " << fst1.string << " не распознана" << std::endl;




	system("pause");
	return 0;
}
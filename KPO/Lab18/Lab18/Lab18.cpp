
#include <iostream>
#include <string>
#include <stack>

using namespace std;

string removespacebars(string str) {
	string res;
	for (char c : str) if (c != ' ') res += c;
	str = res;

	return str;

}



bool isexpressionvalid(string str) {

	for (int i = 0; i < str.length()-1; i++)
	{
		if (str[i] == '+' && str[i + 1]=='+' || str[i] == '-'&& str[i + 1] == '-' || str[i] =='/'&& str[i + 1] == '/' || str[i]=='*'&& str[i + 1] == '*')
		{
			cout << "expression contain mistakes. It cannot be transformed into PolishNotation\n";
			return false;
			break;
		}
	}
	cout << "expression transformed into PolishNotation \n";
	return true;


}






bool PolishNotation(string inputstr){
	stack <char> stackcont;


	string str = removespacebars(inputstr);

	if (!isexpressionvalid(str))
	{
		return false;
	}

	string result;

	bool out = true;

	int resultpos = 0;

	


	for (int i = 0; i < str.length(); i++) {


			if (str[i] == '*' || str[i] == '/'|| str[i] == '+' || str[i] == '-'|| str[i] == '(')
			{
				if (stackcont.empty() || stackcont.top() == '(') {
					stackcont.push(str[i]);
				}
				
				else if (stackcont.top()!='(')//в вершине стека / + - *
				{
						if (str[i]=='+'||str[i]=='-')
						{
							if(stackcont.top() == '*'|| stackcont.top() == '/' || stackcont.top() == '+' || stackcont.top() == '-'  ) {
								
								result += stackcont.top();
								stackcont.pop();

							}
								stackcont.push(str[i]);
						}
						else if (str[i] == '*' || str[i] == '/')
						{
							if (stackcont.top() == '*' || stackcont.top() == '/' )
							{
								result += stackcont.top();
								stackcont.pop();
							}
							stackcont.push(str[i]);
						}
						else if (str[i] == '(')
						{
							stackcont.push(str[i]);
						}
				}

				
			}

			else if (str[i] == ')') {
				while (stackcont.top() != '(')
				{
					result += stackcont.top();

					stackcont.pop();
				}
				stackcont.pop();
			}
			else 
			{

				result += str[i];

			}

	}

	while(!stackcont.empty())
	{
		result += stackcont.top();
		if (stackcont.top() == '(') {
			out = false;
		}
		stackcont.pop();
	}


	cout << "\n \n" << result;

	return out;
}


int main()
{
	string expression1 = "1+(2+3/(6+7/(8+9)))+4*5";

	PolishNotation(expression1);



}


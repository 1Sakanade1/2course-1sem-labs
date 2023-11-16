using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;

public static class Lab6
{
    public static string HaffmanAdd(string str)
    {
        string result="1";
        for(int j = 0; j < str.Length;j++)
        {
            if (j == (str.Length - 1))
            {
                result += "1";
            }
            else
            {
                result += "0";
            }
        }

        

        return result;
    }


    public static void Haffman(string inputstr)
    {
        int length = 0;

        Dictionary<char, int> dictionarys = inputstr.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()); // создаем словарь key - value из строки

        var sortedDict = from entry in dictionarys orderby entry.Value ascending select entry;                 //сортируем(перепробовал куча методов, этот первый, который заработал)
        Console.WriteLine("key - freq");
        foreach (KeyValuePair<char, int> keyValuePair in sortedDict)
        {
            Console.WriteLine("  " + keyValuePair.Key + " - " + keyValuePair.Value);
            length++;
        }

        int counter = 0;

        string[] HaffmanNotation = new string[length];

        //разбитие на бинарное дерево (хз)
        HaffmanNotation[0] ="0";

        for (int i = 1; i < length-1; i++)                    // разбиваем на графф хаффмана(как на вики) формула str[i] = str[i-1].length*"0" + "1" если ласт элемент, то без + 1
        {
            HaffmanNotation[i] = HaffmanAdd(HaffmanNotation[i - 1]);
        }

        // заполняем последний элемент
        HaffmanNotation[length-1] = "1";
        for (int i=1; i< length-1; i++)
        {
            HaffmanNotation[length-1] += "0";
        }
        //последний элемент заполнен

        string[] HaffmanResult = new string[length];
        int toresultcounter = length - 1;
        foreach (string str in HaffmanNotation)  
        {
            HaffmanResult[toresultcounter--] = str;
        }

            foreach (string str in HaffmanResult)
        {
            Console.WriteLine(str);
        }



        string HufResult = "";

        for(int i = 0; i < inputstr.Length; i++)
        {
            int outputcounter = 0;

            foreach (KeyValuePair<char, int> keyValuePair in sortedDict)
            {   
                outputcounter++;

                if(keyValuePair.Key == inputstr[i])
                {
                    HufResult+=(HaffmanResult[outputcounter-1]);
                }
            }
        }

        char[] temp = HufResult.ToCharArray(); //  реверс готовой строки 
        Array.Reverse(temp);
        HufResult = new string(temp);


        Console.WriteLine(HufResult);          

    }





}


class Program
{
    static void Main(string[] args)
    {
        string inputstr = "abracadabra";

        Lab6.Haffman(inputstr);
    }

}

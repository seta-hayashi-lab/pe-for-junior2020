// GaoYufan BinarySearch.cs

using System;
using System.IO;

class BinarySearch
{
    //JSONデータを読み込んで配列化する
    public int[] JsonToArray()
    {
        StreamReader reader = new StreamReader("sample.json");
        string line = reader.ReadLine();
        string[] strArray = line.Split(',');

        //string配列をint配列に変換
        int[] intArray = new int[strArray.Length];
        for(int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = int.Parse(strArray[i]);
        }
       
        Array.Sort(intArray);//ソート
        return intArray;
    }


    //BinarySearch
    public int Binary(int key)
    {
        int index = 0;
        int[] intArray = this.JsonToArray();//ソート済みの配列をget

        int min = 0;
        int max = intArray.Length - 1;

        while(min <= max)
        {
            int mid = min + (max - min) / 2;
            if(intArray[mid] == key)
            {
                index = mid;
                return index;
            }
            else if(intArray[mid] > key)
            {
                max = mid - 1;
            }
            else
            {
                max = mid + 1;
            }
        }
        return -1; //見つからなければ-1
    }
}
class Program
{
    public static void Main(string[] args)
    {
        BinarySearch binary = new BinarySearch();

        //入力を促すメッセージの表示して、数値を入力してもらう
        Console.Write("探査したい値は： ");
        var key = int.Parse(Console.ReadLine());

        int index = binary.Binary(key);
        Console.WriteLine(index);
    }
}
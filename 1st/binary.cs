using System;
using System.IO;


class json
{
    public static void Main()
    {
        //読み込み
        StreamReader json = new StreamReader("sample.json");
        string line;
        while((line = json.ReadLine()) != null)
        {
            string[] num = line.Split(',');

            //int配列を作成
            int[] a = new int[num.Length];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = int.Parse(num[i]);
            }
            //小→大のソート
            Array.Sort(a);
        }
        json.Close();

    }
}
  

class binary
{
    static int BinarySearch<a>(a[] array, a target)
    {
        var min = 0;
        var max = array.Length - 1;

        Console.WriteLine("検索したい数値：　");
        int t = int.Parse(Console.ReadLine());

        while(min <= max)
        {
            var mid = min + (max - min) / 2;
            if(t > mid)//中央値より大きい
            {
                min = mid + 1;
                break;
            }
            if(t < mid)//中央値より小さい
            {
                max = mid - 1;
                break;
            }
            if(t == mid)//中央値と同じ
            {
                return mid;
            }
            return t;
        }
        return -1;

    }
}
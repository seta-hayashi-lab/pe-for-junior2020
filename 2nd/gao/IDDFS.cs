using System;
using System.IO;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;


class IterativeDeepening
{
    //JSONデータを読み込んで配列化する
    public int[] JsonToArray()
    {
        StreamReader reader = new StreamReader("sample2.json");
        string line = reader.ReadLine();
        string[] strArray = line.Split(',');

        //string配列をint配列に変換
        int[] intArray = new int[strArray.Length];
        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = int.Parse(strArray[i]);
        }

        Array.Sort(intArray);
        return intArray;
    }

    //IDDFS
    public int[] IDDFS(int key)
    {
        int[] intArray = this.JsonToArray();
        int depth = 0;
        var stack = new Stack<int[]>();//！！ネットで調べたコードをそのままコピペしたが、赤線がついてる

        while(depth <= intArray.Length)
        {
            //[]を作って、スタックに投入
            List<int[]> list_ans = new List<int[]>();
            int[] arr = new int[0];
            list_ans.Add(arr);
            stack.Push(list_ans);

            // スタックの末尾から全てのを取り出す
            while (stack.Count > 0)//！！ネットで調べたコードをそのままコピペしたが、赤線がついてる
            {
                int[] pop = stack.Pop();

                int sum = 0;
                for(int i = 0; i < pop.Length; i++)
                {
                    sum += pop[i];
                }

                //sumと目標和が一致するときreturn
                if(sum == key)
                {
                    return pop;
                }

                //stackにノードを追加
                //[]の場合
                if (stack.Pop == null)
                {
                    for(int i = 0; i < intArray.Length; i++)
                    {
                        arr[0] = intArray[i];
                        list_ans.Add(arr);
                    }
                    stack.Push(list_ans);
                }
                //[]でない場合、末尾のを取り出して、未探索のものを追加
                else
                {
                    int max = list_ans.Count - 1;
                    int num = list_ans[max][0];

                    for (int i = list_ans.Count - 1; i <= max + max; i++)
                    {
                        arr[0] = num;
                        for(int j = 1; j < intArray.Length; j++)
                        {
                            arr[1] = intArray[i];
                            list_ans.Add(arr);
                        }
                    }
                    stack.Push(list_ans);
                }
            }
            depth++;
        }

        int[] no_ans = new int[1] { 0 };
        return no_ans;
            
    }
}

class Program
{
    public static void Main(string[] args)
    {
        IterativeDeepening iddfs = new IterativeDeepening();

        //入力を促すメッセージの表示して、数値を入力してもらう
        Console.Write("探査したい和は： ");
        var key = int.Parse(Console.ReadLine());

        int[] ans = iddfs.IDDFS(key);
        if(ans[0] == 0)
        {
            Console.WriteLine("no answer");
        }
        else
        {
            Console.Write("{");
            for(int i = 0; i < ans.Length - 1; i++)
            {
                Console.Write(ans[i] + ",");
            }
            Console.Write(ans[ans.Length-1] + "}" );
        }
    }
}
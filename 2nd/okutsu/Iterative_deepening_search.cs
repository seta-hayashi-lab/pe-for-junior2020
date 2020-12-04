// 20201119 奥津暁夫

using System;
using System.IO;
using System.Collections.Generic;

namespace Iterative_deepening_search
{
    class Solver
    {
        public int[] function1() // jsonファイルを開き，数字の入ったint配列を返す関数
        {
            StreamReader reader = new StreamReader("sample2.json"); // jsonファイル読み込み

            string line = reader.ReadLine(); // 読み込んだ文をlineに代入

            string[] number_list_string = line.Split(','); // ,区切りで分割し，string型の配列に代入

            int[] number_list_int = new int[number_list_string.Length]; // 各数字がint型で入る配列

            number_list_int[0] = int.Parse(number_list_string[0].Split('[')[1]); // 最初と，

            number_list_int[number_list_string.Length - 1] = int.Parse(number_list_string[number_list_string.Length-1].Split(']')[0]); // 最後だけ ] を取り除く

            for (int i = 1; i < number_list_int.Length - 1; i++)
            {
                number_list_int[i] = int.Parse(number_list_string[i]); // 他はstring配列から持ってきてintに変換して代入
            }

            return number_list_int;
        }








        public int[] function2(int Sum) // 反復深化探索を行い，部分和Sumになる組み合わせを探す関数
        {
            int Depth = 0; // 深さ

            int[] used_numbers = this.function1(); // function1によって使える数字のリストを届けてもらう

            Stack<int[]> s = new Stack<int[]>(); // スタック生成

      




            // 反復深化探索開始

            while (Depth <= used_numbers.Length) // 深さは使える数字の数まである
            {
                //Console.WriteLine();
                //Console.WriteLine("Depth : " + Depth);


                int[] empty_array = new int[0]; // 最初にスタックに入れる空リスト

                s.Push(empty_array); // 空リスト(根ノード)をスタックに入れる


                while (s.Count != 0) // Sumになる組み合わせが見つからなければ，スタックが空(s.Count == 0)になるまで繰り返す
                {
                    // まずはスタックの末尾から取り出して確認

                    int[] checked_list = s.Pop();　// スタックの末尾から取り出す





                    /*Console.Write("Pop number: ");
                    for (int i = 0; i < checked_list.Length; i++)
                    {
                        Console.Write(checked_list[i] + ", "); 
                    }
                    Console.WriteLine();*/






                    int total = 0; // 取り出したリストの要素の合計

                    for (int i = 0; i < checked_list.Length; i++) // 取り出したリストの要素の合計を求める
                    {
                        total += checked_list[i];
                    }

                    if (total ==  Sum) // 取り出したリストの要素の合計がSumであれば，取り出したリストを返す
                    {
                        return checked_list;
                    }






                    // checked_listの子で未探索のものを，全て逆順でスタックに追加していく(子はchecked_listに，checked_listの最後の要素より大きい数字をused_numbersの最後の方から一つ選んで入れたもの)

                    if (checked_list.Length <= Depth - 1) // ただし，スタックへの子ノードの一斉追加は，要素数がDepth-1以下のノードのみできる
                    {
                        if (checked_list.Length == 0) // checked_listが[]の場合は個別に対応
                        {
                            for (int i = used_numbers.Length - 1; i >= 0; i--) // used_numberの後ろからスタックに入れていく
                            {
                                int[] new_list = new int[1]; // 要素数１のリストを作る
                                new_list[0] = used_numbers[i]; // used_numbersから選んだ値を入れる
                                s.Push(new_list); // スタックに入れる






                                /*Console.Write("Push number: ");
                                for (int j = 0; j < new_list.Length; j++)
                                {
                                    Console.Write(new_list[j] + ", ");
                                }
                                Console.WriteLine();*/









                            }
                        }
                        else
                        {

                            int checked_list_last_number = checked_list[checked_list.Length - 1]; // checked_listの最後の要素の値を調べる

                            for (int i = used_numbers.Length - 1; used_numbers[i] > checked_list_last_number; i--)
                            {
                                // スタックに追加するため，checked_listにused_numberから選んだ値を一つ追加した新しいリスト(new_list)を作る

                                int[] new_list = new int[checked_list.Length + 1];

                                for (int j = 0; j < checked_list.Length; j++) // new_listの先頭から，最後から二番目まではchecked_listの要素を写す
                                {
                                    new_list[j] = checked_list[j];
                                }

                                new_list[new_list.Length - 1] = used_numbers[i]; // new_listの最後の要素を，used_numbersから選んだ値にする

                                s.Push(new_list);






                                /*Console.Write("Push number: ");
                                for (int j = 0; j < new_list.Length; j++)
                                {
                                    Console.Write(new_list[j] + ", ");
                                }
                                Console.WriteLine();*/








                            }

                        }

                    }
                }
                Depth++; // 次は一つ深いところまで探す
            }
            

            // Sumになる組み合わせが見つからなかった場合，要素数１，中身"0" のint配列，not_fundが返される
            int[] not_found = new int[1];
            not_found[0] = 0;
            return not_found;
        }
    }













    class MainClass
    {
        public static void Main(string[] args)
        {
            Solver solver = new Solver();

            Console.Write("Sum : "); // 部分和(Sum)の入力

            int Sum = int.Parse(Console.ReadLine()); // 入力値をintに変換

            int[] answer = solver.function2(Sum); // function2を使って探索

            if (answer.Length==1 && answer[0]==0)  // not_foundが返ってきた時
            {
                Console.WriteLine("answer : false"); // 答えを表示
            }
            else
            {
                Console.Write("answer : "); // 答えを表示
                for (int i = 0; i < answer.Length; i++)
                {
                    Console.Write(answer[i] + ", "); // 答えを表示
                }
            }
        }
    }
}

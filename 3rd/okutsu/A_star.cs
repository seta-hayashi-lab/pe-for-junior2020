using System;
using System.IO;
using System.Collections;

namespace A_star
{
    class solver
    {
        public string[,] json_reader() // jsonファイルを開き，string型の数字の入った配列を返す関数
        {
            StreamReader reader = new StreamReader("sample3.json"); // jsonファイル読み込み

            string line = reader.ReadLine(); // 読み込んだ文をlineに代入

            string line_except_kakko1 = line.Replace("[", ""); // [ を排除

            string line_except_kakko2 = line_except_kakko1.Replace("]", ""); // ]を排除

            string[] number_list_string = line_except_kakko2.Split(',');

            /*for (int i = 0; i < number_list_string.Length; i++)
            {
                Console.WriteLine(number_list_string[i]);
            }*/

            string[,] start_situation = new string[9,3];

            int index = 0; // number_list_stringのインデックス

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (number_list_string[index] == null)
                    {
                        start_situation[i, j] = null;
                        index++;
                    }
                    else
                    {
                        start_situation[i, j] = number_list_string[index];
                        index++;
                    }
                }
            }
            return start_situation;
        }



        public string[,] UP(string[,] situation) // 渡された配列に対してUPして返す関数
        {
            int null_is_here = -1; // nullのある場所を示す値(0~8)

            // nullのある場所を探す
            for (int i = 0; i < 9; i++)
            {
                if (situation[i, 2] == null)
                {
                    null_is_here = i;
                }
            }

            if (null_is_here == 6 || null_is_here == 7 || null_is_here == 8) // upできない場合
            {
                return situation; // 何もせずに返す
            }
            else // upできる時
            {
                situation[null_is_here, 2] = situation[null_is_here + 3, 2]; // 下のマスの数を入れる
                situation[null_is_here + 3, 2] = null; // 下のマスをnullにする
                return situation;
            }
        }

        public string[,] DOWN(string[,] situation) // 渡された配列に対してDOWNして返す関数
        {
            int null_is_here = -1; // nullのある場所を示す値(0~8)

            // nullのある場所を探す
            for (int i = 0; i < 9; i++)
            {
                if (situation[i, 2] == null)
                {
                    null_is_here = i;
                }
            }

            if (null_is_here == 0 || null_is_here == 1 || null_is_here == 2) // downできない場合
            {
                return situation; // 何もせずに返す
            }
            else // downできる時
            {
                situation[null_is_here, 2] = situation[null_is_here - 3, 2]; // 上のマスの数を入れる
                situation[null_is_here - 3, 2] = null; // 上のマスをnullにする
                return situation;
            }
        }

        public string[,] RIGHT(string[,] situation) // 渡された配列に対してRIGHTして返す関数
        {
            int null_is_here = -1; // nullのある場所を示す値(0~8)

            // nullのある場所を探す
            for (int i = 0; i < 9; i++)
            {
                if (situation[i, 2] == null)
                {
                    null_is_here = i;
                }
            }

            if (null_is_here == 0 || null_is_here == 3 || null_is_here == 6) // rightできない場合
            {
                return situation; // 何もせずに返す
            }
            else // rightできる時
            {
                situation[null_is_here, 2] = situation[null_is_here - 1, 2]; // 左のマスの数を入れる
                situation[null_is_here - 1, 2] = null; // 左のマスをnullにする
                return situation;
            }
        }

        public string[,] LEFT(string[,] situation) // 渡された配列に対してLEFTして返す関数
        {
            int null_is_here = -1; // nullのある場所を示す値(0~8)

            // nullのある場所を探す
            for (int i = 0; i < 9; i++)
            {
                if (situation[i, 2] == null)
                {
                    null_is_here = i;
                }
            }

            if (null_is_here == 2 || null_is_here == 5 || null_is_here == 8) // leftできない場合
            {
                return situation; // 何もせずに返す
            }
            else // leftできる時
            {
                situation[null_is_here, 2] = situation[null_is_here + 1, 2]; // 右のマスの数を入れる
                situation[null_is_here + 1, 2] = null; // 右のマスをnullにする
                return situation;
            }
        }




        public ArrayList run(string[,] first_situation) // 初期状態から終了状態までのオペレーターを調べて返す関数
        {
            // 準備(必要なリストや変数を作る)
            ArrayList situations = new ArrayList(); // 状態を表す配列が入るリストを作る
            ArrayList situations2 = new ArrayList(); // 状態を表す配列が入るリストをもう一つ作る
            ArrayList operators = new ArrayList(); // 適用するオペレータが入るリストを作る
            ArrayList functions = new ArrayList(); // 評価関数が入るリストを作る(インデックスがsituations, situations2と対応している)
            int phase = 0; // 手数
            int not_match = 0; // 目標状態と異なるマスの数


            // リストの最初に初期状態を入れる
            situations.Add(first_situation);


            // 初期状態の評価関数を求める
            for (int i = 0; i < 8; i++) // h(x)を求める
            {
                if (first_situation[i, 2] != (i+1).ToString())
                {
                    not_match++;
                }
            }
            functions.Add(phase+not_match); // 初期状態のf(x)をメモ



            // 状態リストから先頭の要素(評価関数が最小の要素)を取り出し，処理する


            return operators;
        }









    }










    class MainClass
    {
        public static void Main(string[] args)
        {
            solver Solver = new solver();

            string[,] first_situation = Solver.json_reader();

            Console.WriteLine(Solver.run(first_situation));

            
        }
    }
}

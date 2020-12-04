// 20201119 奥津暁夫

using System;
using System.IO;

namespace BinarySearch
{
    class Solver
    {
        public int[] function1() // jsonファイルを開き，数字の入ったint配列を返す関数
        {
            StreamReader reader = new StreamReader("sample.json"); // jsonファイル読み込み
            string line = reader.ReadLine(); // 読み込んだ文をlineに代入
            string[] number_list_string = line.Split(','); // ,区切りで分割し，string型の配列に代入

            int[] number_list_int = new int[number_list_string.Length]; // 各数字がint型で入る配列
            number_list_int[0] = 20; // 最初と，
            number_list_int[number_list_string.Length - 1] = 638; // 最後だけ事前に入れておく(]の処理方法が分からなかった)

            for (int i = 1; i < number_list_int.Length - 1; i++)
            {
                number_list_int[i] = int.Parse(number_list_string[i]); // 他はstring配列から持ってきて変換して代入
            }

            Array.Sort(number_list_int); // 配列を昇順にソート
            return number_list_int;
        }


       public int function2(int target_number) // 任意の数値を引数とし，二分探索をする．見つかればindexを，見つからなければ-1を返す
        {
            int index_number = -1; // target_numberのindex
            int[] number_list = this.function1(); // function1により，jsonファイルを処理したソート済みint配列が届く

          
            // 二分探索開始
            int min = 0; // このindexから，
            int max = number_list.Length - 1; // このindexまでを探索します

            while(min <= max)
            {
                int mid = min + ((max - min) / 2); // 探索範囲の真ん中のindex

                if (number_list[mid] < target_number) // target_numberが中央値より大きい場合
                {
                    min = mid + 1;
                }
                else if (target_number < number_list[mid]) // target_numberが中央値より小さい場合
                {
                    max = mid - 1;
                }
                else // target_numberが中央値と一致した場合
                {
                    index_number = mid;
                    return index_number;
                }
            }
            return index_number;
        }
    }












    class MainClass
    {
        public static void Main(string[] args)
        {
            Solver solver = new Solver();

            Console.Write("target number : "); // 探す値(target_number)の入力
            int target_number = int.Parse(Console.ReadLine());
            int index_number = solver.function2(target_number);
            Console.WriteLine("index number : " + index_number);
        }
    }
}

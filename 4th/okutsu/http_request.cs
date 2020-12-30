using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Json;
using System.Runtime.Serialization;


class Program
{
    async Task<string[]> HtmlContent(HttpClient clinet) // ページにアクセスして内容を受け取り，別の関数に解析させて答えがついていない質問ノードの一覧を調べ，その結果を返す関数
    {
        string url = "https://raw.githubusercontent.com/seta-hayashi-lab/pe-for-junior2020/master/4th/sample4.json";

        HttpResponseMessage response = null;
        //Console.WriteLine("Connect {0}...", url);
        try
        {
            response = await clinet.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync(); // ページの内容が返ってくる

            string[] list = this.list_maker(responseBody); // 読み込んだ内容(string)を解析させ，答えがついていない質問ノードの一覧を受け取る

            return list; // 配列化した内容を返す
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception Message :{0} ", ex.Message);
        }
        return null;
    }


    string[] list_maker(string content) // 内容についてのstringを解析し，答えがついていない質問ノードの一覧を返す関数(どうしてもjsonの扱いがわからなかったので，なんとかしてstringを処理する)
    {
        // おおまかにnodesとedgesを分ける
        string s1 = content.Replace("\"edges\"", "@");
        //Console.WriteLine(s1);
        string[] s2 = s1.Split('@');
        //Console.WriteLine("[0]:"+s2[0]);
        //Console.WriteLine("[1]:" + s2[1]);


        // nodesの方で，おおまかにnodeごとの情報に分ける
        string s3 = s2[0].Replace("\"node\"", "@");
        string[] s4 = s3.Split('@'); // s4[0]だけいらない
        /*for (int i = 0; i< s4.Length; i++)
        {
            Console.WriteLine(i+":"+s4[i]);
        }*/


        // それぞれのノードの情報から，idとタイプのみ抽出する
        string[] node_id = new string[s4.Length-1]; // ノードのidが入る配列
        string[] node_type = new string[s4.Length - 1]; // ノードのタイプが入る配列
        for (int i = 1; i < s4.Length; i++)
        {
            string[] s5 = s4[i].Split(',');

            string[] s6 = s5[0].Split(':');

            Console.WriteLine(s6[3]);
        }





        string[] null_list = new string[1];
        return null_list;
    }



    static void Main(string[] args)
    {
        Program app = new Program();

        HttpClient client = new HttpClient();

        
        string[] result = app.HtmlContent(client).Result;
        //Console.WriteLine(result);


        
    }

    
}
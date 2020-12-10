//
//  ViewController.swift
//  Ensyuu2
//
//  Created by kslab on 2020/12/08.
//

import UIKit

class ViewController: UIViewController , UITextFieldDelegate{


    @IBOutlet weak var textField: UITextField!
   
    @IBOutlet weak var label: UILabel!
    
    @IBOutlet weak var Label2: UILabel!
    
    override func viewDidLoad() {
        super.viewDidLoad()
    }
    
     
    
    override func viewDidAppear(_ animated: Bool) {
        super.viewDidAppear(animated)
        
        //もしUserDefaultsに値が登録されてるなら
        if let _ = UserDefaults.standard.object(forKey: "text") as? String {
            //labelに表示
            label.text = (UserDefaults.standard.object(forKey: "text") as! String)
        }
        
    }

    @IBAction func registerButton(_ sender: Any) {
        //UserDefaultsに値を登録
        UserDefaults.standard.set(textField.text, forKey: "text")
        //登録された値を表示する＞str取得
        let str:String =  (UserDefaults.standard.object(forKey: "text") as! String)
                
        let kazu:Int = Int(str)!//入力した値
        let json:[Int] = [1,3,5,7,9,12]
        //var kensaku:[[Int]] = [[],[]]
        
        var a = 0
        var Depth = 0
        var depth = Depth
        // kensaku(空配列)を用意，jsonの配列を先頭から減らして追加していく
        
        for a in 0..<json.count{
            /* 配列にどんどん追加して行きたかったけど確認方法が分からない
            kensaku[a].append(contentsOf:json[a...(json.count-1)])*/
          
            //一旦手動で入力
            let kensaku = [[1,3,5,7,9,12],[3,5,7,9,12],[5,7,9,12],[7,9,12],[9,12],[12]]
            var check = kensaku[depth][a]
            if check == kazu {
                label.text = String(check)
                return
            }else {
                
            }
            
        }
        
        
        
        //最終的な配列を表示する場所
        //label.text = String(kazu * 3)
    }
    
    //画面をタップした時
    override func touchesBegan(_ touches: Set<UITouch>, with event: UIEvent?) {
        //キーボードを閉じる
        textField.resignFirstResponder()
    }


}


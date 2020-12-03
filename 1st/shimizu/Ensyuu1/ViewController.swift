//
//  ViewController.swift
//  Ensyuu1
//
//  Created by kslab on 2020/12/03.
//

import UIKit

class ViewController: UIViewController, UITextFieldDelegate {
    // TextField
    //促す部分
    @IBOutlet weak var Label: UILabel!
    //入力場所
    @IBOutlet weak var textField: UITextField!
    //検索結果を表示する場所
    @IBOutlet weak var Kouho: UILabel!
    
    @IBOutlet weak var Kekka: UILabel!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
        textField.delegate = self
    
    }
    
    //テキストの入力
    func textField(_ textField: UITextField, shouldChangeCharactersIn range:NSRange, replacementString string:String) -> Bool {
        let tmpStr = textField.text! as NSString
        let replacedString = tmpStr.replacingCharacters(in: range, with: string)

        
        if replacedString == ""{
            //変更後が空ならば入力を促す
            Kouho.text = "数字を入力してください"
        }else{
            //変更後の値を計算してラベルに表示する
            if let num = Int(replacedString){
                let str1 = "検索したい数字："
                let str2 = String(num)
                let str3 = str1 + str2
                Kouho.text = str3
            }
        }
        return true
    }
    
    //クリアボタンで実行されるデリゲートメソッド
    func textFieldShouldClear(_ textField: UITextField) -> Bool {
        Kouho.text = "0"
        return true
    }
    
    //タップするとキーボードが下がる
    func textFieldShouldReturn(_ textField: UITextField) -> Bool {
        //キーボードを下げる
        view.endEditing(true)
        return false
    }

    @IBAction func pushButton(_ sender: Any) {
        //let JsonData = [ 20, 191, 6, 52, 5, 182, 4, 129, 202, 483, 875, 749, 54, 618, 649, 739, 337, 575, 464, 267, 943, 645, 581, 21, 762, 100, 742, 124, 338, 932, 942, 815, 5, 515, 994, 395, 27, 940, 907, 817, 390, 523, 561, 554, 138, 310, 478, 109, 124, 789, 906, 461, 807, 166, 253, 472, 235, 506, 120, 267, 754, 964, 63, 177, 448, 788, 693, 183, 996, 610, 932, 326, 110, 580, 933, 756, 37, 852, 681, 593, 687, 827, 816, 579, 877, 942, 512, 197, 204, 887, 952, 79, 63, 425, 56, 775, 245, 808, 2, 383, 880, 468, 724, 800, 737, 918, 165, 66, 439, 534, 665, 187, 850, 315, 260, 976, 111, 370, 270, 694, 753, 299, 551, 210, 229, 205, 965, 795, 859, 444, 693, 765, 482, 773, 976, 778, 458, 43, 77, 332, 734, 285, 866, 899, 303, 889, 432, 210, 266, 757, 901, 572, 803, 919, 722, 327, 617, 152, 712, 745, 977, 76, 291, 930, 227, 651, 319, 796, 204, 859, 709, 558, 117, 987, 289, 514, 106, 387, 951, 587, 661, 197, 701, 0, 619, 559, 421, 713, 329, 306, 636, 591, 412, 733, 775, 491, 974, 458, 100, 251, 353, 683, 699, 202, 793, 748, 666, 226, 607, 51, 579, 108, 660, 531, 590, 118, 330, 328, 476, 393, 883, 321, 888, 986, 643, 476, 939, 923, 787, 454, 631, 487, 697, 666, 967, 269, 737, 603, 720, 600, 237, 234, 869, 337, 356, 867, 542, 920, 977, 915, 855, 309, 704, 586, 195, 105, 503, 553, 948, 561, 157, 295, 431, 604, 182, 63, 194, 677, 559, 171, 49, 396, 713, 103, 235, 666, 963, 161, 268, 111, 564, 994, 982, 13, 967, 522, 487, 576, 515, 783, 551, 266, 192, 840, 965, 492, 923, 912, 603, 417, 938, 738, 122, 731, 132, 852, 951, 499, 411, 385, 625, 445, 657, 270, 610, 415, 258, 592, 883, 1, 369, 719, 486, 252, 252, 772, 356, 580, 978, 561, 540, 999, 142, 289, 883, 93, 456, 918, 571, 844, 661, 731, 270, 16, 968, 654, 736, 43, 580, 480, 544, 589, 42, 43, 548, 567, 545, 547, 603, 821, 398, 601, 359, 669, 134, 987, 476, 705, 891, 702, 279, 817, 209, 406, 50, 47, 489, 47, 76, 362, 171, 982, 893, 367, 65, 736, 842, 736, 184, 143, 770, 382, 46, 665, 105, 934, 751, 579, 579, 727, 669, 290, 667, 550, 311, 484, 631, 631, 627, 283, 588, 612, 681, 67, 684, 511, 435, 477, 703, 70, 198, 138, 674, 577, 687, 603, 499, 854, 468, 257, 850, 818, 716, 685, 428, 16, 409, 324, 862, 951, 864, 675, 538, 683, 152, 656, 455, 256, 671, 823, 804, 132, 0, 598, 562, 504, 838, 542, 721, 623, 257, 457, 990, 538, 716, 28, 491, 263, 265, 56, 383, 477, 435, 705, 627, 534, 360, 561, 826, 917, 512, 622, 925, 856, 810, 285, 265, 917, 904, 327, 499, 941, 5, 91, 917, 98, 72, 347, 63, 551, 303, 635, 969, 637, 535, 337, 668, 638 ]
        let JsonDataSorted = [1,2,3,4,5,6,7,8,9,10]//JsonData.sorted()
        
        let str:String = textField.text!
        let item:Int = Int(str)!
        var low = 0
        var high = JsonDataSorted.count - 1
        
        // 同じ値になるまでループ
        while (low <= high){
            let middle = Int(ceil(Double(low + high) / 2))
            let value = JsonDataSorted[middle]
            
            if value == item{
                Kekka.text = ("検索した数字はありました")
                
            }else if value < item{
                low = middle + 1
            }else{
                high = middle - 1
            }
        }
        Kekka.text = ("検索した数字はありませんでした")
    }
    
}


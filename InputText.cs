using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UIを扱う
using UnityEngine.SceneManagement;
//マップの大きさを指定するスクリプト
public class InputText : MonoBehaviour
{
    public Text txt;
    public InputField inputField;
    
    public static int map_size;
 
    void Start()
    {
        
    }
 
    //ボタンが押された時の処理
    public void OnClickStartButton()
    {
        //何も数値が入っていない場合
        if(inputField.text == ""){
            txt.text = "数値が入力されていません";
        }else{
        //なんかしら数字が入っている場合
            int name = int.Parse(inputField.text);
            if(name > 4 && name % 2 == 1){
                map_size = name;    //入力した数値をint型にして格納
                SceneManager.LoadScene("Game"); //ゲームシーンに移行
                //数値をマップサイズに反映
            }else{
                txt.text = "５以上の整数値を入力してください";
            }
        }
        inputField.text = "";
    }
}
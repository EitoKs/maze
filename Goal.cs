using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; //UIを扱う(追加)
using UnityEngine.SceneManagement;  //シーンロードのために追加
//ゴールしたときの処理を行うスクリプト
public class Goal : MonoBehaviour
{
    public GameObject GoalText; //ゴールテキストを設定
    public GameObject Human; //プレイヤーを設定
    private GameObject goal;

    void Start(){
        //初めはゴールテキストを非表示にしておく
        GoalText.SetActive(false);
    }

    void Update () {

    }
//プレイヤーがゴールオブジェクトと接触した時
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            //Debug.Log("ゲームクリア"); //コンソール確認用
            GoalText.SetActive(true); //ゴールテキストを表示する
            GetComponent<FPSController>().enabled = false; //FPSControllerを無効化して操作不能にしている
            goal = GameObject.Find("GameObject");
            goal.GetComponent<Sound>().enabled = false;
        }
    }

    //ここから下を追加
    public void GoTitle(){
        SceneManager.LoadScene("Title"); //ゲームシーンに移行
    }

    public void RetryGame(){
        SceneManager.LoadScene("Game"); //ゲームシーンに移行
    }
}

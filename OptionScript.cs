using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//操作説明パネルの操作に関するスクリプト
public class OptionScript : MonoBehaviour
{
    //操作説明のパネルを入れておく
    [SerializeField]
    private GameObject OptionPanel;

    void Start()
    {
        OptionPanel.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Return) && OptionPanel.activeSelf == true){
            OptionPanel.SetActive(false);
        }
    }

    public void OptionOpen(){
        OptionPanel.SetActive(true);
    }
}

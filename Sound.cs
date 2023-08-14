using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//音を発生させるスクリプト
//スペースキーを押すとゴールの方向から音が発生する。
public class Sound : MonoBehaviour
{
    public AudioClip audioSource;
    AudioSource SE;
    // Start is called before the first frame update
    void Start()
    {
        SE = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SE.PlayOneShot(audioSource);
        }
    }
}

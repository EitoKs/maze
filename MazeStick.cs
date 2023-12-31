using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//迷路をランダム生成するスクリプト
//タイトル画面で入力した数字×数字の大きさの迷路が生成される
//生成は棒倒し方によって行われている
public class MazeStick : MonoBehaviour
{
  public int max_z; //フィールドの縦幅。5以上の奇数にすること。
  public int max_x; //フィールドの横幅。5以上の奇数にすること。
  int z; //フィールド配列の縦の要素番号
  int x; //フィールド配列の横の要素番号
  int r; //乱数の値
  Object wall_out; //壁オブジェクト
  Object wall_in; //壁オブジェクト
  Object goal;  //追加：ゴールオブジェクト
  GameObject wallgo; //壁のゲームオブジェクト
  GameObject goalgo; //追加：ゴールオブジェクト

  //追加した部分
  float wall_y;  //内側の壁の高さ

  void Start()
  {
    max_x = InputText.map_size;
    max_z = InputText.map_size;

    int[,] field = new int[max_z,max_x]; //フィールド（0が通路で、1が壁。）
    wall_out = Resources.Load("Wall_Out"); //外の壁オブジェクトを読み込む。
    wall_in = Resources.Load("Wall_In"); //内の壁オブジェクトを読み込む。
    goal = Resources.Load("Goal"); //ゴールオブジェクトを読み込む

    if(max_x == 5 && max_z == 5) {
      wall_y = 5;
    } else {
      wall_y = 0;
    }

    //通路（0）の生成
    for(z=0; z<max_z; z=z+1) //フィールドの縦幅の分だけループする。
    {
      for(x=0; x<max_x; x=x+1) //フィールドの横幅の分だけループする。
      {
        field[z,x] = 0;
      }
    }

    //上下の外壁（1）の生成
    for(x=0; x<max_x; x=x+1) //フィールドの横幅の分だけループする。
    {
      field[0,x] = 1;
      field[max_z-1,x] = 1;
    }

    //左右の外壁（1）の生成
    for(z=0; z<max_z; z=z+1) //フィールドの縦幅の分だけループする。
    {
      field[z,0] = 1;
      field[z,max_x-1] = 1;
    }

    //棒倒し法を使った壁（1）の生成（1行めのみ）
    z = 2; //1行め
    for(x=2; x<max_x-1; x=x+2) //要素番号xが2から要素番号max_x-1の値まで、1マス飛ばしで棒倒し。
    {
      r = Random.Range(1,13); //乱数生成（r = 1から12のランダムな値）
      field[z,x] = 1; //中心から……
      if(r<=3) //rが3以下のとき
      {
        if(field[z-1,x]==0) //上に棒（壁）がなければ
        {
          field[z-1,x] = 1; //上に棒を倒す。
        }
        else if(field[z-1,x]==1) //上に棒（壁）があれば
        {
          x = x - 2; //棒を倒さずに、乱数生成をやり直す。
        }
      }
      if(r>=4 && r<=6) //rが4から6のとき
      {
        if(field[z+1,x]==0) //下に棒（壁）がなければ
        {
          field[z+1,x] = 1; //下に棒を倒す。
        }
        else if(field[z+1,x]==1) //下に棒（壁）があれば
        {
          x = x - 2; //棒を倒さずに、乱数生成をやり直す。
        }
      }
      if(r>=7 && r<=9) //rが7から9のとき
      {
        if(field[z,x-1]==0) //左に棒（壁）がなければ
        {
          field[z,x-1] = 1; //左に棒を倒す。
        }
        else if(field[z,x-1]==1) //左に棒（壁）があれば
        {
          x = x - 2; //棒を倒さずに、乱数生成をやり直す。
        }
      }
      if(r>=10) //rが10以上のとき
      {
        if(field[z,x+1]==0) //右に棒（壁）がなければ
        {
          field[z,x+1] = 1; //右に棒を倒す。
        }
        else if(field[z,x+1]==1) //右に棒（壁）があれば
        {
          x = x - 2; //棒を倒さずに、乱数生成をやり直す。
        }
      }
    }
    
    //棒倒し法を使った壁（1）の生成（2行め以降）
    for(z=4; z<max_z-1; z=z+2) //zの要素番号4から要素番号max_z-1まで、1マス飛ばしで棒倒し。
    {
      for(x=2; x<max_x-1; x=x+2) //xの要素番号2から要素番号max_x-1まで、1マス飛ばしで棒倒し。
      {
        r = Random.Range(1,13); //乱数生成（r = 1から12のランダムな値）
        field[z,x] = 1; //中心から……
        if(r<=4) //rが4以下のとき
        {  
          if(field[z+1,x]==0) //下に棒（壁）がなければ
          {
            field[z+1,x] = 1; //下に棒を倒す。
          }
          else if(field[z+1,x]==1) //下に棒（壁）があれば
          {
            x = x - 2; //棒を倒さずに、乱数生成をやり直す。
          }
        }
        if(r>=5 && r<=8) //rが5から8のとき
        {
          if(field[z,x-1]==0) //左に棒（壁）がなければ
          {
            field[z,x-1] = 1; //左に棒を倒す。
          }
          else if(field[z,x-1]==1) //左に棒（壁）があれば
          {
            x = x - 2; //棒を倒さずに、乱数生成をやり直す。
          }
        }
        if(r>=9) //rが9以上のとき
        {
          if(field[z,x+1]==0) //右に棒（壁）がなければ
          {
            field[z,x+1] = 1; //右に棒を倒す。
          }
          else if(field[z,x+1]==1) //右に棒（壁）があれば
          {
            x = x - 2; //棒を倒さずに、乱数生成をやり直す。
          }
        }
      }
    }

    field[0,1] = 0; //スタート地点の壁を撤去する。
    field[max_z-1,max_x-2] = 2; //ゴール地点の壁を撤去する。

    //壁の配置
    for(z=0; z<max_z; z=z+1) //フィールドの縦幅の分だけループする。
    {
      for(x=0; x<max_x; x=x+1) //フィールドの横幅の分だけループする。
      {
        if(field[z,x]==0) //通路なら
        {
          //何も配置しない。
        }
        else if(field[z,x]==1) //壁なら
        {
          //外側の座標なら外側の壁を生成
          if(x == 0 || x == max_x-1 || z == 0 || z == max_z-1) {
            wallgo = (GameObject)Instantiate(wall_out, new Vector3(5.0f*x,5.0f,5.0f*z), Quaternion.identity); //壁を配置する。
          } else {
            wallgo = (GameObject)Instantiate(wall_in, new Vector3(5.0f*x,wall_y,5.0f*z), Quaternion.identity); //壁を配置する。
          }
        }
        else if(field[z,x]==2)
        {
          goalgo = (GameObject)Instantiate(goal, new Vector3(5.0f*x-2.5f,3.95f,5.0f*z), Quaternion.identity); //壁を配置する。
        }
      }
    }
  }

  void Update()
  {
    
  }
}

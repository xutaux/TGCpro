using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{

    public float speed = 8f;           //移動速度
    public float movebleRange = 23f;   //可動範囲
    public Transform SettingCanvas;    //テキスト用変数
    float downspeed;                   //落下速度
    Rigidbody2D rb;                    //プレイヤー移動用変数
    Collider2D cb;                     //isTrigger用変数
    GameObject Item;                   //アイテム情報格納変数
    string tagnam;                     //アイテムのタグ名格納変数
    Vector2 Itmpos;                    //アイテム座標
    Vector2 nowpos;                    //プレイヤー座標
    float rot;                         //アイテム回転 
    public float Vcnt;                        //Vキーカウント変数
    float vectol;                      //アイテム貼り付け方向
    bool Setteing;                     //アイテム設置中フラグ
    public Item ItemScp;               //アイテムスクリプト変数

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        cb = GetComponent<Collider2D>();
        downspeed = 0;
        Vcnt = 0;
        vectol = 0;
        Setteing = false;
        SettingCanvas.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー移動操作
        if (Setteing == false)
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(transform.position + new Vector3(-0.45f, -0.55f), Vector2.right, 0.9f);
            if (hit.transform != null)
            {
                downspeed = 0;
                if (Input.GetButtonDown("Jump"))
                {
                    downspeed += 10.0f;
                    //transform.Translate(Vector3.up * 0.01f);
                }
            }
            else
            {
                downspeed += -0.3f;
            }
            nowpos = rb.position;
            nowpos += new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, downspeed * Time.deltaTime);
            rb.MovePosition(nowpos);
            if (Input.GetKeyDown(KeyCode.LeftArrow)) vectol = -2;
            if (Input.GetKeyDown(KeyCode.RightArrow)) vectol = 2;

        }
    }
}

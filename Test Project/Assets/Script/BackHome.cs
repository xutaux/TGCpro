using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackHome : MonoBehaviour {

    public float speed = 1.0f;
    private float time;
    private float TuchFlg;
    private SpriteRenderer image;
    Vector3 InitPos;

    // Use this for initialization
    void Start()
    {
        image = this.gameObject.GetComponent<SpriteRenderer>();
        InitPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        image.color = GetAlphaColor(image.color);
        if(TuchFlg == 1)
        {
            if(this.gameObject.transform.position.x > 12.7f)
            {
                this.gameObject.transform.Translate(-0.01f, 0, 0);
            }
            else
            {
                this.gameObject.transform.position = InitPos;
            }
        }
        else
        {
            this.gameObject.transform.position = InitPos;
        }
    }

    Color GetAlphaColor(Color color)
    {
        if (TuchFlg == 1)
        {
            time += Time.deltaTime * 5.0f * speed;
            color.a = Mathf.Sin(time) * 0.5f + 0.5f;
        }
        else
        {
            color.a = 255;
        }
        return color;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TuchFlg = 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TuchFlg = 0;
    }
}

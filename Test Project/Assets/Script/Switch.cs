using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public bool changeFlg = false;
    private ParticleSystem par;
    public GameObject Player;
    

	// Use this for initialization
	void Start () {
        par = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {

        if (changeFlg == true)
        {
            GameObject.Find("Player").GetComponent<Player>().enabled = false;
            GameObject.Find("Player").GetComponent<Past>().enabled = true;
            //AIM.SetActive(true);
            //GetComponent<kuriku>().enabled = true;

            if (Input.GetKeyUp(KeyCode.V))
            {
                //Instantiate(yuka);
                //Instantiate(yuka, new Vector3(transform.position.x + 1, transform.position.y, 0.0f), Quaternion.identity);
                Debug.Log("生成");
                GameObject.Find("Player").GetComponent<Past>().enabled = false;
                GameObject.Find("Player").GetComponent<Player>().enabled = true;
                //AIM.SetActive(false);
                //GetComponent<kuriku>().enabled = false;
                changeFlg = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            changeFlg = true;
            par.Play();
        }
		
	}
}

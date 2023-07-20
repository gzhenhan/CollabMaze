using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnds : MonoBehaviour
{   
    public GameObject EndMenu;

    void Start(){
        //EndMenu = GameObject.FindObjectOfType<Canvas2>().FindObjectOfType<EndMenu>();
        EndMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "end2" || collision.gameObject.name == "end"){
            Debug.Log("TriggerEnd");
            EndMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        
        if(collision.gameObject.name == "Coin" || collision.gameObject.name == "Coin2" || collision.gameObject.name == "Coin3" || collision.gameObject.name == "Coin4"){
            Debug.Log("TriggerCoin");
            Destroy(collision.gameObject);
        }
    }
}

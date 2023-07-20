using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{   
    public int damage = 2;
    public int summeDamage;

    void OnTriggerEnter2D(Collider2D hitInfo){
        //summeDamage = summeDamage + damage;
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null){
            //if(summeDamage <= 250){
                enemy.TakeDamageBlue(damage);
            //}
        }
        Debug.Log(hitInfo.name);
        Destroy(gameObject, 0.5f);
    } 

    void Update(){
        Debug.Log(summeDamage);
        Destroy(gameObject, 0.5f);
    }
}

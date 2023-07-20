using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject deathEffect;


    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void TakeDamageRed(int damage){
        if(currentHealth >= (maxHealth/2)){
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }

        if(currentHealth <= 0){
            Die();
        }
    }

    public void TakeDamageBlue(int damage){
        if(currentHealth <= (maxHealth/2)){
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }

        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Update(){
        Debug.Log(currentHealth);
    } 
}

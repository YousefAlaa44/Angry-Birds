using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 4f;
    public static int EnemiAlive = 0;

    void Start()
    {
        EnemiAlive++;
    }
  void OnCollisionEnter2D(Collision2D colinf)
    {
        if (colinf.relativeVelocity.magnitude > Health)
        {
            Die();
        }
        
    }
    void Die()
    {
        EnemiAlive--;
        if (EnemiAlive <= 0)
        {
            Debug.Log("Game Won!");
        }
        Destroy(gameObject);
    }
}

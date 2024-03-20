using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public void TakeDamage(float damageamount)
    {
        health -= damageamount;
        if (health <= 0f)
        {
            Died();
        }
    }
    void Died()
    {
        Destroy(gameObject); //För tillfället så förstör vi bara objektet
    }
}


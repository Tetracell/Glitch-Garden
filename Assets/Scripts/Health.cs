using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health = 100.0f; // just in case it wasn't set

    public void dealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            //Optionally trigger an animation
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}

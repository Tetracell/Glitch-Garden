using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health;

	// Use this for initialization
	void Start ()
    {	
	}

    public void dealDamage(float damage)
    {
        health -= damage;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (health <= 0)
        {
            Destroy(gameObject);
        }
	}


    

}

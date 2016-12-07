using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
    [Range (-1f, 1.5f)] // Literally the best thing in Unity so far.
    public float currentSpeed;
    public float lizardDamage;
    public float foxDamage;

    private GameObject currentTarget;

	// Use this for initialization
	void Start ()
    {
        Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody.isKinematic = true;
	}
    
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}

    void OnTriggerEnter2D()
    {
        //Debug.Log("Generic Collision with " + name);
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    //called From the animator at the time of the actual blow
    public void StrikeCurrentTarget() // Don't need references in any code for this, should only be called by animator.
    {
        SetSpeed(0.0f);
        //Debug.Log("I am attacking for : " + damage);
        //print("My current target is: " + currentTarget);           
    }

    public void Attack (GameObject obj, float damage)
    {
        currentTarget = obj;
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.dealDamage(damage);
            }
        }
    }

    //public void lizardAttack (GameObject obj)
    //{
    //    lizardDamage = 20.0f;
    //    currentTarget = obj;
    //    currentSpeed = 0f;
    //    SetSpeed(currentSpeed);
    //    StrikeCurrentTarget(lizardDamage);     
    //}

    //public void foxAttack(GameObject obj)
    //{
    //    foxDamage = 15.0f;
    //    currentTarget = obj;
    //    currentSpeed = 0f;
    //    StrikeCurrentTarget(foxDamage);
    //    //StrikeCurrentTarget(15.0f);        
    //}
}
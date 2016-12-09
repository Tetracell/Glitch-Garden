using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
    [Range (-1f, 1.5f)] // Literally the best thing in Unity so far.
    public float currentSpeed;
    private GameObject currentTarget;

    Animator animator;

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
    public void StrikeCurrentTarget(float damage) // Don't need references in any code for this, should only be called by animator.
    {
        Debug.Log("I am attacking for : " + damage);
        if (currentTarget) // is there a target
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health) // does it have a health component
            {
                health.dealDamage(damage); // deal dat damage
            }
        }
        
    }

    //public void lizardAttack(GameObject obj)
    //{
    //    currentTarget = obj;
    //    currentSpeed = 0f;

    //}

    //public void foxAttack(GameObject obj)
    //{
    //    currentTarget = obj;
    //    currentSpeed = 0f;
    //}
}
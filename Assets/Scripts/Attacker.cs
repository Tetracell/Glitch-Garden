using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
    [Range (-1f, 1.5f)] // Literally the best thing in Unity so far.
    public float currentSpeed;

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
        Debug.Log("SHITFARTS");
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        Debug.Log("I am attacking");
    }
}
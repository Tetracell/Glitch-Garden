using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker) )]
public class Fox : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;

    public float damage = 15.0f;
     

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
        // float health = Health.setHealth(5.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D (Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        //Leave the method if not colliding with a defender
        if (!obj.GetComponent<Defender>())
        {
            return;
        }
        Debug.Log("Fox collided with " + collider);
        if (obj.GetComponent<Stone>())
        {
            anim.SetTrigger("jump trigger");
        } else
        {
            anim.SetBool("isAttacking", true);
            //attacker.foxAttack(obj);
        }
    }
}

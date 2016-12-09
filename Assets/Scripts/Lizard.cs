using UnityEngine;
using System.Collections;

public class Lizard : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;

    public float health;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
        health = 10.0f;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        //Leave the method if not colliding with a defender
        if (!obj.GetComponent<Defender>())
        {
            return;
        }        
        else
        {
            anim.SetBool("isAttacking", true);
            //attacker.lizardAttack(obj);
        }

    }
}

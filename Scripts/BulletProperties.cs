using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public float speed = 20f;
    public int damage = 2;

    void Start()
    {
    	rb.velocity = transform.right * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
    	
    	EnemyProperties enemy = hitInfo.GetComponent<EnemyProperties>();
    	if (enemy != null){
    		enemy.takeDamage(damage);
    	}


    	Destroy(gameObject);

    }
}

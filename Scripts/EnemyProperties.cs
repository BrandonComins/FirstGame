using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour {
   
    public int health = 3;
      
	private Rigidbody2D rb;

    public void update(){
    
	
	}

	void Awake(){
		rb = transform.GetComponent<Rigidbody2D>();
		
	}

   	public void takeDamage(int damage){
   		health -= damage;
   		
   		if(health <= 0){
   			die();
   		}
   	}

      private void die(){
   		Destroy(gameObject);
   	}  
}
      
    
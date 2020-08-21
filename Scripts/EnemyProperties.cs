using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour {
   
	public Transform enemy;
    public GameObject heartPrefab;
	public float healthDropChance;
	
    public int health = 40;

	private Rigidbody2D rb;


	void Awake(){
		healthDropChance = Random.Range(0f, 1f);
		rb = transform.GetComponent<Rigidbody2D>();

	}

    public void update(){
    
	
	}

   	public void takeDamage(int damage){
   		health -= damage;
   		
   		if(health <= 0){
   			die();
   		}
   	}

      private void die(){
   		Destroy(gameObject);
		dropHealth();
		
   	}  

	private void dropHealth(){
		if(healthDropChance <= .1f){
			GameObject heart = Instantiate(heartPrefab, enemy.position, enemy.rotation);
		}
	}

}
      
    
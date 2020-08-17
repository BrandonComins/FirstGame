using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour {
   
   	public int health = 3;

   	public void takeDamage(int damage){
   		health -= damage;
   		
   		if(health <= 0){
   			die();
   		}
   	}

   	void die(){
   		Destroy(gameObject);
   	}
}
    
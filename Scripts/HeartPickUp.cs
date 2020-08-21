using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUp : MonoBehaviour {

private int healthGiven = -20;

PlayerController player;

void Awake(){
    player = FindObjectOfType<PlayerController>();
}
private void OnTriggerEnter2D(Collider2D hitInfo) {

       if(hitInfo.gameObject.tag == "Player"){
            player.takeDamage(healthGiven);
            Destroy(this.gameObject);

       }
   }
}

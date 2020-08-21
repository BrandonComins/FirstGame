using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickup : MonoBehaviour{

PlayerController player;

private bool pickUpAllowed;

public SpriteRenderer playerGun;
public Sprite shotgun;

void Update(){
    if(pickUpAllowed && Input.GetKeyDown("e")){
        PickUp();
    }
}

void Awake(){
    player = FindObjectOfType<PlayerController>();
    
    
}
private void OnTriggerEnter2D(Collider2D hitInfo) {

       if(hitInfo.gameObject.tag == "Player"){
            pickUpAllowed = true;
       }
   }


private void OnTriggerExit2D(Collider2D hitInfo){
    if(hitInfo.gameObject.tag == "Player"){
            pickUpAllowed = false;
       }
}

private void PickUp(){
    PlayerShoot.gunEquiped = PlayerShoot.gun.shotgun;
    playerGun.sprite = shotgun;
    Destroy(gameObject);
    }
}

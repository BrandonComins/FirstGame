using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmPivot : MonoBehaviour {
  
  	public GameObject player;

    void Awake(){
    	 player = GameObject.FindGameObjectWithTag ("Player");
        
    }

    // Update is called once per frame
    void Update(){
    	
    	}
        

    private void FixedUpdate(){
    	// Vector2 difference = transform.position(player.position.x, player.position.y);
    	
    	// float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

    	// transform.rotation = Quaternion.Euler(0f,0f,rotationZ);

    	// Prevent arm from being upsidedown when player changes direction
  //   	if(rotationZ < -90 || rotationZ > 90){

		// 	if(myPlayer.transform.eulerAngles.y == 0){
		// 		transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);

		// 		}

		// 	else if(myPlayer.transform.eulerAngles.y == 180){
		// 		transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
		// 	}
		// }
    }
}
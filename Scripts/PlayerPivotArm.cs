using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPivotArm : MonoBehaviour
{
    
    public GameObject myPlayer;

    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void FixedUpdate(){
    	Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    	
    	float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

    	transform.rotation = Quaternion.Euler(0f,0f,rotationZ);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPivotArm : MonoBehaviour
{
  
    public float speed;
    public Transform player;

    void FixedUpdate(){
        
        if (player){
        Vector2 difference = player.position - transform.position;
    	
    	float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

    	transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}

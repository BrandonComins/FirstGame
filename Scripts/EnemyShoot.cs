using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
    public Transform firePoint;
    public GameObject bulletPrefab;

    float timeRemaining;

    float maxTime = 1.5f;

    void Start(){
        timeRemaining = maxTime;
    }
    
    void Update(){
        if(timeRemaining <= 0){
    	    Shoot();
            timeRemaining = maxTime;
        }
        timeRemaining -= Time.deltaTime;
    }
        

    void Shoot(){
    	GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    	
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

public Transform firePoint;
public GameObject bulletPrefab;

public float nextTimeToFire= 0f;

public static gun gunEquiped;

public enum gun{
    pistol, revolver, assaultRifle, shotgun, rocketLauncher
}



    
     void Start(){
        gunEquiped = gun.pistol;
 
     }
        

    void Update(){
        if(gunEquiped == gun.pistol){
    	    if(Input.GetButtonDown("Fire1") &&  nextTimeToFire <= Time.time){
                nextTimeToFire = Time.time + .2f;
                shoot();
        	}
        }

        else if(gunEquiped == gun.assaultRifle){
            if(Input.GetButton("Fire1") &&  nextTimeToFire <= Time.time){
                nextTimeToFire = Time.time + .15f;
                shoot();
            }
        }
        
        else if(gunEquiped == gun.shotgun){
            if(Input.GetButtonDown("Fire1") &&  nextTimeToFire <= Time.time){
                nextTimeToFire = Time.time + .65f;
                shoot();
            }
        } 

        else if(gunEquiped == gun.revolver){
            if(Input.GetButtonDown("Fire1") &&  nextTimeToFire <= Time.time){ 
                nextTimeToFire = Time.time + .3f;
                shoot();
            }
        }           
    }

    public void shoot(){
    	if(gunEquiped == gun.pistol){
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

        else if (gunEquiped == gun.revolver){
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

        else if (gunEquiped == gun.assaultRifle){
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            
        }
    

        else if (gunEquiped == gun.shotgun){
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            GameObject bullet1 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            
            bullet.transform.Rotate(0, 0, Random.Range(-10,10));
            bullet1.transform.Rotate(0, 0, Random.Range(-10,10));
            bullet2.transform.Rotate(0, 0, Random.Range(-10,10));
            bullet3.transform.Rotate(0, 0, Random.Range(-10,10));

            //TODO maybe make actual spray instead of random spray or make a better shotgun with more predictable spray pattern
        }

        else if(gunEquiped == gun.rocketLauncher){
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}

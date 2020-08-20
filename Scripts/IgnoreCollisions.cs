using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisions : MonoBehaviour {

    public GameObject heart;
    public GameObject bullet;

    public GameObject enemy;

    void Start() {
        
    }


    void Update() {
        Physics2D.IgnoreCollision(heart.GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());  
        
    }
}

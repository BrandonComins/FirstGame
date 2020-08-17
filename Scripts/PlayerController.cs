using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
   	
   	public float moveSpeed;
	public float jumpSpeed;
	public float midAirControl;

	public float fallMultiplyer = 2.5f;
	public float lowJumpMultiplyer = 2f;

	private Rigidbody2D rb;
	private BoxCollider2D col;

	[SerializeField] public LayerMask groundLayer;
	// public LayerMask wallLayer;

    void Awake() {
    	rb = transform.GetComponent<Rigidbody2D>();
    	col = transform.GetComponent<BoxCollider2D>();
      
    }

    void Update(){
    	if(Input.GetKey("space") && isGrounded()) {

 			rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

 			// Hold to jump Higher (gravity is no longer constant)

 			if (rb.velocity.y < 0){
 				rb.velocity+= Vector2.up*Physics2D.gravity.y * (fallMultiplyer - 1) * Time.deltaTime;

				}
 		
 			else if (rb.velocity.y > 0 && !Input.GetButton ("Jump")){

 					rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplyer - 1) * Time.deltaTime;

 				}
    		}
    	}


 	void FixedUpdate(){
 			
 			handleMovement();

 		}

 	//Collect Coins
 	private void OnTriggerEnter2D(Collider2D col){
		int coins_collected = 0;
		if(col.gameObject.CompareTag("coin")){
			Destroy(col.gameObject);
			coins_collected++;
		}

	}

	bool isGrounded(){
		RaycastHit2D raycast = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, groundLayer);
	 	Debug.Log(raycast.collider);
	 	return raycast.collider != null;
	}

	private void handleMovement(){
		if (Input.GetKey("d")) {
			if(isGrounded()){
 				rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
 			}else{
 				rb.velocity += new Vector2(moveSpeed * Time.deltaTime, 0);
 				rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -moveSpeed, moveSpeed), rb.velocity.y);
 		}
 	}

 		else if (Input.GetKey("a")){
 				if(isGrounded()){
 					rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
 				}else{
 					rb.velocity += new Vector2(-moveSpeed * Time.deltaTime, 0);
 					rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -moveSpeed, moveSpeed), rb.velocity.y);
 				}
 			
 		}else{
 			//no keys pressed
 			if(isGrounded()){
 				rb.velocity = new Vector2(0, rb.velocity.y);
 			}

		} 
	}
}
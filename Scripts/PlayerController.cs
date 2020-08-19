using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
   	
   	public float moveSpeed;
	public float jumpSpeed;
	public float midAirControl;

	public float fallMultiplyer = 2.5f;
	public float lowJumpMultiplyer = 2f;

	private bool canDoubleJump;

	private Rigidbody2D rb;
	private BoxCollider2D col;
	private GameObject player;


	public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;

	public float dashSpeed;
	private float dashTime;
	public float startDashTime;
	private bool isDashing = false;
	private int lastDirection = 0;



	[SerializeField] public LayerMask groundLayer;
	

	void Start(){
		
		// Starts character with max health
		currentHealth = maxHealth;
		healthBar.setMaxHealth(maxHealth);

		dashTime = startDashTime;
	}

    void Awake() {
    	rb = transform.GetComponent<Rigidbody2D>();
    	col = transform.GetComponent<BoxCollider2D>();
      
    }

    void Update(){
    		jump();
    		die();
    		dash();
    		handleMovement();

    	}

 	void FixedUpdate(){
 			
 			
 			

 			//Hold to jump Higher (gravity is no longer constant)
 			if (rb.velocity.y < 0){
 				rb.velocity+= Vector2.up*Physics2D.gravity.y * (fallMultiplyer - 1) * Time.deltaTime;

				}
 		
 			else if (rb.velocity.y > 0 && !Input.GetButton ("Jump")){

 					rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplyer - 1) * Time.deltaTime;

 		}
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
	 	return raycast.collider != null;
	}

	private void handleMovement(){
		if (Input.GetKey("d")) {
			//move right (positive direction)
			if(isGrounded()){
 				rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
 			}else{
 				//move right at reduced speed if in air
 				rb.velocity += new Vector2(moveSpeed * Time.deltaTime, 0);
 				rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -moveSpeed, moveSpeed), rb.velocity.y);
 		}
 			lastDirection = 1;
 	}

 		else if (Input.GetKey("a")){
 				//move left (negative direction)
 				if(isGrounded()){
 					rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
 				}else{
 					//move left at reduced speed if in air
 					rb.velocity += new Vector2(-moveSpeed * Time.deltaTime, 0);
 					rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -moveSpeed, moveSpeed), rb.velocity.y);
 				}
 				lastDirection = -1;
 		}else{
 			//no keys pressed
 			if(isGrounded()){
 				rb.velocity = new Vector2(0, rb.velocity.y);
 			}

		} 
	}

	private void jump(){
		if(isGrounded()){
    		canDoubleJump = true;
    	}

    	//Key may be held to jump as soon as they hit the ground
    	if(Input.GetKey("space")) {
    		if(isGrounded()){
 				rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
 				
 				}else{
 					//Key must be pressed twice to jump in air.
 					if(Input.GetKeyDown(KeyCode.Space)){
 						if(canDoubleJump){
 							rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
 							canDoubleJump = false;
 						}
 					}
    			}
    		}

    		//Debugging health
    		if(Input.GetKeyDown("p")){
    			takeDamage(50);
    		}
		}

		void takeDamage(int damage){
			currentHealth -= damage;
			healthBar.setHealth(currentHealth);
		}

		private void die(){
			if (currentHealth <= 0){
				Destroy(gameObject);
			}
		}

		private void dash(){
			// Debug.Log("Are you Dashing? " + isDashing);
			Debug.Log("What is your Dash Time? " + dashTime);
			// Debug.Log("What was your Last Direction? " + lastDirection);
			// Debug.Log("The Start Dash Time: " + startDashTime);
				if(dashTime <= 0){
					dashTime = startDashTime;
					isDashing = false;
					Debug.Log("RESET TIME!");
				}

				if(Input.GetKeyDown("left shift")){
					Debug.Log("DASH!");

					// if(isDashing == false){
						if(dashTime > 0){
							if(lastDirection == 1 || lastDirection == 0){
								rb.velocity = Vector2.right * dashSpeed;
								// isDashing = true;
								dashTime -= Time.deltaTime;
								Debug.Log("Dashing right");
							}
							else if(lastDirection == -1){
								rb.velocity = Vector2.left * dashSpeed;
								// isDashing = true;
								dashTime -= Time.deltaTime;
								Debug.Log("Dashing Left");
							}		
						}
					// }
				}	
			}
		}
	

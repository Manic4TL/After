using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Transform top_left;
	public Transform bottom_right;
	public Transform top_left1;
	public Transform bottom_right1;
	public LayerMask ground_layers;
	PlayerSpriteAnim playerSpriter;
	PlayerStats stats;
	private bool facingRight = true;
	public bool canforward = true;

	Rigidbody2D body;
	float walkSpeed = 2.5f;
	public bool grounded = false;
	public bool sprinting = false;
	public float jumpSpeed = 4f;

	void Start () {
		body = gameObject.GetComponent<Rigidbody2D>();
		//spriter = gameObject.GetComponent<SpriteAnimator>();
		playerSpriter = gameObject.GetComponent<PlayerSpriteAnim>();
		stats = gameObject.GetComponent<PlayerStats>();
		Transform[] ts = gameObject.transform.GetComponentsInChildren<Transform>(true);
		foreach (Transform t in ts) {
			if (t.gameObject.name == "_TL") {
				top_left = t;
			}else if(t.gameObject.name == "_BR"){
				bottom_right=t;
			}else if(t.gameObject.name == "_TL 1"){
				top_left1=t;
			}else if(t.gameObject.name == "_BR 1"){
				bottom_right1=t;
			}
		}
	}
	
	public void Update(){
		Camera.main.gameObject.transform.position=new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,-10);

		grounded = Physics2D.OverlapArea(top_left.position, bottom_right.position, ground_layers);    
		canforward  = !Physics2D.OverlapArea(top_left1.position, bottom_right1.position, ground_layers);  


		if (grounded) {
			body.drag = 5;
			body.angularDrag = 5;

			if (Input.GetKey (KeyCode.LeftShift) && stats.stamina > 0) {
				sprinting = true;
			} else {
				sprinting = false;
			}

			if (Input.GetKeyDown(KeyCode.Space)) {
				body.velocity = new Vector2 (0, jumpSpeed) + body.velocity;

				playerSpriter.AnimationNo=2;
			} else if (Input.GetKey (KeyCode.D)) {
				FaceLeft (true);
				if(canforward){
				if (sprinting) {
					body.velocity = new Vector2 (walkSpeed * 2, 0);
					//spriter.AnimState = 2;
				} else {
					body.velocity = new Vector2 (walkSpeed, 0);
					
					playerSpriter.AnimationNo=1;
				}
				}else{
					playerSpriter.AnimationNo=0;
				}
			} else if (Input.GetKey (KeyCode.A)) {
				FaceLeft (false);
				if(canforward){
				if (sprinting) {
					body.velocity = new Vector2 (-walkSpeed * 2, 0);
					//spriter.AnimState = 2;
				} else {
					body.velocity = new Vector2 (-walkSpeed, 0);
					
					playerSpriter.AnimationNo=1;
					}
				}else{
					playerSpriter.AnimationNo=0;
				}
			} else {

				playerSpriter.AnimationNo=0;
			}
		} else {
			if(body.velocity.x ==0){
			if (Input.GetKey (KeyCode.D)) {

				FaceLeft (true);
					if(canforward){
				body.velocity = new Vector2 (walkSpeed/2, body.velocity.y);
					}

			} else if (Input.GetKey (KeyCode.A)) {
				FaceLeft (false);
					if(canforward){
				body.velocity =new Vector2 (-walkSpeed/2, body.velocity.y);
					}
				}

			}


			body.drag=0;
			body.angularDrag=0;
			playerSpriter.AnimationNo=2;
		}


	}

	public void FaceLeft(bool b){


		if (facingRight != b) {
		
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
			facingRight = b;
		}
	}
}

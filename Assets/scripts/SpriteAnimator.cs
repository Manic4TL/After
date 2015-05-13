using UnityEngine;
using System.Collections;

public class SpriteAnimator : MonoBehaviour {
	
	PlayerStats stats;

	public int AnimState = 0; //idle, walk, run, jump, crouch 
	float animTimer = 0.0f;
	public int spriteNo = 0;

	public Sprite[] bodySprites; // character body
	public Sprite[] equip1Sprites;	// layer 0 feet
	public Sprite[] equip2Sprites; // layer 0 legs
	public Sprite[] equip3Sprites; // layer 0 body
	public Sprite[] equip4Sprites; // layer 0 head
	public Sprite[] equip5Sprites; // layer 1 feet
	public Sprite[] equip6Sprites; // layer 1 legs
	public Sprite[] equip7Sprites; // layer 1 body
	//public Sprite[] item1Sprites; // equiped item

	SpriteRenderer currentBody;
	SpriteRenderer currentEquip1;
	SpriteRenderer currentEquip2;
	SpriteRenderer currentEquip3;
	SpriteRenderer currentEquip4;
	SpriteRenderer currentEquip5;
	SpriteRenderer currentEquip6;
	SpriteRenderer currentEquip7;

	Sprite thisSprite;
	


	void Start () {
		stats = gameObject.GetComponent<PlayerStats> ();


		bodySprites = Resources.LoadAll<Sprite> ("sprites/base_f");
	    equip1Sprites = stats.equipRow1 [3].sprite;
		equip2Sprites = stats.equipRow1 [2].sprite;
		equip3Sprites = stats.equipRow1 [1].sprite;
		equip4Sprites = stats.equipRow1 [0].sprite;
		equip5Sprites = stats.equipRow2 [3].sprite;
		equip6Sprites = stats.equipRow2 [2].sprite;
		equip7Sprites = stats.equipRow2 [1].sprite;




		GameObject body = new GameObject ();
		body.transform.SetParent (gameObject.transform);
		body.name = "body";
		currentBody = body.AddComponent<SpriteRenderer>();
		currentBody.sortingOrder = 1;
		body.transform.localPosition=Vector2.zero;

		GameObject equip1 = new GameObject ();
		equip1.transform.SetParent (gameObject.transform);
		equip1.name = "equip1";
		currentEquip1 = equip1.AddComponent<SpriteRenderer>();
		currentEquip1.sortingOrder = 2;
		equip1.transform.localPosition=Vector2.zero;

		GameObject equip2 = new GameObject ();
		equip2.transform.SetParent (gameObject.transform);
		equip2.name = "equip2";
		currentEquip2 = equip2.AddComponent<SpriteRenderer>();
		currentEquip2.sortingOrder = 3;
		equip2.transform.localPosition=Vector2.zero;

		GameObject equip3 = new GameObject ();
		equip3.transform.SetParent (gameObject.transform);
		equip3.name = "equip3";
		currentEquip3 = equip3.AddComponent<SpriteRenderer>();
		currentEquip3.sortingOrder = 4;
		equip3.transform.localPosition=Vector2.zero;

		GameObject equip4 = new GameObject ();
		equip4.transform.SetParent (gameObject.transform);
		equip4.name = "equip4";
		currentEquip4 = equip4.AddComponent<SpriteRenderer>();
		currentEquip4.sortingOrder = 5;
		equip4.transform.localPosition=Vector2.zero;
		
		GameObject equip5 = new GameObject ();
		equip5.transform.SetParent (gameObject.transform);
		equip5.name = "equip5";
		currentEquip5 = equip5.AddComponent<SpriteRenderer>();
		currentEquip5.sortingOrder = 6;
		equip5.transform.localPosition=Vector2.zero;
		
		GameObject equip6 = new GameObject ();
		equip6.transform.SetParent (gameObject.transform);
		equip6.name = "equip6";
		currentEquip6 = equip6.AddComponent<SpriteRenderer>();
		currentEquip6.sortingOrder = 7;
		equip6.transform.localPosition=Vector2.zero;

		GameObject equip7 = new GameObject ();
		equip7.transform.SetParent (gameObject.transform);
		equip7.name = "equip7";
		currentEquip7 = equip7.AddComponent<SpriteRenderer>();
		currentEquip7.sortingOrder = 7;
		equip7.transform.localPosition=Vector2.zero;


	}
	

	void Update () {

		equip1Sprites = stats.equipRow1[3].sprite;
		equip2Sprites = stats.equipRow1[2].sprite;
		equip3Sprites = stats.equipRow1[1].sprite;
		equip4Sprites = stats.equipRow1[0].sprite;
		equip5Sprites = stats.equipRow2[3].sprite;
		equip6Sprites = stats.equipRow2[2].sprite;
		equip7Sprites = stats.equipRow2[1].sprite;


		if (currentBody != null) {
			if (currentBody.sprite != null) {
				spriteNo = int.Parse (currentBody.sprite.name.Split ('_') [2]);
			}
		}
		animTimer += Time.deltaTime;
		if (AnimState == 0) {//idle
			currentBody.sprite = bodySprites[0];
			currentEquip1.sprite = equip1Sprites[0];
			currentEquip2.sprite = equip2Sprites[0];
			currentEquip3.sprite = equip3Sprites[0];
			currentEquip4.sprite = equip4Sprites[0];
			currentEquip5.sprite = equip5Sprites[0];
			currentEquip6.sprite = equip6Sprites[0];
			currentEquip7.sprite = equip7Sprites[0];
			animTimer=0;
		}

		if (AnimState == 1) {//walk
			if(animTimer >= 0.08){
				if(spriteNo <15 && spriteNo >-1){
					currentBody.sprite = bodySprites[spriteNo+1];
					currentEquip1.sprite = equip1Sprites[spriteNo+1];
					currentEquip2.sprite = equip2Sprites[spriteNo+1];
					currentEquip3.sprite = equip3Sprites[spriteNo+1];
					currentEquip4.sprite = equip4Sprites[spriteNo+1];
					currentEquip5.sprite = equip5Sprites[spriteNo+1];
					currentEquip6.sprite = equip6Sprites[spriteNo+1];
					currentEquip7.sprite = equip7Sprites[spriteNo+1];
				}else{
					currentBody.sprite = bodySprites[0];
					currentEquip1.sprite = equip1Sprites[0];
					currentEquip2.sprite = equip2Sprites[0];
					currentEquip3.sprite = equip3Sprites[0];
					currentEquip4.sprite = equip4Sprites[0];
					currentEquip5.sprite = equip5Sprites[0];
					currentEquip6.sprite = equip6Sprites[0];
					currentEquip7.sprite = equip7Sprites[0];
				}
				animTimer=0;
			}
		}

		if (AnimState == 2) {//run
			if(animTimer >= 0.08){
				if(spriteNo <31 && spriteNo >15){
					currentBody.sprite = bodySprites[spriteNo+1];
					currentEquip1.sprite = equip1Sprites[spriteNo+1];
					currentEquip2.sprite = equip2Sprites[spriteNo+1];
					currentEquip3.sprite = equip3Sprites[spriteNo+1];
					currentEquip4.sprite = equip4Sprites[spriteNo+1];
					currentEquip5.sprite = equip5Sprites[spriteNo+1];
					currentEquip6.sprite = equip6Sprites[spriteNo+1];
					currentEquip7.sprite = equip7Sprites[spriteNo+1];
				}else{
					currentBody.sprite = bodySprites[16];
					currentEquip1.sprite = equip1Sprites[16];
					currentEquip2.sprite = equip2Sprites[16];
					currentEquip3.sprite = equip3Sprites[16];
					currentEquip4.sprite = equip4Sprites[16];
					currentEquip5.sprite = equip5Sprites[16];
					currentEquip6.sprite = equip6Sprites[16];
					currentEquip7.sprite = equip7Sprites[16];
				}
				animTimer=0;
			}
		}
		if (AnimState == 3) {//jump
			currentBody.sprite = bodySprites[21];
			currentEquip1.sprite = equip1Sprites[21];
			currentEquip2.sprite = equip2Sprites[21];
			currentEquip3.sprite = equip3Sprites[21];
			currentEquip4.sprite = equip4Sprites[21];
			currentEquip5.sprite = equip5Sprites[21];
			currentEquip6.sprite = equip6Sprites[21];
			currentEquip7.sprite = equip7Sprites[21];
			animTimer=0;
		}
	}
}

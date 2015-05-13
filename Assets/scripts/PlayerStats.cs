using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	PlayerController PL;

	public int health = 200;
	public int maxHealth = 200;
	public float stamina = 100f;
	public static float extTemp = 0.0f;
	public static float intTemp = 0.0f;
	public int bleedSpeed = 0; 
	public static float warming = 5f;
	public bool isDead = false;
	
	public static float bodyWet = 0f;
	public static bool inwater =false;
	public static bool inrain = false;
	public bool noClothes = true;
	public static float freezeTimer = 0f;
	public static float mostWetClothes = 0.0f;
	private float stamTimer =3.0f;
	public static Item selectedItem;
	public Texture toolTipBack;
	public bool displayInv = false;

	public Item[] equipRow1 = new Item[4];
	public Item[] equipRow2 = new Item[4];


	public Item[] backpack = new Item[20];

	public static Item temphold;
	private bool showDebug = false;

	private float effectTimer =0.0f;



	void Start () {
		extTemp = -2.0f;


		PL = gameObject.GetComponent<PlayerController> ();

		equipRow1 [3] = ItemList.allitems [1].Clone () as Item;
		equipRow1 [2] = ItemList.allitems [2].Clone () as Item;
		equipRow1 [1] = ItemList.allitems [3].Clone () as Item;
		equipRow2 [1] = ItemList.allitems [4].Clone () as Item;
		backpack [6] = ItemList.allitems [4].Clone () as Item;


		GameObject body = new GameObject ();
		body.transform.SetParent (gameObject.transform);
		body.name = "body";
		SpriteRenderer bodyrender = body.AddComponent<SpriteRenderer> ();
		Spritable bodysprite = body.AddComponent<Spritable>();
		bodysprite.baseSprites = Resources.LoadAll<Sprite>("sprites/"+ PlayerCustomisation.genderLetter+"/body");
		bodyrender.sortingOrder = 0;
		bodyrender.sortingLayerName = "PlayerLayer1";
		body.transform.localPosition = Vector2.zero;

		for (int i = 0; i < backpack.Length-1; i++) {
			
			if (backpack [i + 1] == null) {
				backpack [i + 1] = ItemList.allitems [0];
			
			}
		}
		for (int i = 0; i < equipRow1.Length; i++) {
			
			if (equipRow1 [i] == null) {
				equipRow1 [i] = ItemList.allitems [0];
				
			}

			GameObject thisone = new GameObject ();
			thisone.transform.SetParent (gameObject.transform);
			thisone.name = "equipRow1_"+i;
			SpriteRenderer thisrender = thisone.AddComponent<SpriteRenderer> ();
			Spritable thissprite = thisone.AddComponent<Spritable>();
			thissprite.baseSprites = equipRow1[i].sprite;
			thisrender.sortingOrder = 6-i;
			thisrender.sortingLayerName = "PlayerLayer1";
			thisone.transform.localPosition = Vector2.zero;

		}

		for (int i = 0; i < equipRow2.Length; i++) {
			
			if (equipRow2 [i] == null) {
				equipRow2 [i] = ItemList.allitems [0];
				
			}

			GameObject thisone = new GameObject ();
			thisone.transform.SetParent (gameObject.transform);
			thisone.name = "equipRow2_"+i;
			SpriteRenderer thisrender = thisone.AddComponent<SpriteRenderer> ();
			Spritable thissprite = thisone.AddComponent<Spritable>();
			thissprite.baseSprites = equipRow2[i].sprite;
			thisrender.sortingOrder = 6-i;
			thisrender.sortingLayerName = "PlayerLayer2";
			thisone.transform.localPosition = Vector2.zero;
		}

	}
	

	void Update () {


		extTemp = Mathf.Clamp (extTemp, -20f, 20f);


		if (Input.GetKeyDown (KeyCode.Tab)) {
			displayInv=!displayInv;
		}
		if (Input.GetKeyDown (KeyCode.BackQuote)) {
			showDebug=!showDebug;

		}




		warming = 0;
		mostWetClothes = 0;




		if (PL.sprinting == true) {
			stamina -= Time.deltaTime * 10;
			warming += 4;
			stamTimer=0;
		} else {
			if(stamTimer>=3.0f){
				if(stamina + Time.deltaTime*20 <=100){
				stamina+=Time.deltaTime*20;
				}else{
					stamina=100;
				}

			}else{
				if(stamTimer + Time.deltaTime <=3.0f ){
					stamTimer+=Time.deltaTime;
				}else{
					stamTimer=3.0f;
				}
			}


		
		}






		if (effectTimer >= 1.0f) {
			health = health - bleedSpeed;

			if(intTemp <= -2){
				freezeTimer += -intTemp;
			}else if(intTemp >= 1 ){
				if(freezeTimer >= 0+ intTemp){
				freezeTimer += -intTemp;
				}else{
					freezeTimer=0;
				}
			}
			if(freezeTimer >= 200){
				Debug.Log ("Ohdear"+health);
				health -= 4;
			}


			if(health <=0){
				Die();
			}

			Inventory.wetItems(equipRow1,true);
			Inventory.wetItems(equipRow2,true);
			Inventory.wetItems(backpack,false);

			Inventory.checkEffects(equipRow1);
			Inventory.checkEffects(equipRow2);
			if(Inventory.itemCheck(equipRow1)){
				noClothes=false;
			}else if(Inventory.itemCheck(equipRow2)){
				noClothes=false;
			}else{
				noClothes = true;
			}

			if(inwater){
				if(bodyWet<= 100-10){
					bodyWet+=10;
				}else{
					bodyWet=100;
				}

			}else if(inrain){
				if(bodyWet<= 100-3){
					bodyWet+=3;
				}else{
					bodyWet=100;
				}
			}else{
				if(extTemp >1){
					if(bodyWet-(extTemp/5) >=0)
				bodyWet -= extTemp/5;
				}else{
					bodyWet=0;
				}
			}

			if(mostWetClothes==100){
				bodyWet=100;
			}

			if(!noClothes){
			warming -= bodyWet/10;
			}else{
				warming -= bodyWet/40;

			}
			intTemp = extTemp + warming;

			effectTimer = 0.0f;
		} else {
			effectTimer+=Time.deltaTime;
		}


		foreach (Transform child in transform) {
	
			if(child.GetComponent<Spritable>()!=null&&child.name!="body"){
				if(child.name.Split('_')[0]=="equipRow1"){
					child.GetComponent<Spritable>().baseSprites = equipRow1[(int.Parse(child.name.Substring(10)))].sprite;
				}
			}
			if(child.name.Split('_')[0]=="equipRow2") {
				child.GetComponent<Spritable>().baseSprites = equipRow2[(int.Parse(child.name.Substring(10)))].sprite;
			}

		}


	
	
	}

	public void takeDamage (int amount) {
		health -= amount;
	}

	public void takeDamage (int amount, bool bleedable , int percBleed , int bleedAmount) {
		health -= amount;
		if (percBleed >= Random.Range (0, 100)) {
			bleedSpeed +=bleedAmount;
		}
	}

	public void stopBleeding(int amount){
		if (bleedSpeed > amount) {
			bleedSpeed -= amount;
		} else {
			bleedSpeed=0;
		}

	}


	void OnGUI(){

		if (showDebug) {
			GUILayout.BeginArea(new Rect(Screen.width-210,10,200,300));
			GUILayout.Box("Debug Menu");
			GUILayout.Label(health+"/"+maxHealth+" Health");
			GUILayout.Label(stamina+"% Stamina");
			GUILayout.Label(intTemp+"/"+extTemp+" Temperature");
			GUILayout.Label(bodyWet+" wetness");
			if(selectedItem !=null){
				GUILayout.Label(selectedItem.name);
			}else{
				GUILayout.Label("No selected Item");
			}

			if(GUILayout.Button ("LetsBleed (1)")){takeDamage(0,true,100,1);}
			if(bleedSpeed !=0.0f){
			if(GUILayout.Button ("stopBleed (3)")){stopBleeding(3);}

				GUI.color= Color.red;
				GUILayout.Label(bleedSpeed+" Blood per second");
				GUI.color= Color.white;

			}
			if(GUILayout.Button ("Make it rain")){inrain=!inrain;}
			GUILayout.EndArea();
		}

		
		GUIStyle style = new GUIStyle ();
		style.richText = true;
		style.wordWrap = true;

	

		if (displayInv) {

			Inventory.DisplayGUI(equipRow1,new Rect(0,0,50,50),1,true);
			Inventory.DisplayGUI(equipRow2,new Rect(50,0,50,50),1,true);
			Inventory.DisplayGUI(backpack,new Rect(120,0,50,50),5,false);

			if(GUI.tooltip!=null && GUI.tooltip != "" ){
				GUI.DrawTexture(new Rect(Input.mousePosition.x +20, Screen.height-Input.mousePosition.y,150,150), toolTipBack);
				GUI.Box(new Rect(Input.mousePosition.x +20, Screen.height-Input.mousePosition.y,150,150),GUI.tooltip, style);
			}
		}

		if (selectedItem != null) {
			GUI.DrawTexture(new Rect(Input.mousePosition.x -10, Screen.height-Input.mousePosition.y-10,20,20),selectedItem.icon);
		} 
	}

	void Die(){
		isDead = true;
		MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
		foreach(MonoBehaviour script in scripts)
		{
			script.enabled = false;
		}
	}



}

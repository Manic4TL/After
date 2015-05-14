using UnityEngine;
using System.Collections;

public class Item {

	public int ID;
	public string name = "Bugged Item";
	public Texture icon;
	public bool canmove = true;
	public Sprite[] sprite;
	public int equipslot;
	public string desc;
	public string[] effects;
	public float wetness;
	public int Quantity = 1;
	public int MaxStack = 1;
	public int itemType = 0;
	public Color tint = new Color(1,1,1,1);
	public bool waterProof = false;

	public Item(){
		
	}

	public Item ( int thisID,string thisName,Texture thisIcon,bool thisCanmove,Sprite[] thisSprite,int thisEquipSlot,string thisDesc,string[] thisEffects,float thisWetness, int thisQuantity, int thisMaxStack, int thisItemType, Color thisTint, bool thisWaterProof){
		ID=thisID;
		name = thisName;
		icon = thisIcon;
		canmove = thisCanmove;
		sprite= thisSprite;
		equipslot = thisEquipSlot;
		desc = thisDesc;
		effects = thisEffects;
		wetness = thisWetness;
		Quantity = thisQuantity;
		MaxStack = thisMaxStack;
		itemType = thisItemType;
		tint = thisTint;
		waterProof = thisWaterProof;
	} 

	public object Clone ()
	{
		Item item = new Item( ID,name,icon,canmove,sprite,equipslot,desc,effects,wetness,Quantity,MaxStack,itemType,tint,waterProof );
		return item;
	}

	public string WetnessName(){
		float amount = wetness;
		string name;

		if (amount <= 5) {
			name = "<color=#B2D1FF>Dry</color>";
		} else if (amount <= 25) {
			name = "<color=#80B2FF>Damp</color>";
		} else if (amount <= 55) {
			name = "<color=#4D94FF>Wet</color>";
		} else if (amount <= 80) {
			name = "<color=#1975FF>Very wet</color>";
		} else if (amount <=98){
			name= "<color=#0066FF>Soaked</color>";
		} else{
			name="<color=#005CE6>Drenched</color>";
		}


		return name;
	}
}

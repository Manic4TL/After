using UnityEngine;
using System.Collections;

public static class ItemList{


	public static Item[] allitems = new Item[]{
		new Item{
			ID= 0,
			name="",
			sprite =  Resources.LoadAll<Sprite>("sprites/empty_f"),
			canmove=false
		},
		new Item{
			ID= 1,
			name="Standard Issue Shoes",
			sprite =  Resources.LoadAll<Sprite>("sprites/"+ PlayerCustomisation.genderLetter+"/shoes"),
			icon = Resources.Load<Texture>("sprites/icons/shoes_icon"),
			equipslot = 3,
			desc= "Light shoes that keep some heat in..",
			effects= new string[]{"T+1"},
			itemType = 1
		},
		new Item{
			ID= 2,
			name="Standard Issue Sweatpants",
			sprite =  Resources.LoadAll<Sprite>("sprites/"+ PlayerCustomisation.genderLetter+"/pants"),
			icon = Resources.Load<Texture>("sprites/icons/pants_icon"),
			equipslot = 2,
			desc= "Comfortable pants that provide a little protection from the cold.",
			effects= new string[]{"T+2"},
			itemType = 1
		},
		new Item{
			ID= 3,
			name="Standard Issue Vest",
			sprite =  Resources.LoadAll<Sprite>("sprites/"+ PlayerCustomisation.genderLetter+"/vest"),
			icon = Resources.Load<Texture>("sprites/icons/vest_icon"),
			equipslot = 1,
			desc= "Loose fitting vest. Provides no real protection from the elements.",
			effects= new string[]{"T+1"},
			itemType = 1
		},
		new Item{
			ID= 4,
			name="Standard Issue T-Shirt",
			sprite =  Resources.LoadAll<Sprite>("sprites/empty_f"),
			icon = Resources.Load<Texture>("sprites/icons/top_icon"),
			equipslot = 1,
			desc= "A light T-shirt. Wont keep you very warm but perfect for summer.",
			effects= new string[]{"T+1"},
			itemType = 1
		}

	};



}
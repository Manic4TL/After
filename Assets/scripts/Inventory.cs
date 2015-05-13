using UnityEngine;
using System.Collections;

public class Inventory{



	public Inventory () {
	
	}


	public static void wetItems(Item[] inv, bool isequip){
		float wetspeed = 0.0f;
		if (PlayerStats.inwater) {
			wetspeed = 20.0f;
		} else if (PlayerStats.inrain) {
			wetspeed = 5.0f;
		} else {
			if(PlayerStats.extTemp > 2){
				wetspeed = -PlayerStats.extTemp/7;
			}else{
				wetspeed = 0;
			}
		}

		for (int i = 0; i < inv.Length; i++) {
			if(inv[i]!=null && inv[i]!=ItemList.allitems[0] ){


				if(wetspeed < 0){
					if(inv[i].wetness + wetspeed >= 0 && wetspeed < 0){
						inv[i].wetness += wetspeed;
					}else{
						inv[i].wetness=0;
					}
				}else if(wetspeed > 0){
					if(inv[i].wetness + wetspeed <= 100f &&wetspeed > 0){
						inv[i].wetness += wetspeed;
					}else{
						inv[i].wetness=100;
					}
				}

				if(isequip){
					if(inv[i].wetness > PlayerStats.mostWetClothes){
						PlayerStats.mostWetClothes = inv[i].wetness;
					}
				}

			}

			
		}
	}

	public static bool itemCheck(Item[] inv){
		bool istrue = false;
		for (int i = 0; i < inv.Length; i++) {
			if(inv[i]!=null && inv[i].ID !=0){

					istrue=true;


			} 
		}
		return istrue;

	}

	public static void DisplayGUI(Item[] inv, Rect pos,int maxWidth, bool isequip){

		GUIContent[] invContent = new GUIContent[inv.Length];
		float x = pos.x;
		float y = pos.y;
		int thisRow = 0;
		int thisCol = 1;
		for (int i = 0; i < inv.Length; i++) {

			if (inv [i] == null) {
				inv [i] = ItemList.allitems [0];
			}


			thisRow++;
			if(thisRow > maxWidth){
				thisRow=1;
				thisCol++;
			}
			x = pos.x+(thisRow*50);
			y = pos.y+(thisCol*50);

			if(inv[i] != null && inv[i].name !=null && inv[i].desc !=null){
				
				invContent[i] = new GUIContent(inv[i].icon,"<b>"+inv[i].name+"</b> \r\n" + inv[i].desc  + "\r\n \r\n" + inv[i].WetnessName());
			}else{
				invContent[i] =GUIContent.none;
			}

			if(isequip){
				if(PlayerStats.selectedItem !=null){
					if(i == PlayerStats.selectedItem.equipslot){
						GUI.enabled=true;
					}else{
						GUI.enabled=false;
					}
				}

			}else{
				GUI.enabled=true;
			}


			if(GUI.Button(new Rect(x,y,50,50),invContent[i])){ 
				if(PlayerStats.selectedItem == null){
					if(inv[i]!=ItemList.allitems[0]){
						PlayerStats.selectedItem = inv[i];
						inv[i] = ItemList.allitems[0];
						
					}
					
				}else {
					PlayerStats.temphold = inv[i];
					
					if(PlayerStats.temphold == ItemList.allitems[0]){
						inv[i] = PlayerStats.selectedItem;
						PlayerStats.selectedItem = null;
						
					}else{
						inv[i] = PlayerStats.selectedItem;
						PlayerStats.selectedItem = PlayerStats.temphold;
					}
					
					
				}
			}
		
		}

	}

	public static void checkEffects(Item[] inv){
		for (int i = 0; i < inv.Length; i++) {
			if(inv[i]!=null && inv[i].effects !=null){
				string[] alleffects = inv[i].effects;
				for(int e = 0; e < alleffects.Length;e++){
					if (alleffects[e].Contains("T")){
						if (alleffects[e].Contains("+")){
							PlayerStats.warming+= int.Parse(alleffects[e].Substring(2));
						}else if(alleffects[e].Contains("-")){
							PlayerStats.warming-= int.Parse(alleffects[e].Substring(2));
						}
					}
				}
			}
		}
		
	}
	

}

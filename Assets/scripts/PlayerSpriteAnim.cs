using UnityEngine;
using System.Collections;

public class PlayerSpriteAnim : MonoBehaviour {
	
	public int AnimationNo = 0;
	public int spriteNo = 0;
	private float currentAnimTime = 0.0f;
	private float AnimTime = 0.07f;
	private float IdleTime = 0.5f;

	public bool UIBreak0 = false;
	public int Anim0start = 0;
	public int Anim0Length = 5;
	public bool UIBreak1 = false;
	public int Anim1start = 8;
	public int Anim1Length = 10;
	public bool UIBreak2 = false;
	public int Anim2start = 5;
	public int Anim2Length = 1;

	private int currentStart = 0;
	private int currentLength = 0;
	private int seriesNo =0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (AnimationNo != 0 && AnimationNo != 2) {
			if (currentAnimTime >= AnimTime) {
				seriesNo++;
				currentAnimTime = 0.0f;
			} else {
				currentAnimTime += Time.deltaTime;
			}
		} else {
			if (currentAnimTime >= IdleTime) {
				seriesNo++;
				currentAnimTime = 0.0f;
			} else {
				currentAnimTime += Time.deltaTime;
			}
		
		}

		if (AnimationNo == 0) {currentStart=Anim0start;currentLength=Anim0Length;}
		if (AnimationNo == 1) {currentStart=Anim1start;currentLength=Anim1Length;}
		if (AnimationNo == 2) {currentStart=Anim2start;currentLength=Anim2Length;}

		if (seriesNo > currentLength) {
			seriesNo =0;
		}
		spriteNo = currentStart + seriesNo;
		

		foreach(Transform child in transform){
			if(child.GetComponent<Spritable>() !=null){
				child.GetComponent<Spritable>().spriteNo=spriteNo;

			}
		}

	}
}

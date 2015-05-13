using UnityEngine;
using System.Collections;
[RequireComponent (typeof (SpriteRenderer))]
public class Spritable : MonoBehaviour {

	//public string TEMPNAME = "sprites/f/body";
	[HideInInspector]
	public Sprite[] baseSprites;
	public int spriteNo = 0;
	SpriteRenderer renderSprite;

	// Use this for initialization
	void Start () {
		//baseSprites = Resources.LoadAll<Sprite> (TEMPNAME);

		renderSprite = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		renderSprite.sprite = baseSprites [spriteNo];
	}
}

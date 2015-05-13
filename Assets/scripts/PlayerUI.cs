using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	public Image healthbar;
	public Image stambar;
	public Image tempbar;
	public Image frozen;
	PlayerStats player;

	void Start () {
		player = GameObject.Find ("Player").GetComponent<PlayerStats> ();

	}

	void Update () {
		healthbar.fillAmount = Mathf.Lerp(healthbar.fillAmount,(float)player.health / (float)player.maxHealth,1.0f * Time.deltaTime);
		stambar.fillAmount = (player.stamina / 100);
		tempbar.fillAmount = (PlayerStats.extTemp+20)/40 ;
		frozen.color =new Color(1,1,1,PlayerStats.freezeTimer/200);
	}
}

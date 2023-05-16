using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour{
	[SerializeField] DieHandler dieHandler;
	EnemyBase enemy;
	public int life = 10;
	private bool spawnable = true;
	public float interval;

	void Start(){
		enemy = Resources.Load<EnemyBase>("Enemy/Enemy");
	}

	void Update(){
		if(spawnable){
			Instantiate(enemy);
			StartCoroutine(Cooldown());
		}
	}

	IEnumerator Cooldown(){
		spawnable = false;
		yield return new WaitForSeconds(interval);
		spawnable = true;
	}
}

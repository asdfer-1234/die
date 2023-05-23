using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDie : DieObject{
	public Bullet bullet;
	public float interval;
	private bool shootable = true;
	private GameHandler gameHandler;


	void Start(){
		gameHandler = GameObject.FindGameObjectWithTag("Game Handler").GetComponent<GameHandler>();
	}

	void Update(){
		EnemyBase enemy = gameHandler.firstEnemy;
		if(shootable && enemy != null){
			StartCoroutine(Cooldown());
			Shoot(enemy.transform.position);
		}
	}

	public void Shoot(Vector2 target){
		Bullet instantiated = Instantiate<Bullet>(bullet);
		instantiated.transform.position = transform.position;
		instantiated.Fly(target);
	}

	private IEnumerator Cooldown(){
		shootable = false;
		yield return new WaitForSeconds(interval);
		shootable = true;
	}
}

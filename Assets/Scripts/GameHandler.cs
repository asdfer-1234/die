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
			// 이거 startcoroutine 안해주면 1프레임 단위로 이 코드가 실행됨
			StartCoroutine(Cooldown());
		}
	}
	
	// 변수 방식의 코루틴 활용 쿨다운 - StartCoroutine 안썼으면 대참사 날수도 있음
	IEnumerator Cooldown(){
		spawnable = false;
		yield return new WaitForSeconds(interval);
		spawnable = true;
	}
}

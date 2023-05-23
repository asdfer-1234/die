using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 네이밍에 시간 투자할 필요 없어 그냥 이렇게 지어
public class Bullet : MonoBehaviour{
	// 그래 체력이나 데미지 같은거 소수로 하는거 아니야
	public int damage;
	public float speed;
	private Vector2 direction;
	public float lifetime;

	public void Fly(Vector2 target){
		direction = (target - (Vector2)transform.position).normalized * speed;
	}

	void Start(){
		StartCoroutine(Decay());
	}
	void Update(){
		transform.Translate(direction * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collider){
		EnemyBase enemy = collider.GetComponent<EnemyBase>();
		if(enemy != null){
			enemy.health -= damage;
			Destroy(gameObject);
		}
	}

	private IEnumerator Decay(){
		yield return new WaitForSeconds(lifetime);
		Destroy(gameObject);
	}
}

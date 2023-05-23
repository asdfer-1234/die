using UnityEngine;

public class EnemyBase : MonoBehaviour{
	[HideInInspector]public float progress = 0f;
	public float speed;
	private PathHandler pathHandler;
	private GameHandler gameHandler;
	public int startingHealth;
	public int health{
		get => mHealth;
		set{
			mHealth = value;
			if(mHealth <= 0){
				Destroy(gameObject);
			}
		}
	}
	private int mHealth;


	void Start(){
		// 나는 게임핸들러 이거 찾고 아래 함수로 그냥 바로 오브젝트 찾아서 씀. 알아서 수정하시길
		pathHandler = GameObject.FindGameObjectWithTag("Game Handler").GetComponent<PathHandler>();
		gameHandler = GameObject.FindGameObjectWithTag("Game Handler").GetComponent<GameHandler>();
		mHealth = startingHealth;
	}


	void Update(){
		progress += Time.deltaTime * speed;
		transform.position = pathHandler.GetEnemyPoint(progress);
		if(progress >= pathHandler.pathLength){
			gameHandler.life--;
			Destroy(gameObject);
		}
	}

}


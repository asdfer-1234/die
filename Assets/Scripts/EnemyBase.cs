using UnityEngine;

public class EnemyBase : MonoBehaviour{
	private float progress = 0f;
	public float speed;
	private PathHandler pathHandler;
	private GameHandler gameHandler;


	void Start(){
		// 나는 게임핸들러 이거 찾고 아래 함수로 그냥 바로 오브젝트 찾아서 씀. 알아서 수정하시길
		pathHandler = GameObject.FindGameObjectWithTag("Game Handler").GetComponent<PathHandler>();
		gameHandler = GameObject.FindGameObjectWithTag("Game Handler").GetComponent<GameHandler>();
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


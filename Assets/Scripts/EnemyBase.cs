using UnityEngine;

public class EnemyBase : MonoBehaviour{
	private float progress = 0f;
	public float speed;
	private PathHandler pathHandler;
	private GameHandler gameHandler;


	void Start(){
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


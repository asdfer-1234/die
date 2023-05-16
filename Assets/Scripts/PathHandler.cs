using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class PathHandler : MonoBehaviour{
	public Vector2[] path;
	private float[] pathSum;

	public float pathLength => pathSum[pathSum.Length - 1];
	
	// 어디까지 왔니
	public Vector2 GetEnemyPoint(float t){
		int index = GetPointIndex(t);
		
		// 내분해주는 함수
		return Vector2.Lerp(path[index], path[index + 1], (t - pathSum[index]) / (pathSum[index + 1] - pathSum[index]));
	}

	void Start(){
		// "대충 어디냐"랑 "어디까지 왔니" 용 지도 그려주기
		pathSum = new float[path.Length];
		for(int i = 1; i < path.Length; i++){
			pathSum[i] = (path[i - 1] - path[i]).magnitude;
			pathSum[i] += pathSum[i - 1];
		}
	}

	// 대충 어디냐
	private int GetPointIndex(float progress){
		for(int i = 1; i < pathSum.Length; i++){
			if(pathSum[i] > progress){
				return i - 1;
			}
		}
		return pathSum.Length - 2;
	}
	
	void OnDrawGizmos(){
		// 이런걸로 디버깅할때 색놀이하는게 가장 재밌다
		Gizmos.color = Color.cyan;
		for(int i = 0; i < path.Length - 1; i++){
			// 아래 주석 해제해서 **무지개** 를 얻을 수 있다
			//Gizmos.color = Random.HSVColor();
			Gizmos.DrawLine(path[i], path[i + 1]);
		}
	}
}

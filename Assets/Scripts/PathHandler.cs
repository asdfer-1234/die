using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class PathHandler : MonoBehaviour{
	public Vector2[] path;
	private float[] pathSum;

	public float pathLength => pathSum[pathSum.Length - 1];
	
	/// returns where the enemy should be in a given time
	public Vector2 GetEnemyPoint(float t){
		int index = GetPointIndex(t);
		
		// Lerp lerp lerp erp
		return Vector2.Lerp(path[index], path[index + 1], (t - pathSum[index]) / (pathSum[index + 1] - pathSum[index]));
	}

	void Start(){
		pathSum = new float[path.Length];
		for(int i = 1; i < path.Length; i++){
			pathSum[i] = (path[i - 1] - path[i]).magnitude;
			pathSum[i] += pathSum[i - 1];
		}
	}

	private int GetPointIndex(float progress){
		for(int i = 1; i < pathSum.Length; i++){
			if(pathSum[i] > progress){
				return i - 1;
			}
		}
		return pathSum.Length - 2;
	}
	
	void OnDrawGizmos(){
		Gizmos.color = Color.cyan;
		for(int i = 0; i < path.Length - 1; i++){
			Gizmos.DrawLine(path[i], path[i + 1]);
		}
	}
}

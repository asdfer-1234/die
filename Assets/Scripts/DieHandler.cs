using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieHandler : MonoBehaviour
{
	private DieObject diePrefab;
	private Vector2 originPosition;
	private CustomGrid grid;

	void Start(){
		originPosition = Vector2.zero;
		diePrefab = Resources.Load<DieObject>("Die/Die");
		grid = new CustomGrid();
	}

	void Update(){
		if(Input.GetMouseButtonDown(0)){
			SpawnDieInRandomPosition();
		}
	}

	public DieObject SpawnDie(Vector2Int position){
		DieObject instantiated = Instantiate(diePrefab, CustomGrid.GridToWorldPoint(position, originPosition), Quaternion.identity);
		grid.SetObject(position, instantiated);
		return instantiated;
	}

	public DieObject SpawnDieInRandomPosition(){
		if(grid.IsGridFull()){
			Debug.LogError("Board is full.");
			return null;
		}
		Vector2Int position;
		while(true){
			position = new Vector2Int(Random.Range(0, CustomGrid.size.x), Random.Range(0, CustomGrid.size.y));
			if(!grid.ObjectExists(position)){
				break;
			}
		}
		return SpawnDie(position);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class DieHandler : MonoBehaviour
{
	// private라고 언더바를 붙이시네 나는 안해야지
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
			throw new Exception("Wha- The Board is full! What did you thought it was gonna happen? Thank god i made this message that prevents an eternal labor");
		}
		Vector2Int position;
		// 😏
		while(true){
			position = new Vector2Int(Random.Range(0, CustomGrid.size.x), Random.Range(0, CustomGrid.size.y));
			if(!grid.ObjectExists(position)){
				break;
			}
		}
		return SpawnDie(position);
	}
}

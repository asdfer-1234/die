using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomGrid
{
	public static readonly Vector2Int size = new Vector2Int(10, 10);
	public static int cellCount => size.x * size.y;
	public static readonly float cellSize = 1.2f;


	private DieObject[,] gridArray;

	public CustomGrid(){
		gridArray = new DieObject[size.x, size.y];
	}

	private int dieCount = 0;



	public static Vector2 GridToWorldPoint(Vector2Int position, Vector2 origin){
		return ((Vector2)(position) - (Vector2)(size - Vector2Int.one) / 2f) * cellSize + origin;
	}

	public void SetObject(Vector2Int position, DieObject dieObject){
		if(ObjectExists(position)){
			throw new Exception("You waht");
		}
		gridArray[position.x, position.y] = dieObject;
		dieCount++;
	}

	public bool ObjectExists(Vector2Int position){
		return gridArray[position.x, position.y] != null;
	}

	public bool IsGridFull(){
		return dieCount >= cellCount;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomGrid
{
	// Vector2Int쓰면 이제 xy값 정수로 한다고 분리할 필요 없다 함 써봐라
	public static readonly Vector2Int size = new Vector2Int(10, 10);
	// 프로퍼티 이렇게 만들어두면 cellCount를 불러올때마다 함수를 호출한다 이거 좋음
	public static int cellCount => size.x * size.y;
	public static readonly float cellSize = 1.2f;

	// Dice는 복수형이다 Die쓰라
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
			// 꽉 차면 이 메시지 에러로 뜬다
			throw new Exception("waht the");
		}
		gridArray[position.x, position.y] = dieObject;
		// 우리는 여기서 dieCount를 사용하고 프로퍼티를 사용하지 않는 것이 좋은 선택일지 고민을 할 필요는 없지만 해보면 좋을거다
		dieCount++;
	}
	
	// 굳이 이 함수가 필요할까?
	public bool ObjectExists(Vector2Int position){
		return gridArray[position.x, position.y] != null;
	}

	// 이걸 프로퍼티로 만들수도 있다 C#정신이라면 그렇게 하겠지
	public bool IsGridFull(){
		return dieCount >= cellCount;
	}
}

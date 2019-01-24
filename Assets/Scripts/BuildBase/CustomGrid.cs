using System;
using UnityEngine;

public class CustomGrid : MonoBehaviour {

	public GameObject target;
	public GameObject structure;
	Vector3 pos;
	public float gridSize;
	public Vector2 gridDimensions;
	public Tile tilePrefab;
	public Tile[,] tilesMatrix;

	void Awake() {
		GridSetup ();
	}

	void LateUpdate () {
		pos.x = Mathf.Floor(target.transform.position.x / gridSize) * gridSize;
        pos.y = structure.transform.position.y;
		pos.z = Mathf.Floor(target.transform.position.z / gridSize) * gridSize;

		structure.transform.position = pos;
	}

	void GridSetup() {

		if (tilePrefab != null) 
		{
			var tilesParent = new GameObject("Container");
			tilesParent.transform.parent = transform;
			tilesParent.transform.localPosition = new Vector3(0, 0, 0);
			tilesParent.transform.localRotation = new Quaternion(0, 0, 0, 1);
			tilesMatrix  = new Tile[(int) gridDimensions.x, (int) gridDimensions.y];

			for (int y = 0; y < gridDimensions.y; y++)
			{
				for (int x = 0; x < gridDimensions.x; x++)
				{
					Vector3 localPos = new Vector3 (x + 0.5f, 0, y + 0.5f) * gridSize;
					Vector3 targetPos = transform.TransformPoint (localPos);
					targetPos.y += 0.01f;
					Tile newTile = Instantiate(tilePrefab);
					newTile.transform.parent = tilesParent.transform;
					newTile.transform.position = targetPos;
					newTile.transform.localRotation = Quaternion.identity;

					tilesMatrix[x, y] = newTile;
					newTile.SetState(true);
				}
			
			}
		
		}
	
	}

}

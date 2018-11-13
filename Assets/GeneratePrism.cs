using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePrism{



	public List<Vector3[]> vertices;
	public int[] indices = {
		0, 2, 1,

		3, 2, 0,
		3, 5, 2,

		1, 2, 5,
		5, 4, 1,

		1, 4, 0,
		4, 3, 0,

		3, 4, 5};

	public GeneratePrism(int numberOfEdges, float radius, float height) {
		vertices = new List<Vector3[]>();

		Vector3[] points;

		for(int i = 0; i < numberOfEdges; i++) {
			points = new Vector3[6];
			points[0] = new Vector3(0, 0, 0);
			points[1] = Quaternion.AngleAxis(360/(float)numberOfEdges * i, Vector3.up) * new Vector3(radius, 0, 0);
			points[2] = Quaternion.AngleAxis(360/(float)numberOfEdges * (i + 1), Vector3.up) * new Vector3(radius, 0, 0);
			points[3] = new Vector3(0, height, 0);
			points[4] = Quaternion.AngleAxis(360 / (float)numberOfEdges * i, Vector3.up) * new Vector3(radius, height, 0);
			points[5] = Quaternion.AngleAxis(360 / (float)numberOfEdges * (i + 1), Vector3.up) * new Vector3(radius, height, 0);

			vertices.Add(points);
		}
	}

}

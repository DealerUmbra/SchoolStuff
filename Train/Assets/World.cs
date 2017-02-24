using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class World : MonoBehaviour {

    public int width;
    public int height;

    Mesh mesh;
    Vector3[] vertices;
    List<int> triangles;

	// Use this for initialization
	void Start () {
        mesh = GetComponent<MeshFilter>().mesh = new Mesh();

        vertices = new Vector3[width * height];
        triangles = new List<int>();

        for(int i=0; i<width; i++)
        {
            for(int j=0; j<height; j++)
            {
                vertices[i] = new Vector3(i, 0, j);
            }
        }
        for(int i=0; i<width - 1; i++)
        {
            for(int j=0; j<height - 1; j++)
            {
                int curIndex = i * width + j;
                print(curIndex);
                AddQuad(curIndex, curIndex + 1, curIndex + width, curIndex + width + 1);
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void AddQuad(int v1, int v2, int v3, int v4)
    {
        triangles.Add(v1);
        triangles.Add(v2);
        triangles.Add(v3);
        triangles.Add(v2);
        triangles.Add(v4);
        triangles.Add(v3);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

    public int xSize = 20, zSize = 20; // The dimensions of the terrain
    public int maxHeight = 10;

    private Vector3[] vertices;
    private int[] triangles;

    Mesh mesh;


    // Start is called before the first frame update
    void Start() {

        mesh = new Mesh ();

        GetComponent<MeshFilter>().mesh = mesh;

        vertices = new Vector3[(xSize + 1) * (zSize + 1)]; // The number of vertices in each dimension is the number of edges + 1

        int i = 0;
        for (int z = 0; z <= zSize; z++) {
            for (int x = 0; x <= xSize; x++) {
                vertices[i++] = new Vector3 (x, Mathf.PerlinNoise(x * 0.6f, z * 0.1f) * maxHeight, z);
            }
        }

        int nSquares = (xSize) * (zSize);
        triangles = new int[nSquares * 6];


        int vert = 0;
        int triangle = 0;


        for(int z = 0; z < zSize; z++) {
            for (int x = 0; x < xSize; x++) {
                triangles[triangle + 0] = vert;
                triangles[triangle + 1] = vert + xSize + 1;
                triangles[triangle + 2] = vert + 1;

                triangles[triangle + 3] = vert + 1;
                triangles[triangle + 4] = vert + xSize + 1;
                triangles[triangle + 5] = vert + xSize + 2;


                triangle += 6;
                vert++;
            }

            vert++;
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

    }

    private void OnDrawGizmos() {

        if (vertices != null) {
            int size = vertices.Length;

            for (int i = 0; i < size; i++) {
                Gizmos.DrawSphere (vertices[i], 0.2f);
            }

        }

    }


}

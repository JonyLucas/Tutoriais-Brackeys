using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible to generate a quad mesh
/// </summary>
[RequireComponent(typeof(MeshFilter))]  
public class GenerateMeshScript : MonoBehaviour {
    
    Mesh mesh;

    Vector3[] vertices; // The vertices of the mesh to be draw
    int[] triangles; // The index (on clockwise direction) of the vertices that will form a triangle

    [SerializeField]
    private float size; // The size of the mesh

    [SerializeField]
    private bool horizontal; // The direction of the mesh

    [SerializeField]
    private Vector3 origin; // The origin point

    // Start is called before the first frame update
    void Start() {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateQuad(origin, size, horizontal);

    }


    private void CreateQuad(Vector3 origin, float size, bool horizontal) {

        if (horizontal) {
            vertices = new Vector3[] {
                new Vector3(0,0,0),
                new Vector3(size, 0, 0),
                new Vector3(0, 0, size),
                new Vector3(size, 0, size)
            };

            triangles = new int[] {
                0, 2, 1,
                3, 1, 2
            };

        } else {

            vertices = new Vector3[] {
                new Vector3(0,0,0),
                new Vector3(0, size, 0),
                new Vector3(size, 0, 0),
                new Vector3(size, size, 0)
            };

            triangles = new int[] {
                0, 1, 2,
                3, 2, 1
            };

        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

    }


}

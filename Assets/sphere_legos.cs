using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere_legos : MonoBehaviour
{
    public Material mat;

    public int width, height, depth;
    List<Vector3> centres = new List<Vector3>();

    Vector3[] vertices;
    int[] triangles;


    // Start is called before the first frame update
    void Start()
    {

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        
        centres.Add(new Vector3(12, 12, 12));
        centres.Add(new Vector3(24, 24, 24));

        drawLegos(30, 60, 30,  centres, 10);

        Mesh msh = new Mesh();

        msh.vertices = vertices;
        msh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = msh;
        gameObject.GetComponent<MeshRenderer>().material = mat;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void drawLegos(int w, int h, int d, List<Vector3> c, int r){
        
        vertices = new Vector3[w * h * d];
        // triangles = new int [h*w*2];
        int v = 0;
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                for (int k = 0; k < d; k++)
                {
                    // List<float> distances;
                    Vector3 current = new Vector3(i, j, k);
                    bool draw = false;

                    foreach (Vector3 centre in centres)
                    {
                        Vector3 distance = current - centre;
                        float dist = distance.magnitude;
                        if(dist < r) {
                            draw = true;
                        }

                    }
                    // Debug.Log(dist);

                    if (draw){

                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.position = new Vector3(i, j, k);


                    }

                }


            }
        }

    }
    
    private void OnDrawGizmos()
    {
        if (vertices == null) return;
        // DrawSphere();
        Gizmos.color = Color.white;
        foreach (var point in vertices)
        {
            Gizmos.DrawCube(point, new Vector3(0.1f, 0.1f, 0.1f));
        }
    }

}

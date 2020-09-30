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
        centres.Add(new Vector3(24, 18, 15));

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
                        foreach (Vector3 othercenter in centres)
                        {
                            if(othercenter == centre) continue;
                            Vector3 otherdistance = current - othercenter;
                            float otherdist = otherdistance.magnitude;
                            if(otherdist >= r) {
                            draw = false;
                        }

                        }
                    }

                    if (draw){

                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.position = new Vector3(i, j, k);


                    }

                }


            }
        }

    }

    public void draw_intersec(int w, int h, int d, List<Vector3> c, int r)
    {
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
                        if (dist < r)
                        {
                            draw = true;
                        }


                    }

                    if (draw)
                    {

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

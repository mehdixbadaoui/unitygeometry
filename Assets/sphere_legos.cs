using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class sphere_legos : MonoBehaviour
{
    public Material mat;

    public int width, height, depth;
    List<Vector3> centres = new List<Vector3>();

    Vector3[] vertices;
    int[] triangles;

    float step = 1;



    // Start is called before the first frame update
    void Start()
    {
        width = 30;
        height = 60;
        depth = 30;
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        
        // centres.Add(new Vector3(12, 12, 12));
        centres.Add(new Vector3(15, 15, 15));
        centres.Add(new Vector3(24, 24, 24));

        // drawLegos(centres, 10, step);
        draw_intersec(centres, 10, step);
        // draw_diff(width, height, depth, new Vector3(12, 12, 12), centres, 10);

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
    public void drawCube(Vector3 v, float step){
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale =new Vector3 (step, step, step);
        cube.transform.position = v;
        cube.GetComponent<Renderer>().material.color = new Color(0f,0.7f,1f,1);

    }

    public void drawLegos(List <Vector3> c, int r, float step){
        
        // starting point and ending point
        Vector3 min = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        Vector3 max = new Vector3(0, 0, 0);
        foreach(Vector3 center in c){
            max.x = Math.Max(max.x, center.x);
            max.y = Math.Max(max.y, center.y);
            max.z = Math.Max(max.z, center.z);

            min.x = Math.Min(min.x, center.x);
            min.y = Math.Min(min.y, center.y);
            min.z = Math.Min(min.z, center.z);
            
        }

        for (float i = min.x - r; i < max.x + r; i+=step)
        {
            for (float j = min.y - r; j < max.y + r; j+=step)
            {
                for (float k = min.z - r; k < max.z + r; k+=step)
                {
                    // List<float> distances;
                    Vector3 current = new Vector3(i, j, k);
                    bool draw = false;

                    foreach (Vector3 centre in c)
                    {
                        Vector3 distance = current - centre;
                        float dist = distance.magnitude;
                        if(dist < r) {
                            draw = true;
                        }
                    }

                    if (draw){
                        drawCube(current, step);

                    }

                }


            }
        }

    }

    public void draw_intersec(List <Vector3> c, int r, float step){
        Vector3 min = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        Vector3 max = new Vector3(0, 0, 0);
        foreach(Vector3 center in c){
            max.x = Math.Max(max.x, center.x);
            max.y = Math.Max(max.y, center.y);
            max.z = Math.Max(max.z, center.z);

            min.x = Math.Min(min.x, center.x);
            min.y = Math.Min(min.y, center.y);
            min.z = Math.Min(min.z, center.z);
            
        }

        for (float i = min.x - r; i < max.x + r; i+=step)
        {
            for (float j = min.y - r; j < max.y + r; j+=step)
            {
                for (float k = min.z - r; k < max.z + r; k+=step)
                {
                    // List<float> distances;
                    Vector3 current = new Vector3(i, j, k);
                    bool draw = false;

                    foreach (Vector3 centre in c)
                    {
                        Vector3 distance = current - centre;
                        float dist = distance.magnitude;
                        if (dist < r)
                        {
                            draw = true;
                        }
                        foreach (Vector3 othercenter in c)
                        {
                            if(othercenter == centre) continue;
                            Vector3 otherdistance = current - othercenter;
                            float otherdist = otherdistance.magnitude;
                            if(otherdist >= r) {
                            draw = false;
                        }

                        }



                    }

                    if (draw)
                    {
                        drawCube(current, step);
                    }

                }


            }
        }

    }

    private void draw_diff(int w, int h, int d, Vector3 c1, List<Vector3> c, int r){

        int v = 0;
        for (float i = 0; i < h; i+=0.5f)
        {
            for (float j = 0; j < w; j+=0.5f)
            {
                for (float k = 0; k < d; k+=0.5f)
                {
                    // List<float> distances;
                    Vector3 current = new Vector3(i, j, k);
                    bool draw = false;

                    Vector3 distance = current - c1;
                    float dist = distance.magnitude;
                    if(dist < r) {
                        draw = true;
                    }

                    foreach (Vector3 centre in c)
                    {
                        Vector3 distance2 = current - centre;
                        float dist2 = distance2.magnitude;
                        if(dist2 < r) {
                            draw = false;
                        }
                    }

                    if (draw){

                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.localScale =new Vector3 (0.5f, 0.5f, 0.5f);
                        cube.transform.position = new Vector3(i, j, k);


                    }

                }


            }
        }


    }
    private void OnDrawGizmos()
    {
        // if (vertices == null) return;
        // Gizmos.color = Color.black;
        // Gizmos.DrawSphere(new Vector3, new Vector3(0.1f, 0.1f, 0.1f));
        // foreach (Vector3 point in vertices)
        // {
        //     Gizmos.DrawCube(point, new Vector3(0.1f, 0.1f, 0.1f));
        // }
    }

}

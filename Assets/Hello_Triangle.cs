using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Hello_Triangle : MonoBehaviour
{

    public Material mat;

    int yrows = 3;
    int xcols = 4;

    Vector3[] vertices;
    int[] triangles;


    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();


        //plan();

        // circle(new Vector3(0, 0, 0), 3, 4);

        // cylindre(new Vector3(0, 0, 0), 3, 60, 10);

        sphere(new Vector3(0, 10, 0), 4, 4, 2);

        Mesh msh = new Mesh();

        msh.vertices = vertices;
        msh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = msh;
        gameObject.GetComponent<MeshRenderer>().material = mat;


    }

    void plan(){

        vertices = new Vector3[(yrows+1)* (xcols+1)];
        triangles = new int[6 * yrows * xcols];

        int v = 0;
        for(int x = 0; x <= xcols; x++){
            for(int y = 0; y <= yrows; y++){
                vertices[v] = new Vector3(y, x, 0);
                Debug.Log(vertices[v]);
                v++;
            }

        }

        int vert = 0;
        int tri = 0;

        for(int i = 0; i < xcols; i++){ 
            for(int j = 0; j < yrows; j++){

                triangles[tri] = vert;                  Debug.Log(tri+" "+vert);
                triangles[tri + 1] = vert + 1;          Debug.Log((tri + 1)+" "+(vert + 1));
                triangles[tri + 2] = vert + yrows + 1;   Debug.Log((tri + 2)+" "+(vert + yrows + 1));
                triangles[tri + 3] = vert + yrows + 1;   Debug.Log((tri + 3)+" "+(vert + yrows + 1));
                triangles[tri + 4] = vert + 1;          Debug.Log((tri + 4)+" "+(vert + 1));
                triangles[tri + 5] = vert + yrows +2;    Debug.Log((tri + 5)+" "+(vert + yrows +2));

                vert ++;
                tri += 6;

            }
            vert++;
        }
        // yield return new WaitForSeconds(.1f);



    }

    void circle(Vector3 c, int r, int edges){
        int rotate = 360 / edges;
        vertices = new Vector3[edges + 1];
        triangles = new int[ 3*edges];

        int start = 0;
        int angle = 0;

        vertices[0] = c;
        for (int i = 1; i <= edges; i++)
        {
            vertices[i] = new Vector3(r * (float)Math.Cos(angle * Math.PI / 180), 0, r * (float)Math.Sin(angle * Math.PI / 180));
            angle += rotate;
        }

        int tri = start;
        for (int i = 1; i < edges; i++)
        {
            triangles[tri] = 0;
            triangles[tri+1] = i + 1;
            triangles[tri+2] = i;

        tri += 3;
        }

        triangles[tri] = start;
        triangles[tri+1] = start + 1;
        triangles[tri+2] = edges;


    }

    void cylindre(Vector3 c, float r, int edges, float height){

        // int     void circle(Vector3 c, int r, int edges){
        int rotate = 360 / edges;
        vertices = new Vector3[2* (edges + 1)];
        triangles = new int[ 12*edges];


        int angle = 0;
        vertices[0] = c;
        vertices[edges + 1] = c + new Vector3(0, height, 0);

        for (int i = 1; i <= edges; i++)
        {
            vertices[i] = new Vector3(r * (float)Math.Cos(angle * Math.PI / 180), 0, r * (float)Math.Sin(angle * Math.PI / 180));
            vertices[edges + 1 + i] = new Vector3(r * (float)Math.Cos(angle * Math.PI / 180), height, r * (float)Math.Sin(angle * Math.PI / 180));
            angle += rotate;

        }
        int start_bottom = 0;
        int start_top = edges + 1;

        int tri = 0;
        for (int i = 1; i < edges; i++)
        {
            triangles[tri] = start_bottom;
            triangles[tri+2] = i + 1;
            triangles[tri+1] = i;

            triangles[tri+3] = start_top;
            triangles[tri+4] = i + edges +2;
            triangles[tri+5] = i + edges + 1;

            triangles[tri+6] = i;
            triangles[tri+8] = i + edges + 2;
            triangles[tri+7] = i + edges + 1;

            triangles[tri+9] = i;
            triangles[tri+10] = i + edges +2;
            triangles[tri+11] = i + 1;



        tri += 12;
        }

        triangles[tri] = start_bottom;
        triangles[tri+1] = edges;
        triangles[tri+2] = start_bottom + 1;

        triangles[tri+3] = start_top;
        triangles[tri+4] = start_top + 1;
        triangles[tri+5] = 2*edges + 1;

        triangles[tri+6] = start_bottom + 1;
        triangles[tri+7] = edges;
        triangles[tri+8] = 2*edges + 1;

        triangles[tri+9] = start_bottom + 1;
        triangles[tri+10] = 2*edges + 1;
        triangles[tri+11] = start_top + 1;


    }

    void sphere(Vector3 c, int r, int edges, int etages){
        int rotate = 360 / edges;
        vertices = new Vector3[2*etages*(edges + 1) + 1];
        triangles = new int[ etages*(3*edges)];

        int start = 0;
        int angle = 0;

        vertices[0] = c;
        int v = 1;

        for (int i = 1; i <= edges; i++)
        {
            vertices[v] = new Vector3(r * (float)Math.Cos(angle * Math.PI / 180), 10, r * (float)Math.Sin(angle * Math.PI / 180));
            angle += rotate;
            v++;
        }
        Debug.Log(v);

        for(int i = 1; i< etages; i++){

            vertices[v] = new Vector3(0, r + i*r/etages, 0);
            v++;
            for (int j = 1; j <= edges; j++)
            {
                float height = r  i*r/etages;
                double new_r = Math.Sqrt(r*r - (i*r/etages)*(i*r/etages));
                Debug.Log("old " + r + " new " + new_r);
                vertices[v] = new Vector3((float)new_r * (float)Math.Cos(angle * Math.PI / 180), height, (float)new_r * (float)Math.Sin(angle * Math.PI / 180));
                angle += rotate;
                v++;
            }

            vertices[v] = new Vector3(0, r - i*r/etages, 0);
            v++;
            for (int j = 1; j <= edges; j++)
            {
                float height = r - i*r/etages;
                double new_r = Math.Sqrt(r*r - (i*r/etages)*(i*r/etages));
                vertices[v] = new Vector3((float)new_r * (float)Math.Cos(angle * Math.PI / 180), height, (float)new_r * (float)Math.Sin(angle * Math.PI / 180));
                angle += rotate;
                v++;
            }


        }


    }

    private void OnDrawGizmos()
    {
        if (vertices == null) return;
        // DrawSphere();
        Gizmos.color = Color.black;
        foreach (var point in vertices)
        {
            Gizmos.DrawSphere(point, 0.1f);
        }
    }

    

}
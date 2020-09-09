﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello_Triangle : MonoBehaviour
{

    public Material mat;

    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();          // Creation d'un composant MeshFilter qui peut ensuite être visualisé
        gameObject.AddComponent<MeshRenderer>();

        Vector3[] vertices = new Vector3[4];            // Création des structures de données qui accueilleront sommets et  triangles
        int[] triangles = new int[6];

        vertices[0] = new Vector3(0, 0, 0);            // Remplissage de la structure sommet 
        vertices[1] = new Vector3(1, 0, 0);
        vertices[2] = new Vector3(0, 1, 0);
        vertices[3] = new Vector3(1, 1, 0);


        triangles[0] = 0;                               // Remplissage de la structure triangle. Les sommets sont représentés par leurs indices
        triangles[1] = 1;                               // les triangles sont représentés par trois indices (et sont mis bout à bout)
        triangles[2] = 2;
        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 3;





        Mesh msh = new Mesh();                          // Création et remplissage du Mesh

        msh.vertices = vertices;
        msh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = msh;           // Remplissage du Mesh et ajout du matériel
        gameObject.GetComponent<MeshRenderer>().material = mat;
    }
}
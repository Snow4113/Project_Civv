using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DeformableTerrain : MonoBehaviour
{
    public float deformationStrength = 0.1f;
    public float maxDeformation = 2.0f;
    private Mesh mesh;
    private Vector3[] originalVertices, modifiedVertices;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        originalVertices = mesh.vertices;
        modifiedVertices = mesh.vertices;
    }

    public void DeformTerrain(Vector3 position, bool isPulling)
    {
        for (int i = 0; i < modifiedVertices.Length; i++)
        {
            Vector3 vertexWorldPos = transform.TransformPoint(modifiedVertices[i]);
            float distance = Vector3.Distance(position, vertexWorldPos);

            if (distance < 1.0f)
            { // Radius of effect
                float deformation = deformationStrength * (1.0f - distance);
                modifiedVertices[i].y += isPulling ? deformation : -deformation;
                modifiedVertices[i].y = Mathf.Clamp(modifiedVertices[i].y, -maxDeformation, maxDeformation);
            }
        }
        mesh.vertices = modifiedVertices;
        mesh.RecalculateNormals();
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
}
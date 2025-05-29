using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    //unfortunetely it spawns the assests on their side and with great quantity, but it does work in spawning.

    [Header("Spawn Settings")]
    public GameObject resourcePrefab;
    public float spawnChance;

    [Header("Raycast Setting")]
    public float distanceBetweenCheck;
    public float heightOfCheck = 10f, rangeOfCheck = 30f;
    public LayerMask layerMask;
    public Vector2 positivePostion, negativePostion;

    private void Start()
    {
        spawnResources();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DeleteResource();
            spawnResources();
        }
    }

    void spawnResources()
    {
        for (float x = negativePostion.x; x < positivePostion.x; x += distanceBetweenCheck)
        {
            for (float z = negativePostion.y; z < positivePostion.y; z += distanceBetweenCheck)
            {
                RaycastHit hit;
                if (Physics.Raycast(new Vector3(x, heightOfCheck, z), Vector3.down, out hit, rangeOfCheck, layerMask))
                {
                    if (spawnChance > Random.Range(0, 101))
                    {
                        Instantiate(resourcePrefab, hit.point, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)), transform);
                    }
                }
            }
        }
    }

    void DeleteResource()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}

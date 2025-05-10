using System;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [Header("Key Setup")]
    public GameObject keyPrefab;              // Assign your key prefab here
    public Transform[] spawnPoints;           // Assign spawn points in the Inspector
    private List<GameObject> spawnedKeys = new List<GameObject>();

    public void SpawnKeys()
    {
        // Clean up any previously spawned keys
        foreach (GameObject Key in spawnedKeys)
        {
            if (Key != null)
                Destroy(Key);
        }
        spawnedKeys.Clear();

        // Shuffle spawn points
        List<Transform> availablePoints = new List<Transform>(spawnPoints);
        for (int i = 0; i < 3 && availablePoints.Count > 0; i++)
        {
            int index = UnityEngine.Random.Range(0, availablePoints.Count);
            Transform spawnPoint = availablePoints[index];
            availablePoints.RemoveAt(index);

            GameObject newKey = Instantiate(keyPrefab, spawnPoint.position, Quaternion.identity);
            spawnedKeys.Add(newKey);
        }
    }
}

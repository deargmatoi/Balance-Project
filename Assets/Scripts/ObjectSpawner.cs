using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Spawn edilecek objeler
    public float spawnInterval = 1f; // Spawn süresi
    public float spawnRangeX = 5f; // X eksenindeki rastgele aralık

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // Rastgele bir X pozisyonu seç
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

        // Rastgele bir obje seç
        int randomIndex = Random.Range(0, objectsToSpawn.Length);

        // Objeyi oluştur
        Instantiate(objectsToSpawn[randomIndex], spawnPosition, Quaternion.identity);
    }
}


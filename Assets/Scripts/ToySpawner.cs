using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToySpawner : MonoBehaviour
{
    public List<ToyObject> goodToys;
    public List<ToyObject> badToys;
    public float goodToyChance = 0.5f; // İyi oyuncakların çıkma şansı
    public GameObject toyTemplate; // Boş bir GameObject, tüm oyuncaklar buradan türetilecek
    public float upwardForce = 5f; // Yukarı uygulanan kuvvet

    public void SpawnToy(Vector3 spawnPosition)
    {
        // İyi veya kötü oyuncağı seç
        bool isGoodToy = Random.value < goodToyChance;
        ToyObject selectedToy;

        if (isGoodToy && goodToys.Count > 0)
        {
            selectedToy = goodToys[Random.Range(0, goodToys.Count)];
        }
        else if (!isGoodToy && badToys.Count > 0)
        {
            selectedToy = badToys[Random.Range(0, badToys.Count)];
        }
        else
        {
            Debug.LogWarning("Oyuncak listesi boş!");
            return;
        }

        // Yeni bir oyuncak oluştur ve ScriptableObject özelliklerini ata
        GameObject newToy = Instantiate(toyTemplate, spawnPosition, Quaternion.identity);
        ToyHolder holder = newToy.GetComponent<ToyHolder>();
        if (holder != null)
        {
            holder.InitializeToy(selectedToy);
        }

        // Yukarıya doğru kuvvet uygula
        Rigidbody2D rb = newToy.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);
        }
    }
}
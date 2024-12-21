/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToyTracker : MonoBehaviour
{
    [Header("Tracker Settings")]
    public int thresholdCount = 15; // Eşik değer
    public float duration = 3f; // Süre boyunca eşik sağlanmalı

    [Header("Event")]
    public UnityEvent onThresholdReached; // Eşik sağlandığında tetiklenecek event

    private List<GameObject> toysInZone = new List<GameObject>();
    private float timer;
    private bool isThresholdMet;

    void Update()
    {
        // İyi ve kötü oyuncakların yüzdesini hesapla
        CalculateToyPercentages(out float goodToyPercentage, out float badToyPercentage);

        // Eşiği kontrol et
        if (toysInZone.Count >= thresholdCount)
        {
            if (!isThresholdMet)
            {
                timer += Time.deltaTime;
                if (timer >= duration)
                {
                    isThresholdMet = true;
                    onThresholdReached?.Invoke(); // Event'i tetikle
                }
            }
        }
        else
        {
            timer = 0f; // Eşik sağlanmazsa süreyi sıfırla
            isThresholdMet = false;
        }

        // Debug için yüzdeleri göster
        Debug.Log($"Good Toys: {goodToyPercentage}%, Bad Toys: {badToyPercentage}%");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<ToyBehavior>(out ToyBehavior toy))
        {
            toysInZone.Add(other.gameObject); // Oyuncağı listeye ekle
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (toysInZone.Contains(other.gameObject))
        {
            toysInZone.Remove(other.gameObject); // Oyuncağı listeden çıkar
        }
    }

    private void CalculateToyPercentages(out float goodToyPercentage, out float badToyPercentage)
    {
        int goodToys = 0;
        int badToys = 0;

        foreach (GameObject toy in toysInZone)
        {
            if (toy.TryGetComponent<ToyBehavior>(out ToyBehavior toyBehavior))
            {
                if (toyBehavior.isGoodToy) goodToys++;
                else badToys++;
            }
        }

        int totalToys = goodToys + badToys;

        goodToyPercentage = totalToys > 0 ? (goodToys / (float)totalToys) * 100f : 0f;
        badToyPercentage = totalToys > 0 ? (badToys / (float)totalToys) * 100f : 0f;
    }
}*/

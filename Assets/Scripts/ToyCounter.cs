using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToyCounter : MonoBehaviour
{
    public int targetToyCount = 10; // Hedef oyuncak sayısı
    public float countdownDuration = 3f; // 3 saniyelik geri sayım
    public TextMeshProUGUI scoreText; // Toplam puanı gösterecek Text
    public TextMeshProUGUI toyCountText; // Anlık oyuncak sayısını gösterecek Text
    private HashSet<GameObject> collidingToys = new HashSet<GameObject>();
    private Coroutine countdownCoroutine;
    private int totalPoints = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        ToyObject toy = other.GetComponent<ToyHolder>()?.toy;
        
        if (toy != null && !collidingToys.Contains(other.gameObject))
        {
            collidingToys.Add(other.gameObject);
            UpdateToyCountText();
            
            if (collidingToys.Count >= targetToyCount && countdownCoroutine == null)
            {
                countdownCoroutine = StartCoroutine(StartCountdown());
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (collidingToys.Contains(other.gameObject))
        {
            collidingToys.Remove(other.gameObject);
            UpdateToyCountText();

            if (collidingToys.Count < targetToyCount && countdownCoroutine != null)
            {
                StopCoroutine(countdownCoroutine);
                countdownCoroutine = null;
            }
        }
    }

    void UpdateToyCountText()
    {
        if (toyCountText != null)
        {
            toyCountText.text = collidingToys.Count.ToString();
        }
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(countdownDuration);

        if (collidingToys.Count >= targetToyCount)
        {
            int goodToyCount = 0;
            int badToyCount = 0;
            totalPoints = 0;

            foreach (GameObject obj in collidingToys)
            {
                ToyObject toy = obj.GetComponent<ToyHolder>()?.toy;
                if (toy != null)
                {
                    totalPoints += toy.point;
                    if (toy.isGoodToy)
                    {
                        goodToyCount++;
                    }
                    else
                    {
                        badToyCount++;
                    }
                }
            }

            if (scoreText != null)
            {
                scoreText.text = "Toplam Puan: " + totalPoints;
            }

            float badToyPercentage = (float)badToyCount / collidingToys.Count * 100;
            if (badToyPercentage >= 50)
            {
                SceneManager.LoadScene("BadEnding");
            }
            else
            {
                SceneManager.LoadScene("GoodEnding");
            }
        }
        countdownCoroutine = null;
    }
}

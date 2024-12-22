using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageSequence : MonoBehaviour
{
    public Sprite[] images; // Sýrayla gösterilecek görseller
    public Image displayImage; // UI'deki Image bileþeni
    public string nextSceneName; // Geçilecek sahne adý

    private int currentIndex = 0; // Þu anda gösterilen görselin indeksi

    void Start()
    {
        if (images.Length > 0)
        {
            displayImage.sprite = images[currentIndex]; // Ýlk görseli göster
        }
        else
        {
            Debug.LogError("Görseller atanmadý!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Enter tuþuna basýldýðýnda
        {
            ShowNextImage();
        }
    }

    void ShowNextImage()
    {
        currentIndex++; // Bir sonraki görsele geç

        if (currentIndex < images.Length)
        {
            displayImage.sprite = images[currentIndex]; // Yeni görseli göster
        }
        else
        {
            SceneManager.LoadScene(nextSceneName); // Son görselden sonra sahneye geç
        }
    }
}

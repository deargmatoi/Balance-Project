using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Yeni oyunu ba�lat�r, ilk sahneyi y�kler
    public void StartNewGame()
    {
        SceneManager.LoadScene("SampleScene"); // Oyunun ba�lad��� sahneyi y�kle
    }

    // Oyundan ��kar
    public void ExitGame()
    {
        Application.Quit(); // Oyunu kapat
    }
}

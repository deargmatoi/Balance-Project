using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Yeni oyunu baþlatýr, ilk sahneyi yükler
    public void StartNewGame()
    {
        SceneManager.LoadScene("Hikaye"); // Oyunun baþladýðý sahneyi yükle
    }

    // Oyundan çýkar
    public void ExitGame()
    {
        Application.Quit(); // Oyunu kapat
    }
}

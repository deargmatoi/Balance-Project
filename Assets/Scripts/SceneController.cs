using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private string previousScene;  // �nceki sahneyi saklamak i�in bir de�i�ken

    // Sahneye ge�i� fonksiyonu
    public void LoadNewScene(string sceneName)
    {
        previousScene = SceneManager.GetActiveScene().name;  // Ge�erli sahneyi sakla
        SceneManager.LoadScene(sceneName);  // Yeni sahneye ge�i� yap
    }

    void Update()
    {
        // ESC tu�una bas�ld���nda �nceki sahneye d�n
        if (Input.GetKeyDown(KeyCode.Escape) && !string.IsNullOrEmpty("UI"))
        {
            SceneManager.LoadScene("UI");  // �nceki sahneye ge�i� yap
        }
    }
}

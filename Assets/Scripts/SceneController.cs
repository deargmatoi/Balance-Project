using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private string previousScene;  // Önceki sahneyi saklamak için bir deðiþken

    // Sahneye geçiþ fonksiyonu
    public void LoadNewScene(string sceneName)
    {
        previousScene = SceneManager.GetActiveScene().name;  // Geçerli sahneyi sakla
        SceneManager.LoadScene(sceneName);  // Yeni sahneye geçiþ yap
    }

    void Update()
    {
        // ESC tuþuna basýldýðýnda önceki sahneye dön
        if (Input.GetKeyDown(KeyCode.Escape) && !string.IsNullOrEmpty("UI"))
        {
            SceneManager.LoadScene("UI");  // Önceki sahneye geçiþ yap
        }
    }
}

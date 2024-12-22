using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;  // Singleton �rne�i

    public AudioSource backgroundMusic;  // Arka plan m�zi�i i�in AudioSource

    void Awake()
    {
        // Ayn� m�zik y�neticisinin ba�ka bir �rne�i varsa, bu nesneyi sil
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Bu nesneyi sahneler aras�nda ta��
        }
    }

    void Start()
    {
        // M�zik ba�lamal�ysa, burada ba�lat�l�r.
        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource; // Music Source – plays background music for the menu or gameplay.
    public AudioSource sfxSource;  // SFX Source – plays the sound effect: the paddle hit.

    /*
     Having separate sources allows music to continue while SFX play simultaneously,
     without interrupting each other
     */

    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip paddleHitSFX;

    void Awake()
    {
        // Singleton - singleton pattern, ensures one global AudioManager.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // keeps music and settings across scenes.
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
            PlayMenuMusic();
        else if (scene.name == "PongGame")
            PlayGameMusic();
    }

    // MainMenu scene
    public void PlayMenuMusic()
    {
        musicSource.clip = menuMusic;  // file menuMusic
        musicSource.loop = true; // just in case
        musicSource.Play();
    }

    // GamePong scene
    public void PlayGameMusic()
    {
        musicSource.clip = gameMusic; // file gameMusic
        musicSource.loop = true;   // just in case
        musicSource.Play();
    }

    // Paddle hit sound
    public void PlayPaddleHit()
    {
        sfxSource.PlayOneShot(paddleHitSFX);
    }

}

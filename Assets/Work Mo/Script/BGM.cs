using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bgmStage1;
    public AudioClip bgmStage2;
    public AudioClip bgmStage3;

    private string currentSceneName;

    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        PlayBGM(currentSceneName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string newSceneName = scene.name;

        if (newSceneName != currentSceneName)
        {
            currentSceneName = newSceneName;
            PlayBGM(currentSceneName);
        }
    }

    private void PlayBGM(string sceneName)
    {
        switch (sceneName)
        {
            case "Stage1":
                audioSource.clip = bgmStage1;
                break;
            case "Stage2":
                audioSource.clip = bgmStage2;
                break;
            case "Stage3":
                audioSource.clip = bgmStage3;
                break;
            default:
                audioSource.clip = null;
                break;
        }

        if (audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}

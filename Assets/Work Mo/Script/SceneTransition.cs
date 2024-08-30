using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void LoadNextStage(string stageName)
    {
        SceneManager.LoadScene(stageName);
    }
}

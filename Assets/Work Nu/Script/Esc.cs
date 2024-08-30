using UnityEngine;
using UnityEngine.SceneManagement;

public class Esc : MonoBehaviour
{
    private string scene = "TitleScene";
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            SceneManager.LoadScene(scene);
        }
    }
}

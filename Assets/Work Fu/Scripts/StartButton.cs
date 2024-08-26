using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // 次に遷移するシーンの名前
    public string nextSceneName;

    // スタートボタンが押されたときに呼ばれる
    public void OnStartButtonPressed()
    {
        // 次のシーンに遷移
        SceneManager.LoadScene(nextSceneName);
    }
}

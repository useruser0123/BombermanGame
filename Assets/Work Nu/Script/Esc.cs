using UnityEngine;
using UnityEngine.SceneManagement;

public class Esc : MonoBehaviour
{
    // 遷移先のシーン名を指定
    private string scene = "TitleScene";

    void Update()
    {
        // エスケープキーが押されたかをチェック
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // シーンをロード
            SceneManager.LoadScene(scene);
        }
    }
}

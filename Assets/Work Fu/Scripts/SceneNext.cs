using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNext : MonoBehaviour
{
    // 次に遷移するシーンの名前
    public string Stage2;

    // プレイヤーがドアに触れたときに呼ばれる
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 触れたオブジェクトがプレイヤーか確認
        if (other.CompareTag("Player"))
        {
            // 次のシーンに遷移
            SceneManager.LoadScene(Stage2);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public enum Estage { Stage1, Stage2, Stage3 }
public class StageManager : MonoBehaviour
{
    private int enemyCount;
    public Estage stage;

    private void Start()
    {
        // シーン内のすべての "Enemy" タグの付いたオブジェクトを数える
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // 敵が倒されたときに呼び出されるメソッド
    public void OnEnemyDefeated()
    {
        enemyCount--;

        // すべての敵が倒されたらクリアシーンに移動
        if (enemyCount <= 0)
        {
            LoadClearScene();
        }
    }

    // クリアシーンに移動するメソッド
    private void LoadClearScene()
    {
        switch (stage)
        {
            case Estage.Stage3:
                SceneManager.LoadScene("ClearScene"); // "ClearScene"はクリア画面のシーン名
                break;
        }

    }
}
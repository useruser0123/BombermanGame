using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    // ���ɑJ�ڂ���V�[���̖��O
    public string Stage2;

    // �v���C���[���h�A�ɐG�ꂽ�Ƃ��ɌĂ΂��
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �G�ꂽ�I�u�W�F�N�g���v���C���[���m�F
        if (other.CompareTag("Player"))
        {
            // ���̃V�[���ɑJ��
            SceneManager.LoadScene(Stage2);
        }
    }
}

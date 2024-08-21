using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f; // 移動速度
    public float moveDistance = 3f; // 移動する距離
    private bool movingRight = true; // 移動方向のフラグ
    private Vector2 initialPosition; // 初期位置

    void Start()
    {
        // 初期位置を保存
        initialPosition = transform.position;
    }

    void Update()
    {
        // 現在位置を取得
        Vector2 currentPosition = transform.position;

        // 移動方向に応じて位置を更新
        if (movingRight)
        {
            transform.position = new Vector2(currentPosition.x + moveSpeed * Time.deltaTime, currentPosition.y);

            // 移動距離を超えたら方向転換
            if (transform.position.x >= initialPosition.x + moveDistance)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.position = new Vector2(currentPosition.x - moveSpeed * Time.deltaTime, currentPosition.y);

            // 移動距離を超えたら方向転換
            if (transform.position.x <= initialPosition.x - moveDistance)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    // 敵の向きを反転させる関数
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Explosionレイヤーのオブジェクトに衝突した際の処理
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突したオブジェクトがExplosionレイヤーに属しているか確認
        if (collision.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            // 敵オブジェクトを削除
            Destroy(gameObject);
        }
    }
}

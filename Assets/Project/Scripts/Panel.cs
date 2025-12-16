using UnityEngine;

public class Panel : MonoBehaviour
{
    public int x, y;
    private bool isHit = false;
    private Renderer rend;
    private GameManager gameManager;
    private Rigidbody rb;

    void Start()
    {
        rend = GetComponent<Renderer>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;  // 初期状態では動かない
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (!isHit && collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("collision");
            isHit = true;
            rend.material.color = Color.red;
            gameManager.RegisterHit(x, y);

            rb.isKinematic = false;  // 動作を有効化
            Vector3 forceDir = transform.forward * -1f + Vector3.up * 0.5f;  // 後方＆少し上向き
            rb.AddForce(forceDir.normalized * 300f);  // ふっとばす力（調整可）
        }
    }
}

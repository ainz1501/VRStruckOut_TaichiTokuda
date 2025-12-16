using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;     // 投げるボールのプレハブ
    public float shootForce = 80f;   // 射出の強さ
    public Transform shootPoint;      // 射出位置（通常はカメラ前）

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Shoooooot!!");
            ShootBall();
        }
    }

    void ShootBall()
    {
        GameObject ball = Instantiate(ballPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(shootPoint.forward * shootForce);
    }
}

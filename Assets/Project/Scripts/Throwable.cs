using UnityEngine;
using Valve.VR;

public class Throwable : MonoBehaviour
{
    private Rigidbody rb;
    private bool isHeld = false;
    private Transform attachPoint;
    private Vector3 lastVelocity;
    private Vector3 lastAngularVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isHeld && attachPoint != null)
        {
            // 手の速度を記録
            var pose = attachPoint.GetComponent<SteamVR_Behaviour_Pose>();
            if (pose != null)
            {
                lastVelocity = pose.GetVelocity();
                lastAngularVelocity = pose.GetAngularVelocity();
            }
        }
    }

    public void PickUp(Transform hand)
    {
        isHeld = true;
        attachPoint = hand;
        rb.isKinematic = true;
        transform.SetParent(hand); // 手の Transform を親にする
        transform.localPosition = new Vector3(-0.0f, 0.0f, -0.1f);; // 位置をリセット（＝手の中心）
        transform.localRotation = Quaternion.identity; // 回転もリセット（＝手と同じ向き）
    }

    public void Helding()
    {
        isHeld = true;
    }

    public void Release()
    {
        isHeld = false;
        transform.SetParent(null);
        rb.isKinematic = false;
        // rb.velocity = lastVelocity;
        rb.velocity = new Vector3(0.0f, 1.0f, 30.0f);
        rb.angularVelocity = lastAngularVelocity;
        attachPoint = null;
    }

    public bool IsHeld => isHeld;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    // is Trigerにチェックを入れたときのみ有効な衝突判定
    //　物体があたらずにすり抜ける（当たり判定だけをとることができる）
    // void OnTriggerEnter(Collider other)
    // {
    //     Debug.Log("あたった！");
    // }

    void OnCollisionEnter(Collision collision) // 物体がちゃんと当たる衝突判定
    {
        Debug.Log("当たった！");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    //キューブに効果音を再生させる
    private AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        // AudioSourceからのコンポーネントを取得
        AudioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //衝突したオブジェクトにCube Tagがある時のみ効果音を出す
        if (collision.gameObject.CompareTag("Cube Tag")|| collision.gameObject.CompareTag("ground Tag"))
        {
            // 衝突時に効果音を再生
            AudioSource.Play();
        }
        
     }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }
}

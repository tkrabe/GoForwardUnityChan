using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる（アニメーション）
    Animator animator;

    //Unityちゃんを移動させるコンポーネントを入れる（ジャンプさせる）
    Rigidbody2D rigid2D;

    // 地面の位置（アニメーション）
    private float groundLevel = -3.0f;

    // ジャンプの速度の減衰（ジャンプさせる）
    private float dump = 0.8f;

    // ジャンプの速度（ジャンプさせる）
    float jumpVelocity = 20;

    // Start is called before the first frame update
    void Start()
    {
        // アニメータのコンポーネントを取得する（アニメーション）
        this.animator = GetComponent<Animator>();

        // Rigidbody2Dのコンポーネントを取得する（ジャンプさせる）
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 走るアニメーションを再生するために、Animatorのパラメータを調節する（アニメーション）
        this.animator.SetFloat("Horizontal", 1);

        // 着地しているかどうかを調べる（アニメーション）
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        // 着地状態でクリックされた場合（ジャンプさせる）//Input.GetMouseButtonDown(0)この文がマウスの左クリックされた瞬間に真実（true）か判定している
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            // 上方向の力をかける（ジャンプさせる）
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        // クリックをやめたら上方向への速度を減速する（ジャンプさせる）
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }
    }
}

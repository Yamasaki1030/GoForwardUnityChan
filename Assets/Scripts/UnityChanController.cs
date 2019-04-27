using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

    Animator animator;
    Rigidbody2D rigid2D;

    // 地面の位置
    private float groundLevel = -3.0f;
    // ジャンプ速度の減衰・ジャンプの速度
    private float dump = 0.8f;
    float jumpVelocity = 20;
    // ゲームオーバーになる位置
    private float deadLine = -9;

	// Use this for initialization
	void Start () {
        // アニメータのコンポーネントを取得
        this.animator = GetComponent<Animator>();

        this.rigid2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        // 走るアニメーションを再生
        this.animator.SetFloat("Horizontal", 1);

        // 着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        // ジャンプ状態では足音を消す
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        // 着地状態でクリック
        if(Input.GetMouseButtonDown(0) && isGround)
        {
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }
        // クリックをやめたら落下
        if(Input.GetMouseButton(0) == false)
        {
            if(this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        // ゲームオーバー位置
        if(transform.position.x < this.deadLine)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            Destroy(gameObject);
        }

	}
}

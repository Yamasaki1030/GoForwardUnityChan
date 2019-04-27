using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    // テキスト
    private GameObject gameOverText;
    private GameObject runLengthText;
    // 走行距離
    private float len = 0;
    // 速度
    private float speed = 0.03f;
    // ゲームオーバーの判定
    private bool isGameOver = false;

	// Use this for initialization
	void Start () {
        // シーンビューからオブジェクトを検索
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
	}
	
	// Update is called once per frame
	void Update () {
		if(this.isGameOver == false)
        {
            // 走行距離の更新と表示
            this.len += this.speed;
            this.runLengthText.GetComponent<Text>().text = "Distance: " + len.ToString("F2") + "m";
        }

        // ゲームオーバーになった場合
        if(this.isGameOver == true)
        {
            // クリックされたらシーンをロードする
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
	}

    public void GameOver()
    {
        // ゲームオーバーを表示
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        this.isGameOver = true;
    }
}

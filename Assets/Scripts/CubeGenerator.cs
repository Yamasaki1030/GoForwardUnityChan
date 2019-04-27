using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

    public GameObject cubePrefab;
    // キューブの生成間隔
    private float span = 1.0f;
    // 時間計測用
    private float delta = 0;

    // 生成位置：X座標
    private float genPosX = 12;
    // キューブの生成位置オフセット
    private float offsetX = 0.5f;
    private float offsetY = 0.3f;
    // キューブの縦方向の間隔
    private float spaceX = 0.4f;
    private float spaceY = 6.9f;
    // 生成個数の上限
    private int maxBlockNum = 4;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;

        // span秒以上の時間が経過した場合
        if(this.delta > this.span)
        {
            this.delta = 0;
            // キューブの数
            int n = Random.Range(1, maxBlockNum + 1);

            // 指定した数だけキューブを生成
            for(int i = 0; i < n; i++)
            {
                GameObject go = Instantiate(cubePrefab) as GameObject;
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
            }
            // 次のキューブまでの生成時間
            this.span = this.offsetX + this.spaceX * n;
        }
	}
}

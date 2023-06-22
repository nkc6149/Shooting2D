using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject ExplPre;
    public GameObject ShotPre;
    float speed;
    Vector3 dir;
    int enemyType;
    float rad;
    float shotTime;
    float shotInterval = 2f;
    GameDirector gd;

    void Start()
    {
        Destroy(gameObject, 6);            //寿命
        enemyType = Random.Range(0, 3);    //敵の種類
        speed = 5;                         //移動速度
        dir = Vector3.left;                //移動方向
        rad = Time.time;                   //サインカーブの動きをずらす用
        shotTime = 0;                      //発射間隔計算用
       
        //GameDirectorコンポーネントを保存
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyType == 2)
        {
            //移動方向
            dir.y = Mathf.Sin(rad + Time.time * 5f);
        }
        //移動方法
        transform.position += dir.normalized * speed * Time.deltaTime;

        //敵の弾の生成
        if (shotTime > shotInterval)
        {
            shotTime = 0;
            Instantiate(ShotPre,transform.position,transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerShot")
        { 
        gd.Kyori
        }

        //制限時間を10秒減らす
        GameDirector.lastTime -= 10f;

        //何か他のオブジェクトと重なったら消去
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPre;

    Vector3 dir; //移動方向を保存する変数
    float speed;
    float timer;
    Animator anim;

    void Start()
    {
        //アニメーターコンポーネントの情報を保存
        anim = GetComponent<Animator>();
        bulletLevel = 0;
        timer = 0;
        speed = 10;
    }

    void Update()
    {
        //移動方向をリセット
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.C))
        {
            bulletLevel = (bulletLevel + 1) % 13;
        }

        timer += Time.deltaTime;
        if (timer >= 0.3f && Input.GetKey(KeyCode.Z))
        {
            timer = 0;
            bulletLevel = (bulletLevel < 0) ? 0 : bulletLevel;
            for (int i = -bulletLevel; i < bulletLevel + 1; i++)
            { 
               Vector3 p = transform.position;
            
               Quaternion rot = Quaternion.identity;
               rot.eulerAngles = transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);

                Instantiate(bulletPre, p, rot);  
            }
        
        }

        //画面内移動制限
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;

        //アニメーション設定
        if (dir.y == 0)
        {
            //アニメーションクリップ[Player]を再生
            anim.Play("Player");
        }
        else if (dir.y == 1)
        {
            anim.Play("PlayerL");
        }
        else if (dir.y == -1)
        {
            anim.Play("PlayerR");
        }
    }

    public float Speed
    {
        set
        {
            speed = value;
            speed = Mathf.Clamp(speed, 1, 20);
        }
        get { return speed; }
    }

    int bulletLevel;
    public int BulletLevel
    {
        set
        {
            bulletLevel = value;
            bulletLevel = Mathf.Clamp(bulletLevel, 0, 12);
        }
       get{ return bulletLevel; }
    }
}

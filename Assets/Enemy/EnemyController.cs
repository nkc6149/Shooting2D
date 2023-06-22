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
        Destroy(gameObject, 6);            //����
        enemyType = Random.Range(0, 3);    //�G�̎��
        speed = 5;                         //�ړ����x
        dir = Vector3.left;                //�ړ�����
        rad = Time.time;                   //�T�C���J�[�u�̓��������炷�p
        shotTime = 0;                      //���ˊԊu�v�Z�p
       
        //GameDirector�R���|�[�l���g��ۑ�
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyType == 2)
        {
            //�ړ�����
            dir.y = Mathf.Sin(rad + Time.time * 5f);
        }
        //�ړ����@
        transform.position += dir.normalized * speed * Time.deltaTime;

        //�G�̒e�̐���
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

        //�������Ԃ�10�b���炷
        GameDirector.lastTime -= 10f;

        //�������̃I�u�W�F�N�g�Əd�Ȃ��������
        Destroy(gameObject);
    }

}

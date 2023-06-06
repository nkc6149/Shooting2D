using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
                float speed = 5;

        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * speed * Time.deltaTime;

        //��ʓ��ړ�����
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f); //Mathf.Clamp�͈�ڂ̒l���Q�ڂ̒l�ȉ��ɂȂ�Ȃ��悤��
        pos.y = Mathf.Clamp(pos.y, -5f, 5f); //�܂��A�R�ڂ̒l�ȏ�ɂȂ�Ȃ��悤�ɐݒ肵�Ă���鎮�ł���
        transform.position = pos;
    }
}

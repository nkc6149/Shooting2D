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

        //画面内移動制限
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f); //Mathf.Clampは一つ目の値が２つ目の値以下にならないように
        pos.y = Mathf.Clamp(pos.y, -5f, 5f); //また、３つ目の値以上にならないように設定してくれる式である
        transform.position = pos;
    }
}

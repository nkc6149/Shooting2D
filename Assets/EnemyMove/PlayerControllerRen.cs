using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRen : MonoBehaviour
{

    Vector3 dir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
    }
}

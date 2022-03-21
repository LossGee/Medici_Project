using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 총알이 계속 위로 이동하고 싶다 
// 1. 방향 구하기
// 2. 이동하기
public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 방향 구하기
        Vector3 dir = Vector3.up;

        // 2. 이동하기 
        transform.position += dir * speed * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        i += 1;     // 복합할당연산자
        // 이동공식
        // P = P0 + vt (P += vt)
        // P0: 이전 위치
        // v: 속도 (velocity)
        // t: 시간 (tiem)
        // 현재 위치 = 이전 위치 +  (Vector * 속도 * 시간)
        // transform.position = transform.position + Vector3.left * 5 * Time.deltaTime;     // 공식 적용
        transform.position += Vector3.left * speed * Time.deltaTime;        // 줄여쓰기
        

    }
}

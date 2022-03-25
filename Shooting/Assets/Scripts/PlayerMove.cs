using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자의 입력에 따라 플레이어를 이동시키고 싶다.
// 1. 사용자의 입력처리 (입력을 컴퓨터에 먹인다)
// 2. 방향 만들기 (입력값을 사용하여 이동식 완성)
// 3. 플레이어 이동시키기 (Player를 이동시킨다.)
public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        // 1. 사용자의 입력 처리
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        // 2. 방향[dir] 만들기 
        //Vector3 dir = Vector3.right * h + Vector3.up * v;     // 수식으로 이해하기 
        
        Vector3 dir = new Vector3(h, v, 0);                     // 벡터의 성분으로 넣어 연산 줄이기
        dir.Normalize();
        //print("Magnitude: " + dir.magnitude);

        // 3. 플레이어 이동시키기 + 이동 제한 걸기
        //transform.Translate(dir * speed * Time.deltaTime);    // transform.Translate()  함수 이용
        //transform.position = transform.position + dir * speed * Time.deltaTime;     // P = P0 + vt 수식 적용
        //transform.position += dir * speed * Time.deltaTime;     // 단축된 식

        //+ 이동 범위 제한기능 추가: Mathf.Clamp() 활용
        Vector3 currentPos = transform.position;
        currentPos += dir * speed * Time.deltaTime;
        currentPos.x = Mathf.Clamp(currentPos.x, -3f, 3f);
        currentPos.y = Mathf.Clamp(currentPos.y, -5f, 5f);

        transform.position = currentPos;
         
    }
}

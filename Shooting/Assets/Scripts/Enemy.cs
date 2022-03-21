using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
[proto]
step1 : 아래로 계속 이동하고 싶다. 
    1. 방향 구하기
    2. 이동하기 

step2 : Enemy가 어떤 물체와 충돌하면 둘 다 파괴하고 싶다. 
    
step3 : 30% 확률로 플레이어 방향, 나머지 확률로 아래방향으로 정하고 싶다.
        = 0부터 9까지 10개의 값 중에 하나를 랜덤으로 가져온다. 
          만약, 그 값이 3보다 작으면 플레이어 방향으로,
          그렇지 않으면, 아래 방향으로 이동한다. 
    1. 30% 확률로 플레이어 방향, 나머지 확률로 아래 방향
    2. 태어날 때 방향을 정하고 그 방향으로 계속 이동


[alpha]
 - 목표: 적이 다른 물체와 충돌했을 때 폭발효과를 발생시키고 싶다. 
 - 순서: 1. 적이 다른 물체와 충돌했으니까
         2. 폭발 효과 공장에서 폭발효과를 하나 만들어야 한다. 
         3. 폭발 효과를 발생(위치)시키고 싶다. 
 - 필요속성: 폭발 공장 주소(외부에서 값을 넣어준다)
 */

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 dir;
    public GameObject explosionFactory; 

    // Start is called before the first frame update
    void Start()
    {
        // 0~9까지 1개의 값을 랜덤으로 가져온다. 
        int randValue = UnityEngine.Random.Range(0, 9);

        // 만약, 그 값이 3보다 작으면 플레이어의 방향으로 설정
        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");          // target 찾기
            if (target != null)
            { 
                dir = target.transform.position - transform.position;   // 추적: target - 내위치벡터
                dir.Normalize();
            }
            else
                dir = Vector3.down;
        }
        // 그렇지 않으면 아래 방향으로 설정
        else 
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // step1 : 아래로 계속 이동하고 싶다. 
        // 1. 방향 구하기
        //Vector3 dir = Vector3.down;       // dir을 필드로 사용
        //print("Magnitude of dir: " + dir.magnitude);

        // 2. 이동하기 
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 폭발 공장에서 폭발을 하나 생산한다. 
        GameObject explosion = Instantiate(explosionFactory);
        // 폭발 효과를 발생(위치)시키고 싶다. 
        explosion.transform.position = transform.position;

        // 너 죽고
        Destroy(collision.gameObject);
        // 나 죽자
        Destroy(gameObject);

        //
    }
    
}

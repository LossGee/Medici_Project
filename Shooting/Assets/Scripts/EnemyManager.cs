using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
step1) 일정 시간마다 적을 생성해 내 위치에 갖다 놓고 싶다. 
    1. 시간이 흐르다가
    2. 만약, 현재시간이 일정 시간이 되면
    3. 적 공장에서 적을 생성해 내 위치에 갖다 놓고 싶다.(+현재시간 초기화)
step2) 적이 생성될 때마다 다음 생성시간을 랜덤하게 바꾸고 싶다. 
    1. 태어날때, 적의 생성시간을 설정하고
    2. 적을 생성한 후 생성시간을 다시 설정하고 싶다. 
*/
public class EnemyManager : MonoBehaviour
{
    public float minTime = 0.5f;        // 적 생성 최소시간
    public float maxTime = 2.0f;        // 적 생성 최대시간
    public float createTime = 1.0f;     // 일정시간 
    float currentTime = 0f;
    public GameObject enemyFactory;     // 적 공장 


    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때, 적의 시간을 설정하고 
        createTime = UnityEngine.Random.Range(minTime, maxTime);    // 일정시간(랜덤하게 설정)
    }

    // Update is called once per frame
    void Update()
    {
        // 1.시간이 흐르다가
        currentTime += Time.deltaTime;

        // 2.만약, 현재시간이 일정 시간이 되면
        if(currentTime > createTime)
        {
            // 3.적 공장에서 적을 생성해 
            GameObject enemy = Instantiate(enemyFactory);
            // 내 위치에 갖다 놓고 싶다.
            enemy.transform.position = transform.position;
            // 현재시간 초기화
            currentTime = 0.0f;

            // 적을 생성한 후 다시 생성시간을 다시 설정하고 싶다. 
            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }



    }
}

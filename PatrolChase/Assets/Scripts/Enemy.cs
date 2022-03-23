using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// agent를 이용해서 길찾기를 하고싶다. 
// 순찰, 추적 상태로 제어하고싶다. 
// 
public class Enemy : MonoBehaviour
{
    public enum State
    {
        PATROL,     //순찰
        CHASE       //추적
    }
    public State state;     // 이걸 public으로 설정할거면 enum State 선언해준것도 public해 줘야함.

    NavMeshAgent agent;
    int targetIndex;        // 목적지 인덱스 번호 


    // Start is called before the first frame update
    void Start()
    {
        state = State.PATROL;
        agent = GetComponent<NavMeshAgent>();
        targetIndex = 0;
    }

    // Update is called once per frame
    void Update()
    { 
        switch (state)
        {
            case State.PATROL: UpdatePatrol(); break;
            case State.CHASE: UpdateChase(); break;
        }

    }

    public float chaseDistance = 15f;
    private void UpdateChase()
    {
        agent.destination = chaseTarget.transform.position;

        float dist = Vector3.Distance(chaseTarget.transform.position, transform.position);        //chaseTarget과의 거리 구하기
        
        // 만약, chaseTarget과의 거리가 추적 범위를 벗어나면
        if(dist > chaseDistance)
            // 순찰상태로 전이하고 싶다. 
            state = State.PATROL;
    }

    public float detectedRadius = 5;
    GameObject chaseTarget;
    private void UpdatePatrol()
    {
        // 반경 5m안에 Plyer가 있다면
        Collider[] cols = Physics.OverlapSphere(transform.position, detectedRadius);
        for (int i = 0 ; i<cols.Length ; i++)
        {
            if (cols[i].name.Contains("Player"))
            {
                // 추적상태로 전이하고 싶다. 
                state = State.CHASE;
                chaseTarget = cols[i].gameObject;
                return;
            }
        }

        Vector3 target = PathInfo.Instance.wayPoints[targetIndex].transform.position;

        // 길을 순환이동 하고 싶다.
        agent.destination = target;

        //[순방향]
        // 만약 도착했다면? 도착기준: 거리
        float dist = Vector3.Distance(target, transform.position);
        if (dist <= 1)      // 1이라는 거리는 상황에 맞게 값을 정해야한다. 
        {
            // 인덱스 번호 1증가 
            targetIndex++;

            // 만약 targetIndex가 PathInfo.instance.wayPoints배열 크기 이상이라면
            if (targetIndex >= PathInfo.Instance.wayPoints.Length)
            {
                targetIndex = 0;    //0으로 초기화
            }
        }
        //targetIndex = (targetIndex + 1) % PathInfo.Instance.wayPoints.Length;       // 줄여서 표현하기 


        // [역방향]
        /*if (dist <= 1)      // 1이라는 거리는 상황에 맞게 값을 정해야한다. 
        {
            // 인덱스 번호 1감소
            targetIndex--;
            // 만약 targetIndex가 0보다 배열 크기 미만
            if (targetIndex < 0)
            {
                targetIndex = PathInfo.Instance.wayPoints.Length - 1;    //0으로 초기화
            }
        }*/
        //targetIndex = (targetIndex +PathInfo.Instance.wayPoints.Length) % PathInfo.Instance.wayPoints.Length;       // 줄여서 표현하기

    }
 

    
}

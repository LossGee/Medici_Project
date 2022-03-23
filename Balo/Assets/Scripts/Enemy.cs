using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
    step1) agent 기능을 이용해서 목적지를 향해서 이동하고 싶다
    step2) FSM : 목표검색(대기, search), 이동, 공격
     
 */
public class Enemy : MonoBehaviour
{
    // "열거형(enumaration)" 으로 state들 정의
    // SEARTCH = 100 이렇게 임의로 줄 수 있으며 그 뒤에 오는 변수들은 그 다음 숫자인 101이 옴
    enum State
    { 
        SEARCH,
        MOVE,
        ATTACK
    }

    // 현재 상태
    State state;

    NavMeshAgent agent;
    GameObject target;      // GameObject: Call by Reference
    public Animator anim;   // 애니메이터를 가져오기 위한 변수

    // Start is called before the first frame update
    void Start()
    {
        state = State.SEARCH;     // 초기 상태 지정
        agent = this.gameObject.GetComponent<NavMeshAgent>();       //this.gameObject 생략 가능
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // [FSM: (way1)if-else를 활용하여 구현]
        // 만약, 현재상태(state)가 목표검색(SEARCH)이라면 검색만 하고 싶다. 
        if (state == State.SEARCH)
        {
            UpdateSearch();
        }
        // 그렇지않고 상태가 이동이라면 이동만 하고싶다. 
        else if (state == State.MOVE)
        {
            UpdateMove();
        }
        // 그렇지않고 상태가 공격이라면 공격만 하고싶다. 
        else if (state == State.ATTACK)
        {
            UpdateAttack();
        }
        */

        // [FSM: (way2)switch-case문을 활용하여 구현] - 아래처럼 한 줄로 정리할 수 있다. 
        switch (state)
        {
            // 만약, 현재상태(state)가 목표검색(SEARCH)이라면 검색만 하고 싶다. 
            case State.SEARCH: UpdateSearch(); break;
            // 그렇지않고 상태가 이동이라면 이동만 하고싶다
            case State.MOVE: UpdateMove(); break;
            // 그렇지않고 상태가 공격이라면 공격만 하고싶다.
            case State.ATTACK: UpdateAttack();break;
        }
    }


    private void UpdateSearch()
    {
        // 목적지를 찾고 싶다.
        target = GameObject.Find("Player");
        // 만약 목적지를 찾았으면(target이 없으면 NULL이 반환된다는 것을 활용)
        if (target != null)
        {
            // 이동상태로 전이하고 싶다. 
            state = State.MOVE;
            anim.SetTrigger("Move");
        }
    }
    private void UpdateMove()
    {
        // agent에게 목적지를 알려주고 싶다. 
        agent.destination = target.transform.position;      // .destination은 Vector3(structure이므로 Call by Value, Start에 있을 경우 처음 지점으로만 이동. 따라오기 X)
        
        // 만약 목적지와의 거리가 공격가능 거리라면?
        // == (목적지와의 거리가 <= 공격가능거리)
        float distance = Vector3.Distance(target.transform.position, transform.position);       // 두 벡터 사이의 거리 
        if (distance <= agent.stoppingDistance)
        {
            // 공격상태로 전이하고 싶다. 
            state = State.ATTACK;
            anim.SetTrigger("Attack");         
        }

    }

    private void UpdateAttack()
    {
        // 만약 목적지와의 거리가 공격가능 거리가 아니라면?
        // 이동상태로 전이하고싶다.
    }
    internal void OnEnemyAttackHit()        // internal: 같은 프로세스에서는 public을 다른 프로세스에서는 private로 사용되는 접근제한자
    {
        //print("OnEnemyAttackHit");
        // 만약 공격가능 거리라면  Hit를 하고 싶다. 
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance <= agent.stoppingDistance)
        {
            //print("Hit!!!!!");
            HitManager.Instance.DoHitPlz();     // 싱글톤으로 만든 HitManager에서 만든 코루틴함수가 포함된 DoHitPlz 함수 호출
        }
    }

    internal void OnEnemyAttackFinished()
    {
        //print("OnEnemyAttackFinished");
        // 만약 공격가능거리가 아니라면
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > agent.stoppingDistance)
        {
            // 이동 상태로 전이하고 싶다.
            state = State.MOVE;
            anim.SetTrigger("Move");
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
    step1) agent ����� �̿��ؼ� �������� ���ؼ� �̵��ϰ� �ʹ�
    step2) FSM : ��ǥ�˻�(���, search), �̵�, ����
     
 */
public class Enemy : MonoBehaviour
{
    // "������(enumaration)" ���� state�� ����
    // SEARTCH = 100 �̷��� ���Ƿ� �� �� ������ �� �ڿ� ���� �������� �� ���� ������ 101�� ��
    enum State
    { 
        SEARCH,
        MOVE,
        ATTACK
    }

    // ���� ����
    State state;

    NavMeshAgent agent;
    GameObject target;      // GameObject: Call by Reference
    public Animator anim;   // �ִϸ����͸� �������� ���� ����

    // Start is called before the first frame update
    void Start()
    {
        state = State.SEARCH;     // �ʱ� ���� ����
        agent = this.gameObject.GetComponent<NavMeshAgent>();       //this.gameObject ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // [FSM: (way1)if-else�� Ȱ���Ͽ� ����]
        // ����, �������(state)�� ��ǥ�˻�(SEARCH)�̶�� �˻��� �ϰ� �ʹ�. 
        if (state == State.SEARCH)
        {
            UpdateSearch();
        }
        // �׷����ʰ� ���°� �̵��̶�� �̵��� �ϰ�ʹ�. 
        else if (state == State.MOVE)
        {
            UpdateMove();
        }
        // �׷����ʰ� ���°� �����̶�� ���ݸ� �ϰ�ʹ�. 
        else if (state == State.ATTACK)
        {
            UpdateAttack();
        }
        */

        // [FSM: (way2)switch-case���� Ȱ���Ͽ� ����] - �Ʒ�ó�� �� �ٷ� ������ �� �ִ�. 
        switch (state)
        {
            // ����, �������(state)�� ��ǥ�˻�(SEARCH)�̶�� �˻��� �ϰ� �ʹ�. 
            case State.SEARCH: UpdateSearch(); break;
            // �׷����ʰ� ���°� �̵��̶�� �̵��� �ϰ�ʹ�
            case State.MOVE: UpdateMove(); break;
            // �׷����ʰ� ���°� �����̶�� ���ݸ� �ϰ�ʹ�.
            case State.ATTACK: UpdateAttack();break;
        }
    }


    private void UpdateSearch()
    {
        // �������� ã�� �ʹ�.
        target = GameObject.Find("Player");
        // ���� �������� ã������(target�� ������ NULL�� ��ȯ�ȴٴ� ���� Ȱ��)
        if (target != null)
        {
            // �̵����·� �����ϰ� �ʹ�. 
            state = State.MOVE;
            anim.SetTrigger("Move");
        }
    }
    private void UpdateMove()
    {
        // agent���� �������� �˷��ְ� �ʹ�. 
        agent.destination = target.transform.position;      // .destination�� Vector3(structure�̹Ƿ� Call by Value, Start�� ���� ��� ó�� �������θ� �̵�. ������� X)
        
        // ���� ���������� �Ÿ��� ���ݰ��� �Ÿ����?
        // == (���������� �Ÿ��� <= ���ݰ��ɰŸ�)
        float distance = Vector3.Distance(target.transform.position, transform.position);       // �� ���� ������ �Ÿ� 
        if (distance <= agent.stoppingDistance)
        {
            // ���ݻ��·� �����ϰ� �ʹ�. 
            state = State.ATTACK;
            anim.SetTrigger("Attack");         
        }

    }

    private void UpdateAttack()
    {
        // ���� ���������� �Ÿ��� ���ݰ��� �Ÿ��� �ƴ϶��?
        // �̵����·� �����ϰ�ʹ�.
    }
    internal void OnEnemyAttackHit()        // internal: ���� ���μ��������� public�� �ٸ� ���μ��������� private�� ���Ǵ� ����������
    {
        //print("OnEnemyAttackHit");
        // ���� ���ݰ��� �Ÿ����  Hit�� �ϰ� �ʹ�. 
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance <= agent.stoppingDistance)
        {
            //print("Hit!!!!!");
            HitManager.Instance.DoHitPlz();     // �̱������� ���� HitManager���� ���� �ڷ�ƾ�Լ��� ���Ե� DoHitPlz �Լ� ȣ��
        }
    }

    internal void OnEnemyAttackFinished()
    {
        //print("OnEnemyAttackFinished");
        // ���� ���ݰ��ɰŸ��� �ƴ϶��
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > agent.stoppingDistance)
        {
            // �̵� ���·� �����ϰ� �ʹ�.
            state = State.MOVE;
            anim.SetTrigger("Move");
        }
    }
}

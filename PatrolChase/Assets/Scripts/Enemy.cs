using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// agent�� �̿��ؼ� ��ã�⸦ �ϰ�ʹ�. 
// ����, ���� ���·� �����ϰ�ʹ�. 
// 
public class Enemy : MonoBehaviour
{
    public enum State
    {
        PATROL,     //����
        CHASE       //����
    }
    public State state;     // �̰� public���� �����ҰŸ� enum State �������ذ͵� public�� �����.

    NavMeshAgent agent;
    int targetIndex;        // ������ �ε��� ��ȣ 


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

        float dist = Vector3.Distance(chaseTarget.transform.position, transform.position);        //chaseTarget���� �Ÿ� ���ϱ�
        
        // ����, chaseTarget���� �Ÿ��� ���� ������ �����
        if(dist > chaseDistance)
            // �������·� �����ϰ� �ʹ�. 
            state = State.PATROL;
    }

    public float detectedRadius = 5;
    GameObject chaseTarget;
    private void UpdatePatrol()
    {
        // �ݰ� 5m�ȿ� Plyer�� �ִٸ�
        Collider[] cols = Physics.OverlapSphere(transform.position, detectedRadius);
        for (int i = 0 ; i<cols.Length ; i++)
        {
            if (cols[i].name.Contains("Player"))
            {
                // �������·� �����ϰ� �ʹ�. 
                state = State.CHASE;
                chaseTarget = cols[i].gameObject;
                return;
            }
        }

        Vector3 target = PathInfo.Instance.wayPoints[targetIndex].transform.position;

        // ���� ��ȯ�̵� �ϰ� �ʹ�.
        agent.destination = target;

        //[������]
        // ���� �����ߴٸ�? ��������: �Ÿ�
        float dist = Vector3.Distance(target, transform.position);
        if (dist <= 1)      // 1�̶�� �Ÿ��� ��Ȳ�� �°� ���� ���ؾ��Ѵ�. 
        {
            // �ε��� ��ȣ 1���� 
            targetIndex++;

            // ���� targetIndex�� PathInfo.instance.wayPoints�迭 ũ�� �̻��̶��
            if (targetIndex >= PathInfo.Instance.wayPoints.Length)
            {
                targetIndex = 0;    //0���� �ʱ�ȭ
            }
        }
        //targetIndex = (targetIndex + 1) % PathInfo.Instance.wayPoints.Length;       // �ٿ��� ǥ���ϱ� 


        // [������]
        /*if (dist <= 1)      // 1�̶�� �Ÿ��� ��Ȳ�� �°� ���� ���ؾ��Ѵ�. 
        {
            // �ε��� ��ȣ 1����
            targetIndex--;
            // ���� targetIndex�� 0���� �迭 ũ�� �̸�
            if (targetIndex < 0)
            {
                targetIndex = PathInfo.Instance.wayPoints.Length - 1;    //0���� �ʱ�ȭ
            }
        }*/
        //targetIndex = (targetIndex +PathInfo.Instance.wayPoints.Length) % PathInfo.Instance.wayPoints.Length;       // �ٿ��� ǥ���ϱ�

    }
 

    
}

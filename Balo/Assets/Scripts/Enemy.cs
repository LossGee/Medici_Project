using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// agent ����� �̿��ؼ� �������� ���ؼ� �̵��ϰ� �ʹ�
public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject target;      // GameObject: Call by Reference
    // Start is called before the first frame update
    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();       //this.gameObject ���� ����
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //agent���� �������� �˷��ְ� �ʹ�. 
        agent.destination = target.transform.position;      // .destination�� Vector3(structure�̹Ƿ� Call by Value, Start�� ���� ��� ó�� �������θ� �̵�. ������� X)
    }
}

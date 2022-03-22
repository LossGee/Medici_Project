using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// agent 기능을 이용해서 목적지를 향해서 이동하고 싶다
public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject target;      // GameObject: Call by Reference
    // Start is called before the first frame update
    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();       //this.gameObject 생략 가능
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //agent에게 목적지를 알려주고 싶다. 
        agent.destination = target.transform.position;      // .destination은 Vector3(structure이므로 Call by Value, Start에 있을 경우 처음 지점으로만 이동. 따라오기 X)
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
step1 : �Ʒ��� ��� �̵��ϰ� �ʹ�. 
    1. ���� ���ϱ�
    2. �̵��ϱ� 

step2 : Enemy�� � ��ü�� �浹�ϸ� �� �� �ı��ϰ� �ʹ�. 
    
step3 : 30% Ȯ���� �÷��̾� ����, ������ Ȯ���� �Ʒ��������� ���ϰ� �ʹ�.
        = 0���� 9���� 10���� �� �߿� �ϳ��� �������� �����´�. 
          ����, �� ���� 3���� ������ �÷��̾� ��������,
          �׷��� ������, �Ʒ� �������� �̵��Ѵ�. 
    1. 30% Ȯ���� �÷��̾� ����, ������ Ȯ���� �Ʒ� ����
    2. �¾ �� ������ ���ϰ� �� �������� ��� �̵�
 */

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 dir;
    

    // Start is called before the first frame update
    void Start()
    {
        // 0~9���� 1���� ���� �������� �����´�. 
        int randValue = UnityEngine.Random.Range(0, 9);

        // ����, �� ���� 3���� ������ �÷��̾��� �������� ����
        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");          // target ã��
            if (target != null)
            { 
                dir = target.transform.position - transform.position;   // ����: target - ����ġ����
                dir.Normalize();
            }
            else
                dir = Vector3.down;
        }
        // �׷��� ������ �Ʒ� �������� ����
        else 
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // step1 : �Ʒ��� ��� �̵��ϰ� �ʹ�. 
        // 1. ���� ���ϱ�
        //Vector3 dir = Vector3.down;       // dir�� �ʵ�� ���
        //print("Magnitude of dir: " + dir.magnitude);

        // 2. �̵��ϱ� 
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        // �� �װ�
        Destroy(other.gameObject);
        // �� ����
        Destroy(gameObject);
    }
}

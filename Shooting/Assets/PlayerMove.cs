using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        i += 1;     // �����Ҵ翬����
        // �̵�����
        // P = P0 + vt (P += vt)
        // P0: ���� ��ġ
        // v: �ӵ� (velocity)
        // t: �ð� (tiem)
        // ���� ��ġ = ���� ��ġ +  (Vector * �ӵ� * �ð�)
        // transform.position = transform.position + Vector3.left * 5 * Time.deltaTime;     // ���� ����
        transform.position += Vector3.left * speed * Time.deltaTime;        // �ٿ�����
        

    }
}

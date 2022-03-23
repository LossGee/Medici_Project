using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���콺 ���� ��ư�� ������
// ����ī�޶� �ٶ󺻰��� �Ѿ� �ڱ��� ����� �ʹ�. 
// 1. ������� ���콺 ���� ��ư �Է¹ޱ�
// 2. Ray�� �����ϰ� '�߻�� ��ġ'�� '�������' ����
// 3. "Ray�� �ε��� ����� ������ ������ ����" �����ϱ� 
// 4. "Ray�� �߻�"�ϰ�, ���� �ε��� ��ü�� ������ �ǰ�����Ʈ ǥ���ϱ�
public class Gun : MonoBehaviour
{
    public GameObject blmpactFactory;   // �Ѿ˰��� 

    // Start is called before the first frame update
    void Start()
    {
        // Call By Value
        // Call By Reference
       
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���콺 ���� ��ư�� ������
        if (Input.GetButtonDown("Fire1"))
        {
            // ����ī�޶� �ٶ󺻰��� �Ѿ� �ڱ��� ����� �ʹ�.
            // �ü�, �ٶ󺸴�, ���� ���� ����
            // ����ī�޶��� ��ġ���� ����ī�޶��� �չ������� �ü��� ����� �ʹ�. 
            // (�Ʒ� Ray~ if������ �ϳ��� ����or������. �׳� �ܿ���)
            /*
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            { 
            
            }
            */
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo;     // �ε��� ����� ������ ������ ����
            if (Physics.Raycast(ray, out hitInfo))
            {
                //print(hitInfo.transform.name);
                // �Ѿ��ڱ��� �κ��� ���� �����ʹ�.
                GameObject bImpact = Instantiate(blmpactFactory);
                bImpact.transform.position = hitInfo.point;
                bImpact.transform.forward = hitInfo.normal;     // �ε��� ����� ���� ����(normal)
            }


            


        }



    }
}

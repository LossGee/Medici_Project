using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ����ڰ� GŰ�� ������ ��ź���忡 ��ź�� ���� �� ��ġ�� ��ġ�ϰ�ʹ�. 
// step1)��ź�� �չ����� ���� ���������ϴ� ����(�� ������ 45��)���� ȸ����Ű�� �ʹ�. 
// step2)��ź�� �չ����� ���� ���������ϴ� ����(�� ������ 50��)���� ȸ����Ű�� �ʹ�. 
public class PlayThrow : MonoBehaviour
{
    public GameObject grenadeFactory;
    public Transform grenadeThrowPosition;
    public float throwPower = 10f;

    // Update is called once per frame
    void Update()
    {
        // 1. ���� ����ڰ� GŰ�� ������ 
        if (Input.GetKeyDown(KeyCode.G))
        {
            // 2. ��ź���忡�� ��ź�� ���� 
            GameObject grenade = Instantiate(grenadeFactory);
            // 3. ����ġ�� ��ġ�ϰ� �ʹ�. 
            grenade.transform.position = grenadeThrowPosition.position;
            // 4. ��ź�� �չ����� ���� �������� �ϴ� ����(�������� 45��(���� ȸ����Ű�� �ʹ�.)
            // way1) 45���� ������
            //Vector3 dir = transform.forward + transform.up;
            //dir.Normalize();
            //grenade.transform.position += dir * throwPower;

            // way2) ���� ���ϴ� ������ ������
            Quaternion q = grenadeThrowPosition.transform.rotation * Quaternion.Euler(-50, 0, 0);   //Quaternion�� *������ �ϸ� ������ ���ϴ� ��ó�� �������
            grenade.transform.rotation = q;

            // way3) �ѱ��������� ������
            //grenade.transform.forward = grenadeThrowPosition.forward;
        }

    }
}

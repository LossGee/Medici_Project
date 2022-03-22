using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();      // �ڽ� ������ Ÿ�� �������� Component �˻�
    
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ��ư�� ���� Animation ������ �� �ֵ��� ����
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Idle ����
            anim.SetTrigger("Idle");        // Animated blemd ������ ��
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.Play("Idle", 0, 0);        // Animate blend ���� ���� �ٷ� �ش� �ִϸ��̼����� �Ѿ
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Walk ����
            anim.SetTrigger("Walk");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // Attack ����
            anim.SetTrigger("Attack");
        }
    }
}

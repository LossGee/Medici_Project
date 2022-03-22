using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
step1) ������� �Է¿� ���� �յ��¿�� �̵��ϰ� �ʹ�.
step2) + �̵�����(dir)�� "ī�޶�"�� �������� �̵��ϰ� �ʹ�.
step3) Jump�� �ٰ� �ϰ� �ʹ�. (�ʿ��Ѱ�: �ٴ� ��, �߷�, y�ӵ�)
        �̶�, 
step4) ���� ������ �ٰ� �ʹ�. 

*/
public class PlayerMove : MonoBehaviour
{
    CharacterController cc;

    public float speed = 5.0f;      // P = P0 + vt�� Ȱ���ϴ� v��

    public float jumpPower = 10f;
    public float gravity = -9.81f;
    float yVelocity;

    int jumpCount;                  // ���� ������ �ϰ�ʹ�
    public int maxJumpCount = 2;           // ���� ���� �ִ� Ƚ�� ����
   
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();   //<> �ȿ� �� ��ȯ�ڷ����� ����Ǿ��� �� ���� ��. (using System.Collections.Generic;�� ���� ����)
    }

    // Update is called once per frame
    void Update()
    {
        // [Player Jump ��� ����]
        // 1. y�ӵ��� �߷��� ��� �޾ƾ� �Ѵ�. (�߷�: -9.81 m/s)
        yVelocity += gravity * Time.deltaTime;      // 1�ʴ� gravity�� �ѹ��� �޾ƾ� �ϹǷ� �̸� ������ �ް� �Ѵٰ� ����

        // ���� ���� ���ִٸ�(= '~�� ��� �´�� �ִٸ�'�� ���� ������� ����)
        //cc.collisionFlags & CollisionFlags.Below) != 0       // bit mask�� Ȱ���� ��
        //cc.isGrounded      // �� ������ �ٿ��� Unity���� �����ϴ� cc.isGrounded
        //if(cc.collisionFlags == CollisionFlags.Below)
        //{
        //    yVelocity = 0;
        //}

        if (cc.isGrounded)
        {
            // ���� ���� �� �ִٸ� ���� ȸ���� 0���� �ʱ�ȭ
            jumpCount = 0;
            yVelocity = 0;
        }
        else 
        {
            // ����, �����̶��
            yVelocity += gravity * Time.deltaTime;
        }
        // yVelocity�� 0���� �ϰ�ʹ�. 
        

        // 2. ���� ���� �� �ְ� ����Ű�� ������ y�ӵ��� jumpPower�� �����ϰ� �ʹ�.
        //    ����, ����Ƚ���� �ִ�����Ƚ������ �۰� ���� ��ư�� ������ y�ӵ��� jumpPower�� �����ϰ� �ͤ���
        if (jumpCount < maxJumpCount && Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
            jumpCount++;
        }
        // 3. �̵������� y�Ӽ��� y�ӵ��� �����ϰ� �ʹ�. 
        // �Ʒ� dir.Normalize(); ����� �� �־��ֵ��� �ڵ� �ۼ�


        // [Player �̵� ��� ����]
        // 1. ������� �Է¿� ���� 
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 2. �յ��¿�� ������ ����� 
        Vector3 dir = new Vector3(h, 0, v);
        //dir = dir.normalized; // .normalized ����: ũ�Ⱑ 1�� nomalized�� �纻�� �����Ѵ�. 
        // + "ī�޶�"�� �������� ������ �����ϰ� �ʹ�.
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;              // ĳ���Ͱ� ������������ �� ���� �����̴� ���� ����(y�������� �ٶ󺸰� �����ΰ��� �� ����� ����)   
        dir.Normalize();        // Normalize() �Լ�: dir ���� ��ü��  1�� ���� (���� �������� �̰� �� ����)

        Vector3 velocity = dir * speed;
        velocity.y = yVelocity;         // speed�� yVelocity�� �������� ���� ����

        // cc�� ����ϸ鼭 ĳ���͸� Ư����ǥ�� �����̵� ��Ű�� �ʹٸ�? 
        //cc.enabled = false;
        //transform.position = new Vector3(0, 0, 0);
        //cc.enabled = true;

        // 3. �� �������� �̵��ϰ� �ʹ�. 
        cc.Move(velocity * Time.deltaTime);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 from = transform.position;
        Vector3 to = transform.position + Vector3.up * yVelocity;
        Gizmos.DrawLine(from, to);
    }
}

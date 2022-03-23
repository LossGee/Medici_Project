using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimEvent : MonoBehaviour
{
    Enemy enemy;               // way1) Start���� GetComponentParent<Enemy>�� ã�� ���
    //public Enemy enemy;      // way2) �ܺο��� �־��ִ� ���

    // Start is called before the first frame update
    void Start()
    {
       enemy = GetComponentInParent<Enemy>();

    }
    public void OnEnemyAttackHit() 
    {
        // ���� Hit�� �Ǵ� ����
        enemy.OnEnemyAttackHit();
    }

    public void OnEnemyAttackFinished()
    {
        // ���� �ִϸ��̼��� ����Ǵ� ����
        enemy.OnEnemyAttackFinished();

    }
}

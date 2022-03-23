using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ȭ���� ��½�Ÿ��� ����� ����� �ʹ�. 
// ImageHit ���� ������Ʈ�� �����ٰ� 0.1�� �Ŀ� �Ⱥ��̰� �ϴ� ����� ����� �ʹ�. 
public class HitManager : MonoBehaviour
{
    // �̱������� ���弼��!!
    public static HitManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public GameObject imageHit;

    void Start()
    {
        imageHit.SetActive(false);
    }

    // ImageHit ���� ������Ʈ�� �����ٰ� 0.1�� �Ŀ� �Ⱥ��̰� �ϴ� ����� ����� �ʹ�.
    public void DoHitPlz()
    {
        StopCoroutine("IEDoHit");
        StartCoroutine("IEDoHit");      // StartCoroutine("�ڷ�ƾ�Լ�") - Coroutine�Լ��� ȣ���ϴ� ����!(�Ϲ� �Լ� ȣ��� �ٸ� ����!!!)
    }

    IEnumerator IEDoHit()     //�ڷ�ƾ �Լ��� ��ȯ���� ������ IEnumerator��
    {
        //print("IEDoHit Coroutine");
        // ���̰� �Ѵ�.
        imageHit.SetActive(true);
        yield return new WaitForSeconds(0.2f);    //yield �纸, ��� ���Զ�� �ǹ� 
        //�Ⱥ��̰� �Ѵ�. 
        imageHit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathInfo : MonoBehaviour
{
    public static PathInfo Instance;    // Singleton
    private void Awake()
    {
        Instance = this;
    }

    public GameObject[] wayPoints;

    // ���� list�� ����� �ʹٸ�?
    // public List<GameObject> wayPoints;
    // list�� ������ ������ ���� ��, Length�� �ƴ� .Count�� ����Ѵ�. 




}

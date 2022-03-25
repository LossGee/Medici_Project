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

    // 만약 list로 만들고 싶다면?
    // public List<GameObject> wayPoints;
    // list는 원소의 개수를 구할 때, Length가 아닌 .Count를 사용한다. 




}

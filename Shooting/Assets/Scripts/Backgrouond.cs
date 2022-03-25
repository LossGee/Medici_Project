using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
way1) 배경 스크롤이 되도록 하고 싶다. 
    1. 살아있는 동안 계속 하고싶다. 
    2. 방향이 필요하다 
    3. 스크롤하고싶다.

way2) 배경 스크롤을 하고 싶다. 
    1. 태어날 때 재질을 기억했다가 
    2. 살아가면서 재질의 offset값을 위로 이동하고싶다.
 */
public class Backgrouond : MonoBehaviour
{
    //public Material bgMaterial;       // way1) Material을 직접 넣어주는 경우
    Material mat;                       // way2) Mesh Renderer 속성을 가져오는 경우
    
    public float scrollSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        // 태어날때 재질을 기억한다. 
        mat = gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //2. 방향이 필요하다.
        Vector2 direction = Vector2.up;

        //3. 스크롤하고 싶다. 
        //bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
        mat.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}

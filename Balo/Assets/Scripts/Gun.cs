using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 만약 마우스 왼쪽 버튼을 누르면
// 메인카메라가 바라본곳에 총알 자국을 남기고 싶다. 
// 1. 사용자의 마우스 왼쪽 버튼 입력받기
// 2. Ray를 생성하고 '발사될 위치'와 '진행방향' 설정
// 3. "Ray가 부딪힌 대상의 정보를 저장할 변수" 생성하기 
// 4. "Ray를 발사"하고, 만일 부딪힌 물체가 있으면 피격이펙트 표시하기
public class Gun : MonoBehaviour
{
    public GameObject blmpactFactory;   // 총알공장 

    // Start is called before the first frame update
    void Start()
    {
        // Call By Value
        // Call By Reference
       
    }

    // Update is called once per frame
    void Update()
    {
        // 만약 마우스 왼쪽 버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            // 메인카메라가 바라본곳에 총알 자국을 남기고 싶다.
            // 시선, 바라보다, 닿은 곳의 정보
            // 메인카메라의 위치에서 메인카메라의 앞방향으로 시선을 만들고 싶다. 
            // (아래 Ray~ if까지는 하나의 형식or구문임. 그냥 외우자)
            /*
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            { 
            
            }
            */
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo;     // 부디진 대상의 정보를 저장할 변수
            if (Physics.Raycast(ray, out hitInfo))
            {
                //print(hitInfo.transform.name);
                // 총알자국을 부빚힌 곳에 남기고싶다.
                GameObject bImpact = Instantiate(blmpactFactory);
                bImpact.transform.position = hitInfo.point;
                bImpact.transform.forward = hitInfo.normal;     // 부딪힌 대상의 법선 벡터(normal)
            }


            


        }



    }
}

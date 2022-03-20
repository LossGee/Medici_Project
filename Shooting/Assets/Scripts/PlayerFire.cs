using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 사용자가 발사를 누르면 총알이 발사된다. 
// 1. 사용자가 발사 버튼을 누른다
// 2. 총알 공장에서 총알을 생산한다.
// 3. 총알을 발사한다. 
public class PlayerFire : MonoBehaviour
{
    // 총알을 생산하는 공장
    public GameObject bulletFactory;
    // 총구(총알이 위치할 곳)
    public GameObject firePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 사용자가 발사 버튼을 누른다
        if (Input.GetButtonDown("Fire1"))
        {
            // 2. 총알 공장에서 총알을 생산한다.
            GameObject bullet = Instantiate(bulletFactory);

            // 3. 총알을 발사한다. 
            bullet.transform.position = firePosition.transform.position;
        }
    }

        
}

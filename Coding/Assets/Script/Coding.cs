using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coding : MonoBehaviour
{
    // class!!!!!
    void Start()
    { 
        // 클래스 = 사용자 정의 자료형
        //        = 속성(property, 변수, 명사형) + 기능(method, 함수, 동사형)
        // 클래스로 만든 변수 = 객체, 인스턴스


    }

    /*// 문제!
    void Start()
    {
        int sum = 0;
        for (int i = 0; i <= 10; i++)
            if (i % 2 == 0) sum += i;
    }*/

    /*
    int number1 = 10;        // 전역변수(필드, 엄밀히 말하자면 다르기는 하지만... )
    int number2 = d20;

    void Start()
    {
        // 호출부
        int result = Plus(number1, number2);        // 지역변수(local)
        print(result);

        int result_A = Plus(30, 122);
        print(result_A);
    }

    // 구현부   <- 이거 자체만으로는 일을 하지 않는다.
    // 반환자료형 함수이름(매개변수)
    // {
    //      명령어블럭
    // }
    int c;
    int Plus(int a, int b)
    {
        int c;

        this.c = 10;        // 이건 Plus 밖에 있는 필드 c를 사용하고 싶을 때 this.를 이용한 것.
        int result = a + b;
        return result;
    }
    */


    /*void Start()
    {
        // 반복문
        // 0부터 10까지 숫자를 출력해 보세요.
        // for(1초기값 ; 2조건식 ; 4증감식)
        // {
        //     3 To Do
        // }; 
        // 동작 순서: 1,2,3,2,3,4...
        // i++(선명령실행 후증가)  vs ++i(선증가 후명령실행)


        for (int i = 0; i <= 10; i++)
        {
            //To Do
            print(i);
        }
    }
    */


    /*
        void Start2()
        {
            // 조건문 
            // 조건으로 분기를 만들어 줄 때, if는 반드시 작성해주어야 한다.(if문 시작)
            // 비교연산자, 논리연산자, bool형 등 다 들어갈 수 있음. 
            int number = 3;

            // 만약에 number가 1이라면 "걷는다"
            // 그렇지 않다면 "달린다"
            if (number > 1) print("걷는다");
            else if (number == 1) print("달린다");
            else print("난다~날아!");


            // 만약 number가 1이상이고 10이하라면 "걷는다"
            if (number >= 1 && number <= 10) print("걷는다");
            else if (number <= 2) print("난다");
            else print(걷는다)

        }
    */

    /*
    void Start1()
    {
        //자료형과 변수
        // 정수형 : int -1 0 1 2 3
        // 실수형 : float -0.4f -1.5f 0f 1.2f\
        // 논리형 : bool true false
        // 문자열 : string "가나다라마바사"

        //규칙
        // 자료형 변수이름 = 값;   <<  선언과 초기화까지 같이 한 케이스
        int a = 10;
        //int a;
        //a = 10;     // 이렇게도 가능

        float b = 10.1f;
        bool c = true;
        string d = "가나다라";

        print(d);
    
    }
    */

    void Update()
    {
        
    }
}

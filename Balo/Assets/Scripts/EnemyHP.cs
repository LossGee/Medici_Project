using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public int maxHP = 2;
    int hp;
    public Slider sliderHP;
    public int HP           //Property
    {
        get { return hp; }
        set {
            hp = value;
            sliderHP.value = hp;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // �¾ �� ü���� �ִ� ü������ �ϰ�ʹ�. 
        sliderHP.maxValue = maxHP;
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

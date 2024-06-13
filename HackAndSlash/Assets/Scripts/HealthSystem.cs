using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float health = 100;// 90/100 = 0.9
    public Image Image;

    void Start()
    {
        Image.fillAmount = 1f;
    }

    public void damage()
    {
        Image.fillAmount -= 0.05f;

    }



}

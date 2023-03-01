using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionSelection : MonoBehaviour
{
    float countDown = 5;
    public GameObject FoodIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown > 0)
        {
            countDown -= Time.fixedDeltaTime;
            if (countDown < 0)
            {
                showFoodIcon();
            }
        }
    }

    private void showFoodIcon()
    {
        FoodIcon.SetActive(true);
    }

    public void iconClicked()
    {
        //Debug.Log("Food Icon Clicked");
    }
    public void orderMissionClicked()
    {
        Debug.Log("Order button Clicked");

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public GameObject infoCard;
    public GameObject info_Button;
    public GameObject order_Button;
    public GameObject order_info_card;

    public void InfoButtonClicked()
    {
        infoCard.SetActive(true);
        info_Button.SetActive(false);
        order_Button.SetActive(false);
    }

    public void CancelButtonClicked()
    {
        transform.parent.gameObject.SetActive(false);
    }
    public void UpgradeButtonClicked()
    {
        Debug.Log("Upgrade button clicked");
    }
    public void OrderButtonClicked()
    {
        order_info_card.SetActive(true);
        order_Button.SetActive(false);
        info_Button.SetActive(false);
    }
    public void CookButtonClicked()
    {
        SceneManager.LoadScene("BurgerKing");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URL_Opener : MonoBehaviour
{
    public string Url_Ads;
    public string Url_Discount;
    public string Url_News;

    //We have url's above and on click it has to open those urls

    public void Open_Ads()
    {
        Application.OpenURL(Url_Ads);
    }
    public void Open_Discount()
    {
        Application.OpenURL(Url_Discount);
    }
    public void Open_News()
    {
        Application.OpenURL(Url_News);
    }
   
}

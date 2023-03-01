using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    //bool isSelected;
    //public LayerMask selectable;

    // to Activate Info Button
    public Button info_Button;
    public GameObject Order_Button;
    public GameObject upgradeButton;
    public bool showUI;


    // UI Text Game Objects
    public GameObject Building_Name_Object;
    public GameObject Building_Type_Object;
    public GameObject Building_Rent_Object;
    public GameObject Building_Level_Object;


    // UI Text Variables
    string Building_Name_Text;
    string Building_Type_Text;
    int Building_Rent_Text;
    string Building_Level_Text;

    // UI Text Components
    TextMeshProUGUI text_Name_Component;
    TextMeshProUGUI text_Type_Component;
    TextMeshProUGUI text_Rent_Component;
    TextMeshProUGUI text_Level_Component;

    private BuildingInformations getBuildingInfo;
    private GameObject selectedBuilding;
    private Outline selectedOutline;
    private bool isSelected;

    private GameObject previousBuilding;
    private GameObject activeBuilding;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit selectionRaycastHit;
            Ray selectionRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(selectionRay, out selectionRaycastHit, 100f))
            {
                previousBuilding = activeBuilding;
                activeBuilding = selectionRaycastHit.collider.gameObject;

                if (activeBuilding.CompareTag("Interactable"))
                {
                    EnableOutline(activeBuilding);
                }

                if (previousBuilding != activeBuilding && previousBuilding != null)
                {
                    DisableOutline(previousBuilding);
                }
            }
        }
    }

    private void EnableOutline(GameObject obj)
    {
        Outline outline = obj.GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = true;
            info_Button.gameObject.SetActive(true);
            Order_Button.SetActive(true);

            getBuildingInfo = activeBuilding.GetComponent<BuildingInformations>();
            // Printing Name of the Building to Info Card  
            Building_Name_Text = getBuildingInfo._name;
            text_Name_Component = Building_Name_Object.GetComponent<TextMeshProUGUI>();
            text_Name_Component.text = Building_Name_Text;

            // Printing Type of the Building to Info Card
            string TypeofBuilding = getBuildingInfo._type.ToString(); // Need to convert to String
            Building_Type_Text = TypeofBuilding;
            text_Type_Component = Building_Type_Object.GetComponent<TextMeshProUGUI>();
            text_Type_Component.text = Building_Type_Text;

            // Printing Rent of the Building to Info Card
            Building_Rent_Text = getBuildingInfo._rent;
            text_Rent_Component = Building_Rent_Object.GetComponent<TextMeshProUGUI>();
            text_Rent_Component.text = Building_Rent_Text.ToString();

            // Printing Level of the Building to Info Card
            Building_Level_Text = getBuildingInfo._level.ToString();
            text_Level_Component = Building_Level_Object.GetComponent<TextMeshProUGUI>();
            text_Level_Component.text = Building_Level_Text;
        }
    }

    private void DisableOutline(GameObject obj)
    {
        Outline outline = obj.GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = false;
        }
    }

}



/*  --------------------------Kucuk bir bug var ama calisiyor.-----------------------
 *if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject touchedObject = hit.transform.gameObject;
                // The player touched the object with the tag "Interactable"
                if (touchedObject.transform.CompareTag("Interactable"))
                {
                    if (selectedBuilding == null)
                    {
                        selectedBuilding = touchedObject;
                        selectedOutline = selectedBuilding.GetComponent<Outline>();
                        selectedOutline.enabled = true;
                        info_Button.gameObject.SetActive(true);
                        Order_Button.SetActive(true);


                        getBuildingInfo = selectedBuilding.GetComponent<BuildingInformations>();
                        // Printing Name of the Building to Info Card  
                        Building_Name_Text = getBuildingInfo._name;
                        text_Name_Component = Building_Name_Object.GetComponent<TextMeshProUGUI>();
                        text_Name_Component.text = Building_Name_Text;

                        // Printing Type of the Building to Info Card
                        string TypeofBuilding = getBuildingInfo._type.ToString(); // Need to convert to String
                        Building_Type_Text = TypeofBuilding;
                        text_Type_Component = Building_Type_Object.GetComponent<TextMeshProUGUI>();
                        text_Type_Component.text = Building_Type_Text;

                        // Printing Rent of the Building to Info Card
                        Building_Rent_Text = getBuildingInfo._rent;
                        text_Rent_Component = Building_Rent_Object.GetComponent<TextMeshProUGUI>();
                        text_Rent_Component.text = Building_Rent_Text.ToString();

                        // Printing Level of the Building to Info Card
                        Building_Level_Text = getBuildingInfo._level.ToString();
                        text_Level_Component = Building_Level_Object.GetComponent<TextMeshProUGUI>();
                        text_Level_Component.text = Building_Level_Text;
                    }
                    else
                    {
                        selectedOutline.enabled = false;
                        if (touchedObject == selectedBuilding)
                        {
                            selectedBuilding = null;
                            selectedOutline = null;
                            info_Button.gameObject.SetActive(false);
                            Order_Button.SetActive(false);
                        }
                        else
                        {
                            selectedBuilding = touchedObject;
                            selectedOutline = selectedBuilding.GetComponent<Outline>();
                            selectedOutline.enabled = true;
                            //info_Button.gameObject.SetActive(true);
                            Order_Button.SetActive(true);
                        }
                    }
                }
                else
                {
                    
                    if (selectedBuilding != null)
                    {
                        selectedOutline.enabled = false;
                        selectedBuilding = null;
                        selectedOutline = null;
                        //info_Button.gameObject.SetActive(false);
                        
                        
                    }
                }


            }
        }
 */
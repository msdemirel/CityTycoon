using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BurgerOrderManger : MonoBehaviour
{
    public string[] menus = { "Whopper", "Cheeseburger", "Fries", "Onion Rings" };

    // A dictionary to hold the topping lists for each menu item
    Dictionary<string, List<string>> toppingLists = new Dictionary<string, List<string>>();

    private bool hasOrder = false;

    public GameObject bubbleOrder;
    public TextMeshProUGUI textOrderName;
    float timePassed = 0f;

    public List<string> currentOrder = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        string level = (GetComponent<BuildingInformations>()._level.ToString());

        toppingLists.Add("Whopper", new List<string> { "Beef Patty", "Lettuce", "Tomato", "Onions", "Pickles", "Mayonnaise", "Ketchup", "Sesame Seed Bun" });
        toppingLists.Add("Cheeseburger", new List<string> { "Beef Patty", "American Cheese", "Lettuce", "Tomato", "Onions", "Pickles", "Mayonnaise", "Ketchup", "Sesame Seed Bun" });
        toppingLists.Add("Fries", new List<string> { "Potatoes", "Salt" });
        toppingLists.Add("Onion Rings", new List<string> { "Onions", "Bread Crumbs", "Flour", "Egg", "Salt" });
        Debug.Log("Level is: " + level);
    }
    private void Update()
    {
        if(hasOrder == false)
        {
            timePassed += Time.deltaTime;
            if (timePassed > 10)
            {
                GenerateOrder();
                timePassed = 0f;
            }
        }
    }

    void GenerateOrder()
    {
        // choose a menu
        string menu = menus[Random.Range(0, menus.Length)];
        // Get the toppings for the order
        List<string> toppings = toppingLists[menu];
        // Convert the list of toppings to a comma-separated string
        string toppingsString = string.Join(", ", toppings);
        // Log the new order with toppings
        Debug.Log("New order: " + menu + " with toppings: " + toppingsString);
        hasOrder = true;
        bubbleOrder.SetActive(true);
        textOrderName.text = menu;
        // Store the current order information
        string currentOrderName = menu;
        string currentOrderToppings = toppingsString;
        Debug.Log("Curennt oder: " + currentOrderName + currentOrderToppings);

    }
    void CompleteOrder()
    {
        //Check oreder completion        
    }
}
   

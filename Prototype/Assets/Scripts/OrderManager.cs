using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderManager : MonoBehaviour
{
    // A dictionary to hold the order lists for each restaurant
    Dictionary<string, List<string>> orderLists = new Dictionary<string, List<string>>();

    // A dictionary to hold the topping lists for each menu item
    Dictionary<string, List<string>> toppingLists = new Dictionary<string, List<string>>();

    // The restaurants
    public string[] restaurants = { "Burger King", "Pizza Town", "Sushi Mushi" };

    // The order bubble prefab
    //public GameObject orderBubblePrefab;

    // The position to spawn the order bubbles
    //public Vector3 orderBubblePosition = new Vector3(0, 10, 0);

    // The probability of an order appearing each frame
    //public float orderProbability = 0.01f;

    float timePassed = 0f;

    void Start()
    {
        // Populate the order lists for each restaurant
        orderLists.Add("Burger King", new List<string> { "Whopper", "Cheeseburger", "Fries", "Onion Rings" });
        orderLists.Add("Pizza Town", new List<string> { "Pepperoni Pizza", "Hawaiian Pizza", "Garlic Bread" });
        orderLists.Add("Sushi Mushi", new List<string> { "California Roll", "Spicy Tuna Roll", "Miso Soup", "Edamame" });

        // Populate the topping lists for each menu item
        toppingLists.Add("Whopper", new List<string> { "Beef Patty", "Lettuce", "Tomato", "Onions", "Pickles", "Mayonnaise", "Ketchup", "Sesame Seed Bun" });
        toppingLists.Add("Cheeseburger", new List<string> { "Beef Patty", "American Cheese", "Lettuce", "Tomato", "Onions", "Pickles", "Mayonnaise", "Ketchup", "Sesame Seed Bun" });
        toppingLists.Add("Fries", new List<string> { "Potatoes", "Salt" });
        toppingLists.Add("Onion Rings", new List<string> { "Onions", "Bread Crumbs", "Flour", "Egg", "Salt" });
        toppingLists.Add("Pepperoni Pizza", new List<string> { "Dough", "Tomato Sauce", "Mozzarella Cheese", "Pepperoni" });
        toppingLists.Add("Hawaiian Pizza", new List<string> { "Dough", "Tomato Sauce", "Mozzarella Cheese", "Ham", "Pineapple" });
        toppingLists.Add("Garlic Bread", new List<string> { "Baguette", "Garlic", "Butter" });
        toppingLists.Add("California Roll", new List<string> { "Rice", "Nori", "Avocado", "Imitation Crab", "Cucumber" });
        toppingLists.Add("Spicy Tuna Roll", new List<string> { "Rice", "Nori", "Tuna", "Mayonnaise", "Sriracha Sauce" });
        toppingLists.Add("Miso Soup", new List<string> { "Dashi Stock", "Miso Paste", "Tofu", "Seaweed", "Green Onions" });
        toppingLists.Add("Edamame", new List<string> { "Soybeans", "Salt" });
    }
    private void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > 10)
        {
            string orderString = GenerateRandomOrder();
            Debug.Log("New order: " + orderString);
            Debug.Log("-------------------------------------------------------------------");
            timePassed = 0f;
        }
    }

    string GenerateRandomOrder()
    {
        // Choose a random restaurant
        string restaurant = restaurants[Random.Range(0, restaurants.Length)];

        // Choose a random order from the selected restaurant's order list
        List<string> orders = orderLists[restaurant];
        string order = orders[Random.Range(0, orders.Count)];

        // Get the toppings for the order
        List<string> toppings = toppingLists[order];

        // Build the order string with the toppings included
        string orderString = restaurant + " - " + order + " with ";
        for (int i = 0; i < toppings.Count; i++)
        {
            orderString += toppings[i];
            if (i < toppings.Count - 1)
            {
                orderString += ", ";
            }
        }

        // Return the order string
        return orderString;
    }
}

/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderManager : MonoBehaviour
{
    // Game Objects of Texts
    public TextMeshProUGUI foodTypeText;
    public TextMeshProUGUI foodToppingsText;
    public TextMeshProUGUI foodCostText;


    // Lists of Food types and toppings
    private string[] foodTypes = { "Pizza", "Sushi", "Burger" };
    private string[][] toppings =
    {
        new string[] { "Cheese", "Sauce", "Mushroom", "Pepperoni" },
        new string[] { "Rice", "Seaweed", "Fish", "Avocado" },
        new string[] { "Bun", "Meat", "Lettuce", "Tomato" },
    };
    private int[][] toppingCosts =
    {
        new int[] { 1, 2, 2, 3 },
        new int[] { 2, 2, 3, 3 },
        new int[] { 1, 2, 1, 1 },
    };

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateOrder", 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateOrder()
    {
        // Randomly generate food type, toppings, and cost

        // Randomly generate food type, toppings, and cost
        int foodIndex = Random.Range(0, foodTypes.Length);
        string foodType = foodTypes[foodIndex];
        string toppingsStr = "";
        int cost = 0;
        for (int i = 0; i < toppings[foodIndex].Length; i++)
        {
            if (Random.Range(1, 3) == 1)
            {
                toppingsStr += toppings[foodIndex][i] + ", ";
                cost += toppingCosts[foodIndex][i];
            }
        }
        toppingsStr = toppingsStr.TrimEnd(',', ' ');


        Debug.Log("The order: " + foodType + " " + toppingsStr + " " + cost );

        foodTypeText.text = foodType;
        foodToppingsText.text = toppingsStr;
        string costStr = cost.ToString();
        foodCostText.text = costStr;

    }
}

 */

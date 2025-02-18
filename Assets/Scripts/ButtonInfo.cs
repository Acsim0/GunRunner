using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public List<int> ItemIdList;
    public TextMeshProUGUI PriceTxt;
    public TextMeshProUGUI NameTxt;
    public GameObject ShopManager;

    private void Start()
    {
        List<int> ItemIdList = ShopManager.GetComponent<ShopManagerScript>().ItemIDlist;
        
        if (this.name == "Button (1)")
        {
            Invoke("GenerateItem", 0.1f);
        }
        else if (this.name == "Button (2)")
        {
            Invoke("GenerateItem", 0.2f);

        }
        else
        {
            GenerateItem();
        }
        ;
    }
    public void GenerateItem()
    {
        
        ItemID = Random.Range(1, 5);
        if (ItemIdList.Contains(ItemID))
        {
            int number = ItemIdList.IndexOf(ItemID);
            Debug.Log("Leck Eier");
            ShopManager.GetComponent<ShopManagerScript>().RemoveNumber(ItemID);
            
            
        }
        else
        {
            GenerateItem();
            Debug.Log("New Number");
        }
    }

    void Update()
    {
        
        
        PriceTxt.text = "Price: " + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString();
        if (ItemID == 1)
        {
            NameTxt.text = "Movement Speed";
        }
        else if (ItemID == 2)
        {
            NameTxt.text = "Bullet Delay";
        }
        else if (ItemID == 3)
        {
            NameTxt.text = "Health";
        }
        else if (ItemID == 4)
        {
            NameTxt.text = "Test";
        }

    }
}

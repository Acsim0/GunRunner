using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5,8];
    public PlayerControl Player;
    public Shooting shooting;
    public float coins;
    public TextMeshProUGUI CoinsTxt;
    public List<int> ItemIDlist;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        shooting = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();

        foreach (int value in Enumerable.Range(1, 4))
        {
            ItemIDlist.Add(value);
        }

        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        shopItems[2, 1] = 10;
        shopItems[2, 2] = 40;
        shopItems[2, 3] = 20;
        shopItems[2, 4] = 80;

    }

    public void PlayerChange(int ItemID)
    {
        if (ItemID == 1)
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
            Player.GetComponent<PlayerControl>().movSpeed += 1;
        }
        if(ItemID == 2)
        {
            shooting = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
            shooting.GetComponent<Shooting>().Bulletdelay -= 0.1f ;
        }
        if(ItemID == 3)
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
            Player.GetComponent<PlayerControl>().health += 10;
        }
        if (ItemID == 4)
        {
            Debug.Log("Number 4");
        }

    }

    public void RemoveNumber(int ItemID)
    {
        ItemIDlist.Remove(ItemID);
        Debug.Log("Removed" + ItemID);
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (Player.coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            Player.coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            CoinsTxt.text = "Coins: " + coins.ToString();
            PlayerChange(ButtonRef.GetComponent<ButtonInfo>().ItemID);


        }

    }
    void Update()
    {
        coins = Player.coins;
        CoinsTxt.text = "Coins: " + coins.ToString();
    }
}

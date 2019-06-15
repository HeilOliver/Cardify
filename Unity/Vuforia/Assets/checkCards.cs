using Cardify.Logic;
using Cardify.Logic.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class checkCards : MonoBehaviour
{

    public Text cardText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkButtonClicked()
    {
        //Debug.LogWarning("TEST");
        
        var manager = new CardScoreManager()
        {
            //search for cards first button klick
            HandCards = searchforCards(),
            //search for cards last button klick
            DeskCards = new CardSet()
        };

        var result = manager.CalculateScore();

        //string resultString = result?.Name ?? "None";
        cardText.text = result?.Name ?? "None";
    }

    private GameObject[] cards;

    private CardSet searchforCards()
    {
        cards = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        String outText = "";
        CardSet cs = new CardSet();
        
        for (var i = 0; i < cards.Length; i++)
        {
            if (cards[i].name.StartsWith("Coin") | cards[i].name.StartsWith("Cucumber") | cards[i].name.StartsWith("Sword") | cards[i].name.StartsWith("Goblet")) 
            {
                var trackable = cards[i].GetComponent<TrackableBehaviour>();
                var status = trackable.CurrentStatus;
                if(status == TrackableBehaviour.Status.TRACKED)
                {
                    //Debug.LogWarning(cards[i].name);
                    //outText = outText + cards[i].name + ", ";
                    cs.AddCard(BuildCard(cards[i]));
                }
            }
        }
        return cs;        
    }

    private Card BuildCard(GameObject go)
    {
        CardColor cc = CardColor.Coin;
        CardValue cv = CardValue.Ace;

        string str = go.name;

        if (str.StartsWith("Sword"))
        {
            cc = CardColor.Sword;
            str = str.Replace("Sword", "");
        }
        else if (str.StartsWith("Coin"))
        {
            cc = CardColor.Coin;
            str = str.Replace("Coin", "");
        }
        else if (str.StartsWith("Cucumber"))
        {
            cc = CardColor.Cucumber;
            str = str.Replace("Cucumber", "");
        }
        else if (str.StartsWith("Gobled"))
        {
            cc = CardColor.Goblet;
            str = str.Replace("Gobled", "");
        }

        switch (str)
        {
            case "Jack":
                cv = CardValue.Jack;
                break;
            case "Queen":
                cv = CardValue.Queen;
                break;
            case "King":
                cv = CardValue.King;
                break;
            case "Ace":
                cv = CardValue.Ace;
                break;
            case "2":
                cv = CardValue.Two;
                break;
            case "3":
                cv = CardValue.Three;
                break;
            case "4":
                cv = CardValue.Four;
                break;
            case "5":
                cv = CardValue.Five;
                break;
            case "6":
                cv = CardValue.Six;
                break;
            case "7":
                cv = CardValue.Seven;
                break;
            case "8":
                cv = CardValue.Eight;
                break;
            case "9":
                cv = CardValue.Nine;
                break;
            case "10":
                cv = CardValue.Ten;
                break;
            default:
                break;
        }

        Debug.LogWarning($"Found {cc} - {cv} -> {go.name}");


        Card rc = new Card(cc, cv);
     return rc;
    }

}





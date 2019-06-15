using System;
using System.Collections;
using System.Collections.Generic;
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
        searchforCards();

    }

    private GameObject[] cards;

    private void searchforCards()
    {
        cards = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        String outText = ""; 
        
        for (var i = 0; i < cards.Length; i++)
        {
            if (cards[i].name.StartsWith("Coin") | cards[i].name.StartsWith("Cucumber") | cards[i].name.StartsWith("Sword") | cards[i].name.StartsWith("Goblet")) 
            {
                var trackable = cards[i].GetComponent<TrackableBehaviour>();
                var status = trackable.CurrentStatus;
                if(status == TrackableBehaviour.Status.TRACKED)
                {
                    Debug.LogWarning(cards[i].name);
                    outText = outText + cards[i].name;
                }
            }
        }
        cardText.text = outText ;
    }



}





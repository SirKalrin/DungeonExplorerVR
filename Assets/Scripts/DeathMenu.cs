using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {
    private string points0 = "YOU ARE BAD AT THIS GAME " + "\n" + "AND YOU SHOULD FEEL BAD." + "\n" + "YOU ONLY GOT " + GlobalPointSystem.Instance.points + " POINTS. " + "\n" + "PATHETIC!";
    private string points250 = "YOU ARE NOT GOOD AT THIS GAME " + "\n" + "AND YOU SHOULD FEEL A LITTLE BAD." + "\n" + "YOU ONLY GOT " + GlobalPointSystem.Instance.points + " POINTS. " + "\n" + "SAD!";
    private string points500 = "YOU ARE NOT BAD AT THIS GAME " + "\n" + "AND YOU SHOULD FEEL OK I GUESS." + "\n" + "YOU GOT " + GlobalPointSystem.Instance.points + " POINTS. " + "\n" + "ACCEPTABLE TO SOME!";
    private string points1000 = "YOU ARE OKAY AT THIS GAME " + "\n" + "AND YOU SHOULD FEEL GOOD." + "\n" + "YOU GOT " + GlobalPointSystem.Instance.points + " POINTS. " + "\n" + "YOU CAN STOP CRYING!";
    private int points = GlobalPointSystem.Instance.points;
    void Start()
    {
        PopulateText();
    }
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButton("Fire1"))
	    {
            Initiate.Fade("MenuTake1b", Color.white, 2);

        }
	}
    public void PopulateText()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponentInChildren<TextMesh>().alignment = TextAlignment.Center;
            if(points < 250)
            transform.GetChild(i).GetComponentInChildren<TextMesh>().text = points0;
            else if (points < 500)
            {
                transform.GetChild(i).GetComponentInChildren<TextMesh>().text = points250;
            }
            else if (points < 1000)
            {
                transform.GetChild(i).GetComponentInChildren<TextMesh>().text = points500;
            }
            else
            {
                transform.GetChild(i).GetComponentInChildren<TextMesh>().text = points1000;
            }

        }

        var texts = GameObject.FindGameObjectsWithTag("Text");

        Debug.Log(texts.ToString());
        foreach (var text in texts)
        {
            //(Text) text.text = "YOU ARE BAD AT THIS GAME AND YOU SHOULD FEEL BAD. YOU ONLY GOT " + GlobalPointSystem.Instance.points + " POINTS. PATHETIC!";
        }
    }
}

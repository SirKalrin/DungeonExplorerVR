using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalPointSystem : MonoBehaviour
{
    public int points;

        public static GlobalPointSystem Instance;

        void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

    public void PopulateText()
    {
        var texts = FindObjectsOfType<Text>();
        Debug.Log(texts);
        foreach (Text text in texts)
        {
            text.text = "YOU ARE BAD AT THIS GAME AND YOU SHOULD FEEL BAD. YOU ONLY GOT " + points + " POINTS. PATHETIC!";
        }
    }
}
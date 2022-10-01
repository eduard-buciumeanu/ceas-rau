using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    private char noteKey;
    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Load a random sprite from resources at runtime
        spriteRenderer.sprite = Resources.Load<Sprite>(ChooseNote());
        
    }

    private string ChooseNote()
    {
        string resourcePath = "Sprites/";

        int rand = UnityEngine.Random.Range(0,4);
        switch (rand)
        {
            case 0:
                resourcePath += "q_note";
                noteKey = 'q';
                break;
            case 1:
                resourcePath += "w_note";
                noteKey = 'w';
                break;
            case 2:
                resourcePath += "e_note";
                noteKey = 'e';
                break;
            case 3:
                resourcePath += "r_note";
                noteKey = 'r';
                break;
            default:
                print("Error: cannot choose note");
                break;
        }
        return resourcePath;
    }

    public string GetNote()
    {
        return noteKey.ToString();
    }

}

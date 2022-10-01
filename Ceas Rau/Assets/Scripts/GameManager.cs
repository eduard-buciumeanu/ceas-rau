using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private NoteSpawner noteSpawner;
    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        noteSpawner = NoteSpawner.instance;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            VerifyHit("q");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            VerifyHit("w");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            VerifyHit("e");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            VerifyHit("r");
        }
    }

    void VerifyHit(string keyCode)
    {

        if (noteSpawner.GetSpawnedNote() == keyCode)
        {
            print("Correct!");
        }else
        {
            print("Wrong!");
        }
        noteSpawner.ClearNote();
    }
}
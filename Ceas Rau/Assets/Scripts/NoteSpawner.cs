using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public static NoteSpawner instance;
    

    private GameObject spawnedNote;
    private UIManager uiManager;
    [SerializeField]float noteTimer;
    private float decayTimer;

    void Awake() 
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Getting the UIManager ref
        uiManager = UIManager.instance;

        SpawnNote();
        
    }

    void SpawnNote()
    {
        spawnedNote = (GameObject)Instantiate(Resources.Load("Note"));
        decayTimer = noteTimer;
        
    }

    void Update()
    {
        TickTimer();
    }

    void TickTimer()
    {
        if (decayTimer > 0)
        {
            decayTimer -= Time.deltaTime;
            uiManager.SetTimerProgress(decayTimer/noteTimer);
        }else
        {
            if (spawnedNote != null)
            {
                Destroy(spawnedNote, 0.1f);
            }else
            {
                SpawnNote();
            }
            
        }
    }

    public string GetSpawnedNote()
    {
        if (spawnedNote != null)
        {
            string currentSpawnedNote = spawnedNote.GetComponent<NoteScript>().GetNote();
            return currentSpawnedNote;
        }else
        {
            Debug.Log("No spawned note!");
            return null;
        }
    }

    public void ClearNote()
    {
        Destroy(spawnedNote, 0.1f);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public static NoteSpawner instance;
    

    // private GameObject spawnedNote;
    public struct Note
    {
        public char currentNote { get; }
        public Sprite currentSprite { get; set; }
        public bool isActive {get; set;}
        public Note(char noteKey, Sprite noteSprite, bool active)
        {
            currentNote = noteKey;
            currentSprite = noteSprite;
            isActive = active;
        }

    }

    private SpriteRenderer spriteRenderer;
    private Note spawnedNote;
    private UIManager uiManager;
    private GameManager gameManager;
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
    
    void Start()
    {
        //Getting the UIManager ref
        uiManager = UIManager.instance;
        gameManager = GameManager.instance;

        spriteRenderer = GetComponent<SpriteRenderer>();

        SpawnNote();
        
    }

    void SpawnNote()
    {
        char noteKey = ChooseNote();

        spawnedNote = new Note(noteKey, Resources.Load<Sprite>($"Sprites/{noteKey}_note"), true);
        
        spriteRenderer.sprite = spawnedNote.currentSprite;

        // spawnedNote = (GameObject)Instantiate(Resources.Load("Note"), gameObject.transform.position, Quaternion.identity);
        decayTimer = noteTimer;
        
    }

    void Update()
    {
        if (!spawnedNote.isActive)
        {
            spriteRenderer.sprite = null;
        }

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
            if (spawnedNote.isActive)
            {
                // Destroy(spawnedNote, 0.1f);
                spawnedNote.isActive = false;
                gameManager.RegisterMiss();
            }else
            {
                SpawnNote();
            }
            
        }
    }

    private char ChooseNote()
    {
        
        char noteKey = 'a';

        int rand = UnityEngine.Random.Range(0,4);
        switch (rand)
        {
            case 0:
                noteKey = 'q';
                break;
            case 1:
                noteKey = 'w';
                break;
            case 2:
                noteKey = 'e';
                break;
            case 3:
                noteKey = 'r';
                break;
            default:
                print("Error: cannot choose note");
                break;
        }
        return noteKey;
    }

    public string GetSpawnedNote()
    {
        if (spawnedNote.isActive)
        {
            // string currentSpawnedNote = spawnedNote.GetComponent<NoteScript>().GetNote();
            return spawnedNote.currentNote.ToString();
        }else
        {
            Debug.Log("No spawned note!");
            return null;
        }

        
    }

    public void ClearNote()
    {
        // Destroy(spawnedNote, 0.1f);

        spawnedNote.isActive = false;
    }

    
}

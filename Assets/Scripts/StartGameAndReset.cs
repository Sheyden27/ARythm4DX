using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartGameAndReset : MonoBehaviour
{
    public GameObject generatorsObj;
    public Button me;
    public GameObject overlay;
    public GameObject mainMenuCanvas;

    public TMP_Text scoreText;
    public TMP_Text comboText;

    public HealthHandler healthHandler;

    public bool isFromRestart = false;

    //public GameObject healthContainer;
    //public List<GameObject> healthBars;

    // Start is called before the first frame update
    void Start()
    {
        me.onClick.AddListener(StartOrRestart);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        overlay.SetActive(false);
        StopGame();
    }

    private void OnDisable()
    {
        //overlay.SetActive(true);
    }

    public void StartOrRestart()
    {
        if (!isFromRestart) {
            StartGame();
            //gameObject.SetActive(false);
        } else if (isFromRestart) {
            isFromRestart = false;
            healthHandler.ResetHealth();
            ResetGame();
        }
    }

    private void StopGame()
    {
        generatorsObj.SetActive(false);
    }

    public void StartGame()
    {
        foreach (var generator in generatorsObj.GetComponentsInChildren<NotesGenerator>())
        {
            Debug.Log(generator);
        }
        overlay.SetActive(true);
        generatorsObj.SetActive(true);
        mainMenuCanvas.SetActive(false);
        //gameObject.SetActive(false);
    }

    public void ResetGame()
    {
        foreach (var generator in generatorsObj.GetComponentsInChildren<NotesGenerator>())
        {
            foreach (var note in generator.GetComponentsInChildren<NoteBehaviour>())
            {
                Destroy(note.gameObject);
            }
        }
        scoreText.text = "0";
        comboText.text = "0";
        generatorsObj.SetActive(true);
        overlay.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }
}

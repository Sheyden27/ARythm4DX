using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesGenerator : MonoBehaviour
{
    public GameObject[] generatorsObjs;
    public GameObject noteObj;
    public List<GameObject> notesList = new List<GameObject>();

    private bool playingSong = false;
    private int[] timings = new int[10];

    private int currentNoteID = 0;


    private float lastUpdate;
    public float lastSpeedUpdate = 0;
    public float timeNow = 0;
    public float notesSpeed = 12000;
    public float maxSpawnWait = 1f;
    public float minSpawnWait = 0.2f;
    public float nbTimesMoreDifficult = 0;

    private int genNum;
    private float randomWait;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(CoroutineSpawn());
        timings[0] = 10;
        //SpawnNote(generatorsObjs[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (playingSong)
        {
            timeNow = Time.time;
            if (Time.time - lastUpdate > 1)
            {
                lastUpdate = Time.time;
                StartCoroutine(CoroutineSpawn());
            }
            //if (Time.time - lastSpeedUpdate > 10)
            //{
            //    lastSpeedUpdate = Time.time;
            //}
            //StartCoroutine(CoroutineSpawn());
        }
    }

    void ButtonClicked()
    {
        StartCoroutine(CoroutineSpawn());
        //timeNow = Time.time;
        //keyMaterial.color = Color.green;
        //if (timeNow + 2 < Time.time)
        //{

        //}
    }

    void SpawnNote(GameObject generatorObj, int genNum)
    {
        //var tempNote = noteObj;
        //var tempNoteColor = tempNote.transform.GetChild(1);
        //tempNoteColor.GetComponent<Renderer>().material.color = generatorObj.GetComponent<Renderer>().material.color;
        /*var material = tempNote.GetComponent<Renderer>().material;
        material = generatorObj.GetComponent<Renderer>().material;*/
        Instantiate(notesList[genNum], generatorObj.transform);
    }

    IEnumerator CoroutineSpawn()
    {
        randomWait = Random.Range(0.1f, 0.15f);
        yield return new WaitForSeconds(randomWait);
        genNum = Random.Range(0, 4);
        SpawnNote(generatorsObjs[genNum], genNum);

    }

    private void OnEnable()
    {
        playingSong = true;
    }
    private void OnDisable()
    {
        playingSong = false;
    }
}

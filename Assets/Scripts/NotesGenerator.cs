using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesGenerator : MonoBehaviour
{
    public GameObject[] generatorsObjs;
    public GameObject noteObj;

    private bool playingSong = false;
    private int[] timings = new int[10];

    private int currentNoteID = 0;

    private float lastUpdate;
    private int genNum;

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
            if (Time.time - lastUpdate > 1)
            {
                lastUpdate = Time.time;
                StartCoroutine(CoroutineSpawn());
            }
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

    void SpawnNote(GameObject generatorObj)
    {
        Instantiate(noteObj, generatorObj.transform);
    }

    IEnumerator CoroutineSpawn()
    {
        yield return new WaitForSeconds(0.8f);
        genNum = Random.Range(0, 4);
        SpawnNote(generatorsObjs[genNum]);

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

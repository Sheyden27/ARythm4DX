using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    private ClickerKey clicker;
    public NotesGenerator notesGenerator;

    public float noteSpeed = -0.5f;
    //private float multiplier = 350; // test env
    private float multiplier = 12000; // real, don't touch
    private float secondsBeforeDifficultyRise = 20;
    private bool isAdvancing = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        notesGenerator = GetComponentInParent<NotesGenerator>();
        multiplier = notesGenerator.notesSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if ((notesGenerator.timeNow - notesGenerator.lastSpeedUpdate > secondsBeforeDifficultyRise) && notesGenerator.nbTimesMoreDifficult < 8)
        {
            if (notesGenerator.nbTimesMoreDifficult < 6) {
                notesGenerator.notesSpeed *= 1.1f;
            }
            notesGenerator.lastSpeedUpdate = Time.time;
            notesGenerator.maxSpawnWait -= 0.1f;
            notesGenerator.nbTimesMoreDifficult++;
        }
        if (notesGenerator.nbTimesMoreDifficult == 8) {
            notesGenerator.minSpawnWait = 0.06f;
            notesGenerator.maxSpawnWait = 0.14f;
            notesGenerator.nbTimesMoreDifficult++;
        }
        //if (Time.time - notesGenerator.lastSpeedUpdate > 10)
        //{
        //    multiplier = multiplier * 1.1f;
        //    notesGenerator.lastSpeedUpdate = Time.time;
        //}
        transform.localPosition += new Vector3(0, 0, noteSpeed * multiplier);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        //StartCoroutine(WaitAndDestroy());
    }
    private void OnTriggerStay(Collider other)
    {
        
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject);
    //}
    //private void OnCollisionStay(Collision collision)
    //{
        
    //}
}

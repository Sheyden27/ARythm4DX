using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerKey : MonoBehaviour
{
    public HealthHandler playerHealthHandler;

    public TMP_Text scoreText;
    public TMP_Text comboText;
    public TMP_Text boardPopUpScore;
    //public Animation animator;
    public Button correspondingButton;
    private Material selfMaterial;

    public Material baseMaterial;
    public Material clickedMaterial;

    //private GameObject[] collisions;
    public List<GameObject> collisions;

    public GameObject InternalSphere;
    public GameObject ExternalSphere;

    private bool isNoteInside = false;
    private bool isNoteHit = false;
    private bool isNotePerfect = false;

    // Start is called before the first frame update
    void Start()
    {
        selfMaterial = gameObject.GetComponent<Renderer>().material;
        correspondingButton.onClick.AddListener(ButtonClicked);
        //playerHealthHandler = GetComponentInParent<HealthHandler>();
        //animator = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (collisions.First() && !collisions.First().activeInHierarchy)
        //{
        //    collisions.Remove(collisions[0]);
        //}
    }

    void ButtonClicked()
    {
        StartCoroutine(FlashColor());
        DeleteFirstNote();
        //timeNow = Time.time;
        //keyMaterial.color = Color.green;
        //if (timeNow + 2 < Time.time)
        //{

        //}
    }

    public void OnExternalSphereEntered(Collider other)
    {
        Debug.LogWarning(other.gameObject);
        collisions.Add(other.gameObject);
        isNoteInside = true;
        isNoteHit = true;
        StartCoroutine(WaitAndDestroyNote(other.gameObject));
    }
    public void OnExternalSphereExited(Collider other)
    {
        collisions.Remove(other.gameObject);
        isNoteInside = false;
        isNoteHit = false;
        comboText.text = "0";
        StartCoroutine(FlashColorFailed());
        playerHealthHandler.DescraeseHealth();
    }

    public void OnInternalSphereEntered(Collider other)
    {
        isNotePerfect = true;
    }
    public void OnInternalSphereExited(Collider other)
    {
        isNotePerfect = false;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        //collisions.Append(other.gameObject);
        Debug.LogWarning(other.gameObject);
        collisions.Add(other.gameObject);
        isNoteInside = true;
        StartCoroutine(WaitAndDestroyNote(other.gameObject));
    }

    private void OnTriggerExit(Collider other)
    {
        collisions.Remove(other.gameObject);
        isNoteInside = false;
    }*/

    private void DeleteFirstNote()
    {
        if (collisions.First() != null)
        {
            try {
                Destroy(collisions.First());
                collisions.Remove(collisions[0]);
                var currentScore = int.Parse(scoreText.text);
                var currentCombo = int.Parse(comboText.text);
                var animPlayer = boardPopUpScore.GetComponent<Animator>();
                var comboAnim = comboText.GetComponent<Animation>();

                if (isNoteHit && !isNotePerfect) {
                    scoreText.text = (currentScore + (100 * (currentCombo + 1))).ToString();
                    comboText.text = (currentCombo + 1).ToString();
                    boardPopUpScore.text = "100";
                    isNoteHit = false;
                    //animator.Play("boardScoreTextAnim");
                    animPlayer.Play("boardHalfScoreAnim");
                    comboAnim.Play();
                }
                else if (isNotePerfect) {
                    scoreText.text = (currentScore + (300 * (currentCombo + 1))).ToString();
                    comboText.text = (currentCombo + 1).ToString();
                    boardPopUpScore.text = "300";
                    isNotePerfect = false;
                    isNoteHit = false;
                    //animator.Play("boardScoreTextAnim");
                    
                    animPlayer.Play("boardScoreTextAnim");
                    comboAnim.Play();
                }
                /*else {
                    //boardPopUpScore.text = "ssiM";
                    //animator.Play("boardMissTextAnim");
                    //animPlayer.Play("boardMissTextAnim");
                }*/
            } catch { 
                Debug.LogError("Pb ca exite pas");
            }
        } else {
            var animPlayer = boardPopUpScore.GetComponent<Animator>();
            var comboAnim = comboText.GetComponent<Animation>();
            boardPopUpScore.text = "Miss";
            animPlayer.Play("boardMissTextAnim");
            comboAnim.Play();
            comboText.text = "0";
        }
    }

    IEnumerator FlashColor()
    {
        selfMaterial.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        selfMaterial.color = baseMaterial.color;
    }

    IEnumerator FlashColorFailed()
    {
        var animPlayer = boardPopUpScore.GetComponent<Animator>();
        selfMaterial.color = Color.red;
        boardPopUpScore.text = "Miss";
        animPlayer.Play("boardMissTextAnim");
        yield return new WaitForSeconds(0.2f);
        selfMaterial.color = baseMaterial.color;
    }

    IEnumerator WaitAndDestroyNote(GameObject note)
    {
        yield return new WaitForSeconds(2);
        if (note != null) {
            Destroy(note);
            collisions.Remove(note);
        }
    }
}

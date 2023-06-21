using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClickerKey : MonoBehaviour
{
    public Button correspondingButton;
    private Material selfMaterial;

    public Material baseMaterial;
    public Material clickedMaterial;

    //private GameObject[] collisions;
    public List<GameObject> collisions;

    // Start is called before the first frame update
    void Start()
    {
        selfMaterial = gameObject.GetComponent<Renderer>().material;
        correspondingButton.onClick.AddListener(ButtonClicked);
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

    private void OnTriggerEnter(Collider other)
    {
        //collisions.Append(other.gameObject);
        collisions.Add(other.gameObject);
        StartCoroutine(WaitAndDestroyNote(other.gameObject));
    }

    private void OnTriggerExit(Collider other)
    {
        collisions.Remove(other.gameObject);
    }

    private void DeleteFirstNote()
    {
        if (collisions.First() != null)
        {
            try {
                Destroy(collisions.First());
                collisions.Remove(collisions[0]);
            } catch { Debug.LogError("Pb ca exite pas"); }
        }
    }

    IEnumerator FlashColor()
    {
        selfMaterial.color = Color.green;
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

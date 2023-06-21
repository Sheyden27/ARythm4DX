using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject correspondingClickerKey;
    public Button selfButton;

    public Material baseMaterial;
    public Material clickedMaterial;

    private Renderer keyRenderer;
    private Material keyMaterial;
    private float timeNow;

    // Start is called before the first frame update
    void Start()
    {
        /*selfButton.onClick.AddListener(ButtonClicked);
        keyRenderer = correspondingClickerKey.GetComponent<Renderer>();
        keyMaterial = correspondingClickerKey.GetComponent<Renderer>().material;*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonClicked()
    {
        /*StartCoroutine(FlashColor());
        //timeNow = Time.time;
        //keyMaterial.color = Color.green;
        //if (timeNow + 2 < Time.time)
        //{

        //}*/
    }

    IEnumerator FlashColor ()
    {
        //keyMaterial.color = Color.green;
        //keyRenderer.material.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        //keyMaterial.color = baseMaterial.color;
    }
}

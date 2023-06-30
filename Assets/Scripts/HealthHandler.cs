using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public int PlayerHealthPoints = 10;
    private int currentHealthBar = 9;
    public GameObject mainMenuCanvas;
    public StartGameAndReset mainMenuRestartBtn;
    public GameObject btnObject;

    public TMP_Text healthValue;

    public GameObject healthContainer;
    public List<GameObject> healthBars;

    // Start is called before the first frame update
    void Start()
    {
        healthValue.text = PlayerHealthPoints.ToString();

        //foreach (var item in healthContainer.GetComponentsInChildren<GameObject>())
        //{
        //    healthBars.Add(item);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DescraeseHealth()
    {
        healthBars[currentHealthBar].SetActive(false);
        PlayerHealthPoints -= 1;
        currentHealthBar -= 1;
        //healthValue.text = PlayerHealthPoints.ToString();
        if (PlayerHealthPoints <= 0)
        {
            mainMenuCanvas.SetActive(true);
            mainMenuRestartBtn.isFromRestart = true;
            btnObject.SetActive(true);
        }
    }

    public void ResetHealth()
    {
        PlayerHealthPoints = 10;
        currentHealthBar = 9;
        foreach (var item in healthBars)
        {
            item.SetActive(true);
        }
        //healthValue.text = PlayerHealthPoints.ToString();
    }
}

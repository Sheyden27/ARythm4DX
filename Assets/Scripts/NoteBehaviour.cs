using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    private ClickerKey clicker;

    public float noteSpeed = -0.5f;
    //private float multiplier = 120; // test env
    private float multiplier = 12000; // real
    private bool isAdvancing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

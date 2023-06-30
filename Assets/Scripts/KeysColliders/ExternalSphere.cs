using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalSphere : MonoBehaviour
{
    public ClickerKey clickerKey;

    private void Awake()
    {
        clickerKey = GetComponentInParent<ClickerKey>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        clickerKey.OnExternalSphereEntered(other);
    }
    private void OnTriggerExit(Collider other)
    {
        clickerKey.OnExternalSphereExited(other);
    }
}

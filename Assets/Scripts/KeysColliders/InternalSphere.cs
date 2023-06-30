using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalSphere : MonoBehaviour
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
        clickerKey.OnInternalSphereEntered(other);
    }
    private void OnTriggerExit(Collider other)
    {
        clickerKey.OnInternalSphereExited(other);
    }
}

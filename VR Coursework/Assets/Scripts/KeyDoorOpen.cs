using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyDoorOpen : MonoBehaviour
{
    public Animator animator;
    public string boolName = "isOpen";

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRSocketInteractor>().selectEntered.AddListener(x => ToggleDoorOpen());
    }

    public void ToggleDoorOpen()
    {
        bool isOpen = animator.GetBool(boolName);
        animator.SetBool(boolName, !isOpen);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

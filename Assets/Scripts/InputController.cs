using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public float HorizontalMouse { get; private set; }
    public float VerticalMouse { get; private set; }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        HorizontalMouse = Input.GetAxis("Mouse Y");
        VerticalMouse = Input.GetAxis("Mouse X");
    }
}

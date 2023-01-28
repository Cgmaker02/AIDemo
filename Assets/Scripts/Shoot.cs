using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private LayerMask _mask;

    public delegate void Die();
    public static event Die die;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray origin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            if(Physics.Raycast(origin, out hitInfo, _mask))
            {
                if (hitInfo.collider.name == "AIRobot(Clone)")
                {
                    Debug.Log("hit AI");
                    if (die != null)
                        die();
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraPosition : MonoBehaviour
{
    public Transform cameraTarget1;
    public Transform cameraTarget2;
    public Transform cameraTarget3;
    public float switchingSpeed = 10f;
    public Vector3 dist;
    Transform lookTarget;

    private int currentTarget;
    private Transform cameraTarget;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = 1;
        setCameraTarget(currentTarget);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>

    void Update() 
    {
            if (Input.GetKeyDown(KeyCode.V))
            {
                StartCoroutine(switchCamera());
                Debug.Log(currentTarget);
            }  

            if (currentTarget == 1)
            {
                lookTarget = GameObject.Find("FPPTarget").transform;
            }
             if (currentTarget == 2)
            {
                lookTarget = GameObject.Find("Pickup").transform;
            } 
            if (currentTarget == 3)
            {
                lookTarget = GameObject.Find("Terrain").transform;
            }

            Vector3 dPos = cameraTarget.position + dist;
            Vector3 sPos = Vector3.Lerp(transform.position, dPos, switchingSpeed * Time.deltaTime);
            transform.position = sPos;
            transform.LookAt(lookTarget.position);
    }

    public void setCameraTarget(int num)
    {
        switch(num)
        {
            case 1:
                cameraTarget = cameraTarget1.transform;
                break;
            case 2:
                cameraTarget = cameraTarget2.transform;
                break;
            case 3:
                cameraTarget = cameraTarget3.transform;
                break;
        }
    }

    IEnumerator switchCamera()
    {
        if (currentTarget < 3)
            currentTarget++;
        else
            currentTarget = 1;
            
        setCameraTarget(currentTarget);

        yield return null;
    }
}

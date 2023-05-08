using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    public GameObject bladeTrailPrefab;
    private GameObject currentBladeTrail;
    public float minCuttingVelocity = .001f;
    bool isSwiping = false;
    Rigidbody rb;
    Camera cam;
    BoxCollider boxCollider;

    Vector2 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        cam = Camera.main;
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);

            if (parmak.phase==TouchPhase.Stationary)
            {
                StartSwipe();
            }
            if (parmak.phase==TouchPhase.Moved)
            {
                Swiping();
            }
            if (parmak.phase==TouchPhase.Ended)
            {
                StopSwipe();
            }
        }
        
        if (isSwiping)
        {
            Swiping();
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartSwipe();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSwipe();
        }


    }
    void Swiping() {

        boxCollider.enabled = true;
    }
    void StartSwipe() 
    { 
        isSwiping = true;
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        boxCollider.enabled = false;
    }
    void StopSwipe() 
    { 
        
        isSwiping = false; 
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        boxCollider.enabled = false;
    }

    
}

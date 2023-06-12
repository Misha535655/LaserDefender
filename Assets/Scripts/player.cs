using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public float speedPlayer = 20f, paddingLeft, paddingRight, paddingTop, paddingBottom;
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;

    void Awake() {
        shooter = GetComponent<Shooter>();   
    }

    void Start() 
    {
        InitBounds();    
    }

    void Update()
    {
        Movie();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Movie()
    {
        Vector2 newPos = new Vector2();
        Vector3 delta = rawInput  * Time.deltaTime * speedPlayer;
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
        
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>(); 
    }
     
    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movment : MonoBehaviour
{


    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;

    private static GameObject Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = gameObject;
            DontDestroyOnLoad(gameObject);
        } 
        else
         {
             Destroy(gameObject);
         }
    }

    // Update is called once per frame
    void Update()
    {
        //Input movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //Input QuiteGame
       

    
    }


    void FixedUpdate()
    {
        //Movement
       rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IDataPersistence
{
    public GameData gd;
    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    // Update is called once per frame
    void Update(){
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        movement.Normalize();

            // Sprint
        if( Input.GetKey(KeyCode.LeftShift)){
            moveSpeed = 2f;
        } else{
            moveSpeed = 1f;
        }

                 // spend money for no reason
                 if( Input.GetKeyDown(KeyCode.Space))
           {
                gd.money -= 100;
                Debug.Log(" new balance = " + gd.money);
           }
      

           if( Input.GetKeyDown(KeyCode.Escape))
           {
            DataPersistenceManager.instance.SaveGame();

            SceneManager.LoadSceneAsync("GameLoader");
           }
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }
    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }

    void FixedUpdate() {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

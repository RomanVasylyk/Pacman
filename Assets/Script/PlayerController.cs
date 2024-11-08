using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class PlayerController : MonoBehaviour
{
    public int moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    public Animator myAnimator;
    private int smer = 1;
    public GameObject portal;

    void Start()
    {
    
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        rb2d.velocity = moveInput * moveSpeed;

        if (moveInput.x > 0)
        {
            myAnimator.Play("right");
            smer = 1;
        }
        else if (moveInput.x < 0)
        {
            myAnimator.Play("left");
            smer = -1;
        }

        if (moveInput.y > 0)
        {
            myAnimator.Play("top");
            smer = 1;
        }
        else if (moveInput.y < 0)
        {
            myAnimator.Play("down");
            smer = -1;
        }

        GameObject[] eats1 = GameObject.FindGameObjectsWithTag("eat1");
        GameObject[] eats2 = GameObject.FindGameObjectsWithTag("eat2");
        GameObject[] eats3 = GameObject.FindGameObjectsWithTag("eat3");

        GameObject[] allEats = eats1.Concat(eats2).Concat(eats3).ToArray();

        if (allEats.Length == 0)
        {
            GameObject[] mobs = GameObject.FindGameObjectsWithTag("mob");
            if (mobs.Length == 0)
            {
                portal.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("portal"))
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

int storedLevel = PlayerPrefs.GetInt("level", 0); 

if (storedLevel <= currentSceneIndex + 1)
{
    PlayerPrefs.SetInt("level", currentSceneIndex + 1);
    SceneManager.LoadScene(0); 
}else{
    SceneManager.LoadScene(0); 
}

    }
        if (other.gameObject.CompareTag("eat1"))
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("eat2"))
        {
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("eat3"))
        {
            transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
            
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("pronos"))
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            
            Destroy(other.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mob"))
        {
            Vector3 playerSize = transform.localScale;
            Vector3 mobSize = collision.transform.localScale;

            if (mobSize.x > playerSize.x && mobSize.y > playerSize.y)
            {
                Debug.Log("Player is eaten by the mob!");
                SceneManager.LoadScene(0);
            }
            else if (mobSize.x < playerSize.x && mobSize.y < playerSize.y)
            {
                transform.localScale += new Vector3(mobSize.x, mobSize.y, mobSize.z);
                Destroy(collision.gameObject);
            }
        }
        
    
    }

}

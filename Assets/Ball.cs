using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private bool Ispresed = false;
    public Rigidbody2D rb;
    public Rigidbody2D Hock;
    public float releasetime = .15f;
    public float maxDragdistance = 2f;
    public GameObject NextBall;
    void Update()
    {
        if (Ispresed)
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousepos, Hock.position) > maxDragdistance)
            {
                rb.position = Hock.position + (mousepos - Hock.position).normalized * maxDragdistance;
            }
            else
            {
                rb.position = mousepos;
            }
            
        }
    }
  
    void OnMouseDown()
    {
        Ispresed = true;
        rb.isKinematic = true;
    }
    void OnMouseUp()
    {
        Ispresed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    IEnumerator Release ()
    {
        yield return new WaitForSeconds(releasetime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(2f);
        if (NextBall != null)
        {
            NextBall.SetActive(true);
        }
        else
        {
            Enemy.EnemiAlive = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
     
    }
}

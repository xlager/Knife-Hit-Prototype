using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour {
    private bool onCircle = false;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (onCircle)
            return;
        /* tava tentando ajeitar as espadas que ficam tortas
        if (hitSword)
            Destroy(gameObject);
        */
        else if (collider.transform.tag == "circle")
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.transform.parent = collider.transform;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            onCircle = true;
            gameManager.scoreNum++;
            gameManager.circleLifeNum--;
        }
        else if (collider.transform.tag == "sword")
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.None;
            rb.gravityScale = 40;
            rb.AddTorque(5000);
        }
        else if (collider.transform.tag == "deathPannel")
        {
            gameManager.lifeNum--;
            Destroy(gameObject);
        }
    } 
}

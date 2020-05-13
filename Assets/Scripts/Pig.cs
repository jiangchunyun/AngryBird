using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float maxSpeed = 10;
    public float minSpeed = 5;
    private SpriteRenderer render;
    public Sprite sprite;
    public GameObject boom;
    public GameObject sorce;

    public bool isPig = false;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            if (isPig) {
                GameManager.instance.pigs.Remove(this);
            }
            Destroy(gameObject);
            Instantiate(boom,transform.position,Quaternion.identity);

            GameObject gm = Instantiate(sorce, transform.position+new Vector3(0,0.5f,0), Quaternion.identity);
            Destroy(gm, 1.5f);
        }
        else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed) {
            render.sprite = sprite;
        }
    }
}

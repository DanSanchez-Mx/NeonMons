using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicEnemie : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public float speed = .5f;

    private float waitTime;

    public Transform[] moveSpots;

    public float startWaitTime;

    private int i = 0;

    private Vector2 actualPos;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Linea para lograr rotar el objeto en cuestion
        transform.Rotate(new Vector3(0, 0, 1));

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < .1f)
        {

            if (waitTime <= 0)
            {

                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                waitTime = startWaitTime;
            }

            else
            {
                waitTime -= Time.deltaTime;
            }

        }
    }
}

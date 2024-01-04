using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConroller : MonoBehaviour
{
    // Variables del jugador
    public float runningSpeed = 5f;
    bool die;
    bool stop;

    private Rigidbody2D playerRigidBody;
    Animator animator;
    Vector3 startPosition;

    private const string STATE_ALIVE = "isAlive";

    public AudioClip dead;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
    }

    public void StartGame()
    {
        animator.SetBool(STATE_ALIVE, true);

        this.playerRigidBody.velocity = Vector2.zero;

        Invoke("RestartPosition", .1f);
    }

    public void RestartPosition()
    {
        this.transform.position = startPosition;

        // Esta linea es para que al momento de reiniciar el juego la velocidad vuelva a Cero
        this.playerRigidBody.velocity = Vector2.zero;

        // Esta linea sera para el barrido de la camara
        GameObject mainCamera = GameObject.Find("Main Camera");
        //mainCamera.GetComponent<CameraFollow>().ResetCameraPosition();
        // No es por nada estetico, simplemenete si el jugador a avanzado demasiado, le puede resultar molesto y contraprodusente el barrido en la camara
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchPressureSupported)
        {
            Flip();
        }

        if (Input.GetKey(KeyCode.W))
        {
            Flip();
        }

        Die();
    }

    private void FixedUpdate()
    {
        // Movimiento del jugador
        if (playerRigidBody.velocity.y < runningSpeed)
        {
            playerRigidBody.velocity = new Vector2(runningSpeed, runningSpeed);
            runningSpeed = (float)(runningSpeed + .01);
        }
    }

    void Flip()
    {
        if (playerRigidBody.velocity.y < runningSpeed)
        {
            playerRigidBody.velocity = new Vector2(-runningSpeed, runningSpeed);
        }

    }

    public void Die()
    {
        float travelledDistance = GetTravelDistance();

        if (die == true)
        {
            //animator.SetBool(STATE_ALIVE, false);
            SoundManager.Instance.EjecutarSonido(dead);
            GameManager.sharedInstance.gameOver();
            Destroy(gameObject);
        }
    }

    public void OnParticleSystemStopped()
    {
        if(stop == true)
        {
            playerRigidBody.velocity = new Vector2(-runningSpeed, -runningSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle" || collision.tag == "Enemie")
        {
            die = true;
        }
        else
        {
            die = false;
        }

        if (collision.tag == "Stop")
        {
            stop = true;
        }
        else
        {
            stop = false;
        }
    }

    // Sirve para el Score
    public float GetTravelDistance()
    {
        return this.transform.position.y - startPosition.y;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    GameObject firefly;
    GameObject gameManager;

    public float speedMovement = 1.5f;
    public float speedRun = 1f;

    public SpawnManager spawnManager;

    /*float currentTime = 0f;
    float startingTime = 10f;*/

    private Coroutine timer;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        FireflyInputs();
        transform.Translate(0f, 0f, speedRun * Time.deltaTime);
    }

    void FireflyInputs()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speedMovement * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speedMovement * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, speedMovement * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, -speedMovement * Time.deltaTime, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpawnTrigger")
        {
            spawnManager.SpawnTriggerEntered();
        }

        if (other.gameObject.tag == "Lucioles01")
        {
            Debug.Log("Luciole +20pts");
            gameManager.GetComponent<ScoringSystem>().score += 20;
            Destroy(other);
        }

        if (other.gameObject.tag == "Lucioles02")
        {
            Debug.Log("Luciole +30pts");
            gameManager.GetComponent<ScoringSystem>().score += 30;
            Destroy(other);
        }

        if (other.gameObject.tag == "Obstacles")
        {
            gameManager.GetComponent<ScoringSystem>().score -= 20;
        }

        if(other.gameObject.tag == "ItemsVitesse")
        {

        }
    }
}

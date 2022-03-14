using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private int Score = 0;
    public TextMeshProUGUI scoreText;
    private AudioSource Audio;
    public AudioClip Clip;
    private GameObject child;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Audio = GetComponent<AudioSource>();
        Clip = GetComponent<AudioClip>();
    }

    void Update()
    {
        //Audio Play
        Audio.PlayOneShot(Clip);
        //Projectile Motion
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddRelativeForce(0, 4f, 5f, ForceMode.Impulse);
            StartCoroutine(GravityUse());
            if (child != null)
            {
                child.transform.parent = null;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerRb.AddRelativeForce(5f, 0, 0, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerRb.AddRelativeForce(-5f, 0, 0, ForceMode.Impulse);
        }
    }
    //Gravity Enabled
    IEnumerator GravityUse()
    {
        yield return new WaitForSeconds(0.5f);
        playerRb.useGravity = true;
    }
    //Score Add
    private void AddScore(int ScoretoAdd)
    {
        Score += ScoretoAdd;
        Debug.Log("Score:" + Score);
        scoreText.text = "Score:  " + Score;
    }
    //Collision with Animal
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            AddScore(25);
            collision.gameObject.transform.parent = transform;
            child = collision.gameObject;
            child.GetComponent<Rigidbody>().isKinematic = true;
            transform.position = new Vector3(transform.position.x, 1.61f, transform.position.z);
            child.transform.position = new Vector3(transform.position.x, transform.position.y - 1.2f, transform.position.z);
        }
    }
}

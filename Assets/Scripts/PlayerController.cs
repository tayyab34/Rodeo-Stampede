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
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Audio = GetComponent<AudioSource>();
        Clip = GetComponent<AudioClip>();
    }

    void Update()
    {
        Audio.PlayOneShot(Clip);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddRelativeForce(0, 4f, 5f, ForceMode.Impulse);
            StartCoroutine(GravityUse());
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
    IEnumerator GravityUse()
    {
        yield return new WaitForSeconds(0.5f);
        playerRb.useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            playerRb.isKinematic = true;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            AddScore(25);
        }
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
    private void AddScore(int ScoretoAdd)
    {
        Score += ScoretoAdd;
        Debug.Log("Score:" + Score);
        scoreText.text = "Score:  " + Score;
    }
}

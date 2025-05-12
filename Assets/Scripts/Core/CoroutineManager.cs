using UnityEngine;
using System.Collections;

public class CoroutineManager : MonoBehaviour
{
    public static CoroutineManager Instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //get player's position 
        GameManager.Instance.playerCurrentPosition = GameManager.Instance.player.transform.position;

        //determine movement direction
        GameManager.Instance.playerMovementDirection = (GameManager.Instance.playerCurrentPosition - GameManager.Instance.playerLastPosition).normalized;

        //before moving to next frame, update last position to current;
        GameManager.Instance.playerLastPosition = GameManager.Instance.playerCurrentPosition;
    }

    public void Run(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}

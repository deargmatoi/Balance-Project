using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 10f;

    int timerCountdown = 0;
    private WaitForSeconds timerCounter = new WaitForSeconds(1f);
    public TMPro.TextMeshProUGUI timerText;
    private Coroutine timerCoroutine = null;

    Rigidbody2D rb;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timerCoroutine = StartCoroutine(Timer());


    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }


    IEnumerator Timer(){
        while(true){
            yield return timerCounter;
            timerCountdown++;
            timerText.text = timerCountdown.ToString();
        }
    }

    private void OnDisable(){
        if(timerCoroutine != null){
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }

}
 
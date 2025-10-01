using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    private float originY;
    private float targetY;

    private bool isOpening = false;
    private bool isClosing = false;
    private bool inRange = false;

    public GameObject UI_GO;
    private TextMeshProUGUI UIText;

    // Start is called before the first frame update
    void Start()
    {
        originY = transform.rotation.y;
        targetY = 0f;


        UIText = UI_GO.GetComponent<TextMeshProUGUI>();
        UI_GO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            if (transform.rotation.y == originY && !isOpening) isOpening = true;

            if (transform.rotation.y != originY && !isClosing) isClosing = true;
        }

        if (isOpening)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, originY + targetY, 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime * 10f);
            

            if (transform.rotation == targetRotation) isOpening = false;
        }

        if (isClosing)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, originY, 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime * 10f);
           

            if (transform.rotation == targetRotation) isClosing = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;

            UI_GO.SetActive(true);
            UIText.text = "Press (e) to open door";

            Vector3 lookDirection = transform.position - other.transform.position;
            float dotProduct = Vector3.Dot(transform.forward.normalized, lookDirection);

            //targetY = 90f;

            if (dotProduct > 0f && !isOpening) targetY = -90f;
            else if (dotProduct < 0f && !isOpening) targetY = 90f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
            UI_GO.SetActive(false);
            UIText.text = "test text";
        }
    }
}

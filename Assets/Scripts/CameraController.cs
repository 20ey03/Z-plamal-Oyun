using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float yakinlastir = 5f;
    private PlayerController playerController;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        GetComponent<Camera>().orthographicSize = yakinlastir;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y, -5f);

        if (Input.GetKey(KeyCode.Space))
        {
            yakinlastir = Mathf.Lerp(yakinlastir, 3f, Time.deltaTime * 2f);
        }
        else if (playerController.isGrounded == false)
        {
            yakinlastir = Mathf.Lerp(yakinlastir, 7f, Time.deltaTime * 2f);
        }
        else
        {
            yakinlastir = Mathf.Lerp(yakinlastir, 5f, Time.deltaTime * 2f);
        }

        GetComponent<Camera>().orthographicSize = yakinlastir;
        transform.position = new Vector3(pos.x, pos.y, -5f);
        }
    }

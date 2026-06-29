using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private float yakinlastir=10f;

    void Start()
    {
        GetComponent<Camera>().orthographicSize = yakinlastir;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y,-10f);
        
        if (Input.GetKey(KeyCode.Space))
        {
            yakinlastir = Mathf.Lerp(yakinlastir, 3f, Time.deltaTime*2f);
        }
        else
        {
            transform.position = new Vector3(pos.x, pos.y, -10f);
        }
    }
}

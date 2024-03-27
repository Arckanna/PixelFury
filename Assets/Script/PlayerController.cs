using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    public global::System.Single Speed { get => speed; set => speed = value; }


    // Update is called once per frame
    void Update()
    {
        Vector3 movementInput = new Vector3(Input.GetAxisRaw("Horizontal"),  Input.GetAxisRaw("Vertical"),0);
        movePlayer(movementInput);
    }

    void movePlayer(Vector3 direction)
    {
        transform.position += direction * Speed * Time.deltaTime;
    }
}

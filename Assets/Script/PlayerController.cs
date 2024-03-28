using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private Transform pointer;
    [SerializeField] private ProjectileController projectilePrefab;

    public global::System.Single Speed { get => speed; set => speed = value; }

    private Vector3 pointerDirection;
    private float pointerOffset;

    private void Start()
    {
        pointerOffset = (pointer.position - transform.position).magnitude;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 movementInput = new Vector3(Input.GetAxisRaw("Horizontal"),  Input.GetAxisRaw("Vertical"),0);
        movePlayer(movementInput);
        Pointer();

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void movePlayer(Vector3 direction)
    {
        transform.position += direction * Speed * Time.deltaTime;
    }

    private void Pointer()
    {
        pointerDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pointerDirection.z = 0;

        float angle = Mathf.Atan2(pointerDirection.y , pointerDirection.x ) * Mathf.Rad2Deg - 90;
        pointer.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        pointer.localPosition = pointerDirection.normalized * pointerOffset;
    }

    private void Shoot()
    {
        ProjectileController projectile = Instantiate(projectilePrefab, transform.position, pointer.rotation);
        projectile.SetDirection(pointerDirection.normalized);
    }
}

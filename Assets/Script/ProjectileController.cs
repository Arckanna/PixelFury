using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction;
    // Start is called before the first frame update
   public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}

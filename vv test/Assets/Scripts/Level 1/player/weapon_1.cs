using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_1 : MonoBehaviour
{

	public Transform firePoint;
	public GameObject bulletPrefab;
	public float fireRate;
	public float bulletSpeed;
	public float range;

	Vector2 direction;

	//private bool shooting;
	private float readyForNextShot;

    private void Start()
    {
		//shooting = false;
    }
    // Update is called once per frame
    void Update()
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		direction = mousePos - (Vector2)transform.position;
		faceMouse();

		if (Input.GetButton("Fire1"))
		{
			if(Time.time > readyForNextShot)
            {
				readyForNextShot = Time.time + 1/fireRate;
				Shoot();
			}
			
		}
			
	}

	void faceMouse()
	{
		transform.right = direction;
	}

	void Shoot()
	{
		GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		bulletInstance.GetComponent<Rigidbody2D>().AddForce(bulletInstance.transform.right * (bulletSpeed * 10));
		bulletInstance.GetComponent<bullet_1>().setRange(range);


	}


}
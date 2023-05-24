using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

	[SerializeField] GameObject fruitSlicedPrefab;
	[SerializeField] float startForce = 15f;

	Rigidbody2D rb2D;

	void Start ()
	{
		rb2D = GetComponent<Rigidbody2D>();
		rb2D.AddForce(transform.up * startForce, ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Blade")
		{
			Vector3 direction = (other.transform.position - transform.position).normalized;

			Quaternion rotation = Quaternion.LookRotation(direction);

			GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
			Destroy(slicedFruit, 3f);
			Destroy(gameObject);
		}
	}

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int Speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		winText.text = "";
		SetCountText ();
	}
	// Update is called once per frame
	void FixedUpdate () {
	
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * Speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
			{
				other.gameObject.SetActive(false);
				count = count + 1;
				SetCountText ();
			}

		if (count >= 6)
		{
			winText.text = "You Win!";
		}
	}
	void SetCountText()
	{
		countText.text = "Score: " + count.ToString ();
	}
}
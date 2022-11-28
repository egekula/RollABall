using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float speed;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private TextMeshProUGUI winText;
    private int _counter;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _counter = 0;
        SetCountText();
        winText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _rb.AddForce(movement*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            _counter += 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Coins: " + _counter.ToString();
        if (_counter >= 8)
        {
            winText.text = "You Win!";
        }
    }
}

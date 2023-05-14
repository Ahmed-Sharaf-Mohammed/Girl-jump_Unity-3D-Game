using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItamCollector : MonoBehaviour
{
    int coins = 0;
    [SerializeField] Text coinsText;
    [SerializeField] AudioSource CollectionSound;
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins;
            CollectionSound.Play();
        }
    }
}

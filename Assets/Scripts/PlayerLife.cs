using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource DeathSound;
    bool dead = false;
    Animator anim;
    private void Update()
    {
        anim = GetComponent<Animator>();
        if (transform.position.y < -1f && !dead)
        {

            Die();
        }
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }
    void Die()
    {
        anim.SetBool("die", true);
        Invoke(nameof(ReloadLevel), 2.3f);
        dead = true;
        DeathSound.Play();
        
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
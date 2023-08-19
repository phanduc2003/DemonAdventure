using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Moving : MonoBehaviour
{

    public Animator ani;
    public bool isRight = true;
    public bool blockGrass;
    public Rigidbody2D rigidbody;
    public GameObject panel, text, button, textEnd;
    int tong = 0;
    public TextMeshProUGUI textMP;

    //
    public GameObject PSBrick;
    //
    public AudioSource main, dead;

    // Start is called before the first frame update

    void SetScore(int score)
    {
        tong += score;
        textMP.text = "Your Point: " + tong;
    }
    void Start()
    {
        ani = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        textMP.text = "Your Point: " + 0;
        main.Play();
        dead.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //Khi nhân vật sang phải 
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            isRight = true;
            ani.SetBool("isRunning", true);
            transform.Translate(Time.deltaTime * 3, 0, 0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;
        }

        //Khi nhân vật sang trái
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            isRight = false;
            ani.SetBool("isRunning", true);
            transform.Translate(-Time.deltaTime * 3, 0, 0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;
        }

        //Khi nhân vật nhảy  
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (blockGrass == true)
            {
                if(isRight == true)
                {
                    rigidbody.AddForce(new Vector2(0, 300));
                    Vector2 scale = transform.localScale;
                    scale.x *= scale.x > 0 ? 1 : -1;
                    transform.localScale = scale;
                }
                else
                {
                    rigidbody.AddForce(new Vector2(0, 300));
                    Vector2 scale = transform.localScale;
                    scale.x *= scale.x > 0 ? -1 : 1;
                    transform.localScale = scale;
                }
                blockGrass = false;
            }
            
        }
    }
    //Gioi han do cao khi nhay
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "blockGrass")
        {
            blockGrass = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var name = collision.attachedRigidbody.gameObject.name;
        if (collision.gameObject.tag == "top")
        {
            // tieu diet NPC
            Destroy(GameObject.Find(name));
            SetScore(1);
        }
        if (collision.gameObject.tag == "coin")
        {
            // an dong xu 
            SetScore(1);
            Destroy(GameObject.Find(name));
            Instantiate(PSBrick, collision.gameObject.transform.position,
                                 collision.gameObject.transform.localRotation);
            
        }
        if (collision.gameObject.tag == "left")
        {
            // ket thuc man choi
            Time.timeScale = 0;
            panel.SetActive(true);
            button.SetActive(true);
            text.SetActive(true);
            dead.Play();
            main.Stop();
        }
        if (collision.gameObject.tag == "hetGame")
        {
            // ket thuc man choi
            Time.timeScale = 0;
            panel.SetActive(true);
            textEnd.SetActive(true);
            main.Stop();
        }
        if (collision.gameObject.tag == "traps")
        {
            // ket thuc man choi
            Time.timeScale = 0;
            panel.SetActive(true);
            button.SetActive(true);
            text.SetActive(true);
            dead.Play();
            main.Stop();
        }
        if (collision.gameObject.tag == "saw")
        {
            // ket thuc man choi
            Time.timeScale = 0;
            panel.SetActive(true);
            button.SetActive(true);
            text.SetActive(true);
            dead.Play();
            main.Stop();
        }
        if (collision.gameObject.tag == "congKhongGian")
        {
            SceneManager.LoadScene("Man2");
        }

    }

}

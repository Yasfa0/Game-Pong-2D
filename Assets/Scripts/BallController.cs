using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    public float force;
    private Rigidbody2D rigid;
    private int scoreP1,scoreP2;

    private TextMeshProUGUI textScore1;
    private TextMeshProUGUI textScore2;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);

        textScore1 = GameObject.Find("Score1").GetComponent<TextMeshProUGUI>();
        textScore2 = GameObject.Find("Score2").GetComponent<TextMeshProUGUI>();

        scoreP1 = 0;
        scoreP2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "TepiKanan")
        {
            scoreP1 += 1;
            TampilkanScore();
            ResetBall();
            Vector2 arah = new Vector2(2,0).normalized;
            rigid.AddForce(arah * force);
        }else if (collision.gameObject.name == "TepiKiri")
        {
            scoreP2 += 1;
            TampilkanScore();
            ResetBall();
            Vector2 arah = new Vector2(-2, 0).normalized;
            rigid.AddForce(arah * force);
        }else if (collision.gameObject.name == "Pemukul1" || collision.gameObject.name == "Pemukul2")
        {
            float sudut = (transform.position.y - collision.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(arah * force * 2);
        }
    }

    private void ResetBall()
    {
        transform.localPosition = Vector2.zero;
        rigid.velocity = Vector2.zero;
    }

    private void TampilkanScore()
    {
        textScore1.text = "P1 : " + scoreP1;
        textScore2.text = "P2 : " + scoreP2;

        if(scoreP1 >= 3)
        {
            FindObjectOfType<WinScript>().ShowWinner("One");
        }else if (scoreP2 >= 3)
        {
            FindObjectOfType<WinScript>().ShowWinner("Two");
        }
    }
}

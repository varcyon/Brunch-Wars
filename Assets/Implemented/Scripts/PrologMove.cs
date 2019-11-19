using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrologMove : MonoBehaviour
{
    [SerializeField] int speed = 2;
    float skipTime = 3f;
    float timer;
    [SerializeField] Image skipProgress;
    private void Start()
    {
        skipProgress.GetComponent<RectTransform>().localScale = new Vector3(0, 1, 1);
    }
    void Update()
    {
        gameObject.transform.Translate(0, Time.deltaTime * speed, 0, Space.World);

        if (gameObject.transform.position.y > 50f)
        {
            SceneManager.LoadScene("Level 1");
        }

        if (Input.GetKey(KeyCode.F))
        {
            skipProgress.GetComponent<RectTransform>().localScale += new Vector3(Time.deltaTime* 0.35f, 0, 0);
            timer += Time.deltaTime;
            if (timer >= skipTime)
            {
                SkipAhead();
            }
        }
        else
        {
            skipProgress.GetComponent<RectTransform>().localScale = new Vector3(0, 1, 1);
            timer = 0f;
        }
    }

    void SkipAhead()
    {
        SceneManager.LoadScene("Level 1");
    }
}

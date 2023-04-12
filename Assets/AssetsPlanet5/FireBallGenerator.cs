using System.Collections;
using UnityEngine;

public class FireBallGenerator : MonoBehaviour
{
    public GameObject fireBall;
    public int respawnTime = 1;

    private bool fireBallLaunched = false;
    public bool isFire = true;

    // Start is called before the first frame update
    public void fireBallLaunch()
    {
        if (!fireBallLaunched)
            StartCoroutine(fireBallWave());
        fireBallLaunched = true;
    }

    private void spwanFireBall()
    {
        Vector3 position = new Vector3(Random.Range(290, 294.2f), 65.3f, Random.Range(288.5f, 282.7f));
        GameObject ball = Instantiate(fireBall, position, transform.rotation);  
    }

    IEnumerator fireBallWave()
    {
        while (isFire)
        {
            spwanFireBall();
            yield return new WaitForSeconds(respawnTime);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

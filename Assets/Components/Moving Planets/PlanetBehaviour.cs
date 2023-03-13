using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetBehaviour : MonoBehaviour
{
    private float speed;
    private float travelDistance;
    
    private void Start()
    {
        travelDistance = 0;
        float size = Random.Range(3, 8);
        speed = Random.Range((3 * 70)/size, (4 * 70)/size);
        transform.localScale = new Vector3(size, size, size);
    }

    private void LateUpdate()
    {
        travelDistance += Time.deltaTime * speed;
        transform.position += Time.deltaTime * speed * Vector3.left;
        if(travelDistance > 1000) Destroy(gameObject);
    }
}

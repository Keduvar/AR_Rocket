using UnityEngine;

public class RocketCollisionHandler : MonoBehaviour
{
    public GameObject rocketStagePrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ObjectToPlace"))
        {
            Collider col1 = GetComponent<Collider>();
            Collider col2 = other.gameObject.GetComponent<Collider>();

            if (col1 != null && col2 != null)
            {
                float distance = Vector3.Distance(transform.position, other.transform.position);

                float mergeDistance = 0.5f;
                if (distance < mergeDistance)
                {
                    MergeObjects(col1, col2);
                }
            }
        }
    }

    private void MergeObjects(Collider col1, Collider col2)
    {
        Vector3 newPosition = (col1.transform.position + col2.transform.position) / 2f;

        GameObject newObject = Instantiate(rocketStagePrefab, newPosition, Quaternion.identity);

        Destroy(col1.gameObject);
        Destroy(col2.gameObject);
    }
}
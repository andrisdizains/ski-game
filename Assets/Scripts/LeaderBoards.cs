using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoards : MonoBehaviour
{
    [SerializeField] private List<float> results = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            results.Add(999999);
        }
    }
    public void AddResult(float time)
    {
        results.Add(time);
        results.Sort();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

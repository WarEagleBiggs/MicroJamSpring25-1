using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class King : MonoBehaviour
{
    public GameObject room;
    public Transform pivot;
    public List<Transform> spawnPos;
    public int ranSpot;
    public TextMeshProUGUI score;
    public int activeScore;
    public VolumeProfile vol;
    public GameObject obs;

    private ColorAdjustments colorAdjustments;
    private float hueSpeed = 30f; // Adjust this to control hue transition speed
    private float hueValue = -180f; // Start hue shift at -180

    void Start()
    {
        // Try to get the ColorAdjustments component from the VolumeProfile
        if (vol.TryGet(out colorAdjustments))
        {
            Debug.Log("ColorAdjustments component found in VolumeProfile.");
        }
        else
        {
            Debug.LogError("ColorAdjustments component missing from VolumeProfile.");
        }

        StartCoroutine(Increment());

        // Start multiple spawn coroutines as in the original code
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
        StartCoroutine(Spawn());
    }

    void Update()
    {
        // Smoothly transition the hue shift over time
        if (colorAdjustments != null)
        {
            hueValue += hueSpeed * Time.deltaTime; // Increment hue based on time
            if (hueValue > 180f) hueValue = -180f; // Loop hue back when it exceeds 180

            colorAdjustments.hueShift.value = hueValue;
        }

        score.SetText(activeScore.ToString());

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            room.transform.RotateAround(pivot.position, Vector3.forward, 90f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            room.transform.RotateAround(pivot.position, Vector3.forward, -90f);
        }
    }

    public IEnumerator Increment()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            activeScore++;
        }
    }

    public IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            ranSpot = Random.Range(0, 40);
            GameObject obj2 = Instantiate(obs);
            obj2.transform.position = spawnPos[ranSpot].position;
            obj2.transform.parent = obs.transform.parent;
            obj2.SetActive(true);
        }
    }
}

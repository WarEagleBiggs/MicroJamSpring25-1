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
        StartCoroutine(ChangeHue()); // Start hue change coroutine

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

    public IEnumerator ChangeHue()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f); // Change hue every 0.5 seconds

            if (colorAdjustments != null)
            {
                float ranNum = Random.Range(-180f, 180f); // Hue shift range is -180 to 180
                colorAdjustments.hueShift.value = ranNum;
            }
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

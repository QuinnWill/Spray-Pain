using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarPaint : ASpraypaint
{


    public Dictionary<Vector2, GameObject> walls;

    public float spawnRadius = 1;

    public List<Vector2> keys;
    public List<GameObject> values;

    protected Vector2 aimDirection;

    

    protected override void OnEnable()
    {
        base.OnEnable();
        InputManager.aim += AimInput;
        InputManager.useStart += Activate;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        InputManager.aim -= AimInput;
        InputManager.useStart -= Activate;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        /*for (int i = 0; i < keys.Count; i++)
        {
            walls.Add(keys[i], values[i]);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void AimInput(Vector2 input)
    {
        aimDirection = Camera.main.ScreenToWorldPoint(input) - transform.position;
    }

    protected override void Activate()
    {

        if (!active)
        {
            Deactivate();
            return;
        }

        Debug.Log(aimDirection);

        Vector2 key1 = Vector2.zero;
        Vector2 key2 = Vector2.zero;

        float angle1 = 1000;
        float angle2 = 1000;

        foreach (Vector2 dir in keys)
        {
            float directionAngle = Vector2.Angle(dir, aimDirection);
            if (directionAngle < angle1)
            {
                key2 = key1;
                key1 = dir;
                angle2 = angle1;
                angle1 = directionAngle;
            }
            else if (directionAngle < angle2)
            {
                key2 = dir;
                angle2 = directionAngle;
            }
        }

        GameObject wall1 = Instantiate(values[keys.IndexOf(key1)]);
        key1.Normalize();
        wall1.transform.position = transform.position + new Vector3(key1.x, key1.y * 0.8f) * spawnRadius;
        GameObject wall2 = Instantiate(values[keys.IndexOf(key2)]);
        key2.Normalize();
        wall2.transform.position = transform.position + new Vector3(key2.x, key2.y * 0.8f) * spawnRadius;
    }

    protected override void Deactivate()
    {

    }
}

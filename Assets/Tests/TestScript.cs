using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    private GameObject _gameGO;

    [SetUp]
    public void Setup()
    {
        _gameGO = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameWorld"), Vector3.zero, Quaternion.identity);
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_gameGO);
    }

    [UnityTest]
    public IEnumerator MarblesAboveDeathZone()
    {
        Rigidbody marble = MonoBehaviour.FindObjectOfType<Rigidbody>();

        yield return new WaitForSeconds(5f);

        Assert.Greater(marble.transform.position.y, -20f);
    }

    [UnityTest]
    public IEnumerator MarbleFalls()
    {
        Rigidbody marble = MonoBehaviour.FindObjectOfType<Rigidbody>();
        float yPos = marble.transform.position.y;
        yield return new WaitForSeconds(0.1f);
        Assert.Less(marble.transform.position.y, yPos);
    }
}

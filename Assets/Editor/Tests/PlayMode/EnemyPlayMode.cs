using System.Collections;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyPlayMode
{


    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestTakeOneDamage()
    {
        // Arrange
        var gameObject = new GameObject();
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
        Enemy enemy = gameObject.AddComponent<Enemy>();
        enemy.col = new Gradient();
        // enemy.sr = sr;

        yield return null;
        // Act
        enemy.Damage(1);
        // Assert
        Assert.AreEqual(9, enemy.Health);

        // cleanup
        Object.Destroy(gameObject);

    }

    [UnityTest]
    public IEnumerator TestDie()
    {
        // Arrange
        var gameObject = new GameObject();
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
        Enemy enemy = gameObject.AddComponent<Enemy>();
        enemy.col = new Gradient();
        // enemy.sr = sr;

        yield return null;
        // Act
        enemy.Damage(10);
        // Assert
        Assert.AreEqual(0, enemy.Health);
        Assert.AreEqual(true, enemy.IsDead); 

        // cleanup
        Object.Destroy(gameObject);

    }
}

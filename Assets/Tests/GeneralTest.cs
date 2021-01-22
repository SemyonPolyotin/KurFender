using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Enemies;
using Game.Level;
using Game.Player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class GeneralTest
    {
        [UnityTest]
        public IEnumerator DamageReceiveByPlayer()
        {
            // Arrange
            SceneManager.LoadScene("DemoScene");
            yield return new WaitForSeconds(0.1f);
            var player = GameObject.FindObjectOfType<PlayerController>();
            var enemy = GameObject.FindObjectsOfType<EnemyController>()
                .First(e => e.GetType() != typeof(BeeController));
            var defaultSpValue = player.PlayerModel.SpValue;
            // Act
            enemy.transform.position = player.transform.position;
            yield return new WaitForSeconds(1f);
            // Assert
            Assert.Less(player.PlayerModel.SpValue, defaultSpValue);
        }

        [UnityTest]
        public IEnumerator CoinCollectedByPlayer()
        {
            // Arrange
            SceneManager.LoadScene("DemoScene");
            yield return new WaitForSeconds(0.1f);
            var player = GameObject.FindObjectOfType<PlayerController>();
            var coin = GameObject.FindObjectOfType<CoinController>();
            var defaultCoinValue = player.PlayerModel.CoinValue;
            // Act
            coin.transform.position = player.transform.position;
            yield return new WaitForSeconds(0.1f);
            // Assert
            Assert.Less(defaultCoinValue, player.PlayerModel.CoinValue);
        }

        [UnityTest]
        public IEnumerator CoinDestroyedOnCollection()
        {
            // Arrange
            SceneManager.LoadScene("DemoScene");
            yield return new WaitForSeconds(0.1f);
            var player = GameObject.FindObjectOfType<PlayerController>();
            var coin = GameObject.FindObjectOfType<CoinController>();
            // Act
            coin.transform.position = player.transform.position;
            yield return new WaitForSeconds(0.5f);
            // Assert
            UnityEngine.Assertions.Assert.IsNull(coin);
        }
    }
}
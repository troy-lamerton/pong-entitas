using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreSystem : IExecuteSystem, ICleanupSystem {

	readonly GameContext _context;
	readonly IGroup<GameEntity> _group;
	readonly List<Text> _scoreTexts = new List<Text>();

	public UpdateScoreSystem (Contexts contexts) {
		_context = contexts.game;
		_group = contexts.game.GetGroup (GameMatcher.ChangeScore);

		GameObject[] scoreGameObjects = new GameObject[] {
			GameObject.Find ("ScoreNumberPlayer"),
			GameObject.Find ("ScoreNumberOpponent")
		};
		foreach (GameObject go in scoreGameObjects) {
			if (go == null) {
				Debug.LogError ("Score gameObject for player or opponent not found");
			}
			else if (go.GetComponent<Text> () == null) {
				Debug.LogError ("Score gameObject does not have a 'Text' unity UI component");
			}
			else {
				_scoreTexts.Add (go.GetComponent<Text> ());
			}
		}
	}
	
	public bool Filter(GameEntity e) {
		return e.hasChangeScore;
	}

	public void Execute() {
		GameEntity _scoresEntity = _context.scoresEntity;

		if (_scoresEntity != null) {
			foreach (GameEntity e in _group.GetEntities()) {
				int ownerId = e.changeScore.scoreOwnerId;
				int changeValue = e.changeScore.changeValue;
				if (changeValue == 0) {
					_scoresEntity.scores.scores [ownerId] = 0;
				}
				else {
					_scoresEntity.scores.scores [ownerId] += changeValue;
				}
				int updatedScore = _scoresEntity.scores.scores [ownerId];
				_scoreTexts [ownerId].text = updatedScore.ToString();
				Debug.Log ("we updated- " + _scoreTexts [ownerId].text);
			}
		}
		else {
			Debug.LogError ("Oh crap _scoresEntity is null");
		}
	}

	public void Cleanup() {
		foreach(var e in _group.GetEntities()) {
			_context.DestroyEntity (e);
		}
	}
}

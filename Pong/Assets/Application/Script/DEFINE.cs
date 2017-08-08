using System.Collections;

public static class DEFINE {

	public const int GAME_MATCH_POINT = 3;

	public const string SCENE_TITLE 		= "TitleScene";
	public const string SCENE_PONG_GAME 	= "GameScene";
    public const string SCENE_RESULT        = "ResultScene";

    public const string PREFAB_PATH_BALL 	= "Prefabs/PongGame/ball";
	public const string PREFAB_PATH_HISTORY_PANEL = "Prefabs/PongGame/HistoryPanel";

	public const int GOAL_SCORE = 100;				// ゴールした時のスコア
	public const int WALL_SCORE = 20;				// ゴールした時の壁追加スコア
	public const int MAX_SCORE = 1000;               // スコアの最大値

	public const float PLAYER_MOVE_MAX = 27.0f;        // プレイヤーの移動最大値
	public const float PLAYER_ANGLE = 22.0f;           // プレイヤーの角度
	public const float BALL_SPEED_UP = 1.3f;           // ボール加速量

	public const int MOVE_COUNT_MAX = 5;            // 移動カウンタ最大値
	public const int GAME_SET_COUNT = 180;			// ゲーム終了カウンタ
}

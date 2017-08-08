using System.Collections;

public static class DEFINE {

	public const int GAME_MATCH_POINT = 3;

	public const string SCENE_TITLE 		= "TitleScene";
	public const string SCENE_PONG_GAME 	= "GameScene";
    public const string SCENE_RESULT        = "ResultScene";

    public const string PREFAB_PATH_BALL 	= "Prefabs/PongGame/ball";
	public const string PREFAB_PATH_HISTORY_PANEL = "Prefabs/PongGame/HistoryPanel";

	public const int GOAL_SCORE = 100;				// �S�[���������̃X�R�A
	public const int WALL_SCORE = 20;				// �S�[���������̕ǒǉ��X�R�A
	public const int MAX_SCORE = 1000;               // �X�R�A�̍ő�l

	public const float PLAYER_MOVE_MAX = 27.0f;        // �v���C���[�̈ړ��ő�l
	public const float PLAYER_ANGLE = 22.0f;           // �v���C���[�̊p�x
	public const float BALL_SPEED_UP = 1.3f;           // �{�[��������

	public const int MOVE_COUNT_MAX = 5;            // �ړ��J�E���^�ő�l
	public const int GAME_SET_COUNT = 180;			// �Q�[���I���J�E���^
}

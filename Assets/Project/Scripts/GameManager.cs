using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool[,] panelState = new bool[3, 3];

    public void RegisterHit(int x, int y)
    {
        panelState[x, y] = true;
        if (CheckBingo())
        {
            Debug.Log("🎉 ビンゴ！ゲーム終了");
            // 必要なら、ゲーム停止処理やエフェクト追加
        }
    }

    private bool CheckBingo()
    {
        // 横
        for (int y = 0; y < 3; y++)
            if (panelState[0, y] && panelState[1, y] && panelState[2, y]) return true;

        // 縦
        for (int x = 0; x < 3; x++)
            if (panelState[x, 0] && panelState[x, 1] && panelState[x, 2]) return true;

        // 斜め
        if (panelState[0, 0] && panelState[1, 1] && panelState[2, 2]) return true;
        if (panelState[2, 0] && panelState[1, 1] && panelState[0, 2]) return true;

        return false;
    }
}

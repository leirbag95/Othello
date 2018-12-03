using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{

    //MARK: public var
    public Sprite knob;
    public Image roundSprite;
    public GameObject Places;
    public Text scoreIA, scorePlayer;
    public GameObject GameFinishPanel;
    public Text WinnerText;
    public Button[] arrayPawn;

    //MARK:
    private int pawnNumber = 4;

    public int[,] board = new int[8, 8]
       {{-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1}};

    //MARK: private var
    private int round = 0;

    // Use this for initialization
    void Start()
    {
        /*Start Settings*/
        board[3, 3] = 0;
        board[4, 4] = 0;
        board[3, 4] = 1;
        board[4, 3] = 1;


        scoreIA.text = getIAScore().ToString();
        int pScore = Math.Abs(pawnNumber - getIAScore());
        scorePlayer.text = pScore.ToString();


        boardUpdate();
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void showPawn(Button button)
    {
        int index = Int32.Parse(button.name.ToString());

        int y = index / 8;
        int x = index % 8;

        if (board[x, y] == -1)
        {
            int pawn;
            if (round == 0)
            {
                pawn = 1;
            }
            else
            {
                pawn = 0;
            }
            if (canPutPawn(x, y, pawn) && roundBoardUpdate(round, x, y))
            {
                board[x, y] = round;
                pawnNumber += 1;

                if (isRoundChange(pawn))
                {
                    round = pawn;

                    if (round == 0)
                    {
                        roundSprite.color = Color.white;
                    }
                    else
                    {
                        roundSprite.color = Color.black;
                    }

                }
                scoreIA.text = getIAScore().ToString();
                boardUpdate();
                int pScore = Math.Abs(pawnNumber - getIAScore());
                scorePlayer.text = pScore.ToString();

                if (isGameEnding() || !isRoundChange(round))
                {
                    GameFinishPanel.SetActive(true);
                    int whitePawn = getIAScore();
                    int blackPawn = pawnNumber - whitePawn;
                    if (whitePawn > blackPawn)
                    {
                        WinnerText.text = "White Pawn is the winner";
                    }
                    else if (blackPawn > whitePawn)
                    {
                        WinnerText.text = "Black Pawn is the winner";
                    }
                    else
                    {
                        WinnerText.text = "Equality!!";
                    }
                }
            }
        }

    }

    //MARK : private func


    private int getIAScore()
    {
        int iaScore = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board[j, i] == 0)
                {
                    iaScore++;
                }
            }
        }
        return iaScore;
    }

    private bool canPutPawn(int x, int y, int pawn)
    {
        if (x == 0)
        {
            if (y == 0)
            {
                return board[x + 1, y] == pawn || board[x, y + 1] == pawn || board[x + 1, y + 1] == pawn;
            }
            if (y == 7)
            {
                return board[x + 1, y] == pawn || board[x, y - 1] == pawn || board[x + 1, y - 1] == pawn;
            }
            return board[x + 1, y] == pawn || board[x, y - 1] == pawn
                || board[x, y + 1] == pawn
                || board[x + 1, y - 1] == pawn
                || board[x + 1, y + 1] == pawn;
        }
        if (y == 0)
        {

            if (x == 7)
            {
                return board[x - 1, y] == pawn || board[x, y + 1] == pawn || board[x - 1, y + 1] == pawn;
            }
            return board[x - 1, y] == pawn || board[x - 1, y + 1] == pawn || board[x, y + 1] == pawn
                || board[x + 1, y] == pawn
                || board[x + 1, y + 1] == pawn;
        }

        if (x == 7)
        {
            if (y == 7)
            {
                return board[x - 1, y] == pawn || board[x, y - 1] == pawn || board[x - 1, y - 1] == pawn;
            }
            return board[x, y - 1] == pawn || board[x - 1, y - 1] == pawn || board[x - 1, y] == pawn
                || board[x - 1, y + 1] == pawn
                || board[x, y + 1] == pawn;
        }

        if (y == 7)
        {

            return board[x - 1, y] == pawn
                || board[x - 1, y - 1] == pawn
                || board[x, y - 1] == pawn
                || board[x + 1, y - 1] == pawn
                || board[x + 1, y] == pawn;
        }
        return board[x + 1, y] == pawn
            || board[x, y + 1] == pawn
            || board[x + 1, y + 1] == pawn
            || board[x, y - 1] == pawn
            || board[x - 1, y] == pawn
            || board[x - 1, y - 1] == pawn
            || board[x + 1, y - 1] == pawn
            || board[x - 1, y + 1] == pawn;
    }

    private bool roundBoardUpdate(int r, int x, int y, bool isForChecking = false)
    {

        int[,] boardTmp = new int[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                boardTmp[j, i] = board[j, i];
            }
        }

        /*Right Horizontal*/
        for (int i = x + 1; i < 8; i++)
        {
            if (board[i, y] == -1) break;
            if (board[i, y] == r)
            {
                for (int j = x; j < i; j++)
                {
                    board[j, y] = r;
                }
                break;
            }
        }
        /*Left Horizontal*/
        for (int i = x - 1; i >= 0; i--)
        {
            if (board[i, y] == -1) break;
            if (board[i, y] == r)
            {
                for (int j = x; j > i; j--)
                {
                    board[j, y] = r;
                }
                break;
            }

        }

        for (int i = y - 1; i >= 0; i--)
        {
            if (board[x, i] == -1) break;
            if (board[x, i] == r)
            {
                for (int j = y; j > i; j--)
                {
                    board[x, j] = r;
                }
                break;
            }
        }

        for (int i = y + 1; i < 8; i++)
        {
            if (board[x, i] == -1) break;
            if (board[x, i] == r)
            {
                for (int j = y; j < i; j++)
                {
                    board[x, j] = r;
                }
                break;
            }
        }

        //diagonal x + i ; y+i

        for (int i = 1; x + i < 8 && y + i < 8; i++)
        {
            if (board[x + i, y + i] == r)
            {
                for (int j = 1; x + j < 8 && y + j < 8 && board[x + j, y + j] != r && board[x + j, y + j] != -1; j++)
                {
                    board[x + j, y + j] = r;
                }
                break;
            }
        }

        //diagonal x + i ; y - i

        for (int i = 1; x + i < 8 && y - i >= 0; i++)
        {
            if (board[x + i, y - i] == r)
            {
                for (int j = 1; x + j < 8 && y - j >= 0 && (board[x + j, y - j] != r && board[x + j, y - j] != -1); j++)
                {
                    board[x + j, y - j] = r;
                }
                break;
            }
        }

        //diagonal x - i ; y - i

        for (int i = 1; x - i > 0 && y - i >= 0; i++)
        {
            if (board[x - i, y - i] == r)
            {
                for (int j = 1; x - j >= 0 && y - j >= 0 && (board[x - j, y - j] != r && board[x - j, y - j] != -1); j++)
                {
                    board[x - j, y - j] = r;
                }
                break;
            }
        }

        //diagonal x - i ; y + i

        for (int i = 1; x - i >= 0 && y + i < 8; i++)
        {
            if (board[x - i, y + i] == r)
            {
                for (int j = 1; x - j >= 0 && y + j < 8 && (board[x - j, y + j] != r && board[x - j, y + j] != -1); j++)
                {
                    board[x - j, y + j] = r;
                }
                break;
            }
        }


        //We checked if board changed 
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (j != x || i != y)
                {
                    if (board[j, i] != boardTmp[j, i])
                    {
                        if (isForChecking) board = boardTmp;
                        return true;
                    }
                }
            }
        }
        board = boardTmp;
        return false;
    }

    private void displayboard(int[,] b)
    {
        string tmp = "";
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                tmp += b[j, i] + " ";
            }
            tmp += "\n";
        }
        Debug.Log(tmp);
    }

    private bool isGameEnding()
    {
        return isTherePlaces() || isOnlyOnePawn();
    }

    private bool isTherePlaces()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board[j, i] == -1)
                    return false;
            }
        }
        return true;
    }

    private bool isOnlyOnePawn()
    {
        int whitePawn = getIAScore();
        int blackPawn = pawnNumber - whitePawn;
        return whitePawn == 0 || blackPawn == 0;
    }


    private bool isRoundChange(int r)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            { 
                if (board[j, i] == -1 && roundBoardUpdate(r, j, i, true))
                    return true;
            }
        }
        return false;
    }


    private void boardUpdate() 
    {
        
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board[j, i] == 0)
                {
                    int index = i * 8 + j;
                    arrayPawn[index].image.sprite = knob;
                    arrayPawn[index].image.color = Color.white;
                }
                if (board[j,i] == 1)
                {
                    int index = i * 8 + j;
                    arrayPawn[index].image.sprite = knob;
                    arrayPawn[index].image.color = Color.black;
                }
            }
        }
    }
}

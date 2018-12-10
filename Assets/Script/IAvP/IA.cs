using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA
{

    //MARK: PUBLIC 

    public int[,] board = new int[8, 8]
        {{-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1}};

    public List<int> aStarList = new List<int>();
    public List<int> listOfPossibilities = new List<int>();


    //MARK: RANDOM AI

    public int GetAllPossibilities(int[,] board, bool forMinMax = false)
    {
        listOfPossibilities = new List<int>();
        if (!forMinMax) {
            aStarList = new List<int>();
        }

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {

                if (canPutPawn(j, i, 0) &&  board[j, i] == -1 && roundBoardUpdate(1, j, i, true) )
                {
                    int coordinates = i * 8 + j;
                    Debug.Log(coordinates);
                    listOfPossibilities.Add(coordinates);
                }
            }
        }

        int count = listOfPossibilities.Count; 
        if (count > 0)
        {
            int rand = UnityEngine.Random.Range(0, listOfPossibilities.Count - 1);
            return listOfPossibilities[rand];
        }

        return -1;
    }


    //MARK: A* (A STAR) AI

    public int aStarAI() {
        int possibilities = GetAllPossibilities(board);
        int max = 0;
        int index = -1;
        for (int i = 0; i < aStarList.Count; i++) 
        {
            if (aStarList[i] > max)
            {
                max = aStarList[i];
                index = i;
            }
        }
        if (index != -1) return listOfPossibilities[index];
        return index;
    }

    //MARK: GET NUMBER OF `AI PAWN`

    public int getNumberOfPawn() {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board[j,i] == 1) {
                    count += 1;
                }
            }
        }
        return count;
    }

    //MARK : CHECKING FUNCTION

    public bool canPutPawn(int x, int y, int pawn)
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

    //
    public bool roundBoardUpdate(int r, int x, int y, bool isForChecking = false)
    {

        int[,] boardTmp = new int[8, 8];
        /*Init of boardTmp*/
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

                        if (isForChecking)
                        {
                            aStarList.Add(getNumberOfPawn());
                            board = boardTmp;
                        }
                        return true;
                    }
                }
            }
        }
        board = boardTmp;
        return false;
    }

}

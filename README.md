# Othello
___


**Othello** (Reversi) is a strategy board game for two players,played on an 8×8 uncheckered board. There are sixty-four identical game pieces called _disks_ (often spelled "discs"), which are light on one side and dark on the other. Players take turns placing disks on the board with their assigned color facing up. During a play, any disks of the opponent's color that are in a straight line and bounded by the disk just placed and another disk of the current player's color are turned over to the current player's color.

Through this project, you can play against another player (like your sister or your uncle) and against a robot (artificial intelligence)

# Rules
Each reversi piece has a black side and a white side. On your turn, you place one piece on the board with your color facing up. You must place the piece so that an opponent's piece, or a row of opponent's pieces, is flanked by your pieces. All of the opponent's pieces between your pieces are then turned over to become your color. 

# Aim of the games
The object of the game is to own more pieces than your opponent when the game is over. The game is over when neither player has a move. Usually, this means the board is full. 

# Start of the game 
The game is started in the position shown below on a reversi board consisting of 64 squares in an 8x8 grid.
![http://www.flyordie.com/games/help/reversi/images/reversi-board.gif](http://www.flyordie.com/games/help/reversi/images/reversi-board.gif)

# How to play ?

## Play Online

For try Othello Game you can click on [this link !](https://othello-esilv.firebaseapp.com)

## Play Offline

### Mac OS
For playing on MacOS is to download the build `Othello For Mac` and  run it.

### Windows
For playing on MacOS is to download the .exe `Othello For Windows` and  run it.

### Build the project
If you want to custom the project you need to download the entire project.


Enter this command in your terminal
```sh
git clone https://github.com/leirbag95/Othello.git

```





# GamePlay
- Pvp

![2nynhk](https://user-images.githubusercontent.com/17054452/49338383-ac9a9b80-f620-11e8-8e95-b85afc746bc5.gif)

- PvAI: Easy

![2ov2u7](https://user-images.githubusercontent.com/17054452/49927668-c0ff5380-febe-11e8-92bb-e541c5e210e4.gif)

#### Algorithm

At each round, append position of all possibilities in a list ``` L ```
For example at the first round, ```L ``` will be
```
L = [26, 42, 44]
```
Then we take a random element in this list.

- PvAI: Medium

![2ov2yb](https://user-images.githubusercontent.com/17054452/49927785-0faced80-febf-11e8-8d40-7bfd2560aba4.gif)


#### Algorithm

At each round, append position of all possibilities in a list ``` L ```
For example at the first round, ```L ``` will be
```
L = [26, 42, 44]
```
Then We take the element that will win the most pawn at the next round

- PvAI: Hard
### Algorithm
For this part, I choose : ``` MinMax Algorithm```.

Minimax is a decision rule used in artificial intelligence, decision theory, game theory, statistics and philosophy for minimizing the possible loss for a worst case (maximum loss) scenario. When dealing with gains, it is referred to as "maximin"—to maximize the minimum gain. Originally formulated for two-player zero-sum game theory, covering both the cases where players take alternate moves and those where they make simultaneous moves, it has also been extended to more complex games and to general decision-making in the presence of uncertainty.

![https://upload.wikimedia.org/wikipedia/commons/e/e1/Plminmax.gif](https://upload.wikimedia.org/wikipedia/commons/e/e1/Plminmax.gif)

# ConnectFourBot
This is my iplementation of an AI, which plays Connect four.

This bot is used to compete in the The AI Games(http://theaigames.com/).

Big thanks to suwik, for providing the base engine in C#;

#Rules
The rules for Four in a Row are simple. The field (board) has seven columns and six rows. Two players play by alternately dropping a chip down one of the columns. 
The chip drops to the lowest unoccupied spot in that column. The first player to get four of his own chips in a row, either vertical, horizontal, or diagonal, wins. 
The game ends in a draw if it fills before someone wins.

#Technical Details

You get an initial maximally filled timebank of 10 seconds and each time a move is requested 500ms will be added to your timebank. 
The engine will give the amount of time left in your timebank each time it asks your bot for a move. If your bot does not respond before the timeout, 
the engine will ask again for a move. If it doesn't respond twice, your bot will be shut down. 
Bots that do not output anything at all, a.k.a. fail their input test, can not be placed in the ranked matches.

%Knowledge Base 1 (kbl.pl)

%Facts
girl(lily).
girl(alice).
girl(emma).
can_cook(lily).

%Facts
sing_a_song(merry).
listens_to_music(bob).

%Rules
listens_to_music(merry) :- sing_a_song(merry).
happy(merry) :- sing_a_song(merry).
happy(bob) :- listens_to_music(bob).
plays_guitar(bob) :- listens_to_music(bob).

%to check knowledge base you do kbl. and if it returns true then it compiles

parent(mark, jason).
parent(mark, paul).
male(jason).
male(paul).

brother(X, Y) :- parent(Z,X), parent(Z,Y), male(X), male(Y), X\==Y
%to compile use [filename]. in swiprolog
%press semi colon to get more answers in swiprolog if there's more than one relationship
%by using trace. you can track what swiprolog's logical process of a request. kinda like a debugger
%go over recursive relationships in swiprolog
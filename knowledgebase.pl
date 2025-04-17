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
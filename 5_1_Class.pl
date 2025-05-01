%make sure to add a base case when using recursion
predecessor(X,Z) :- parent(X,Z). %this terminates the recursion
predecessor(X,Y) :- parent(X,Y), predecessor(Y,Z).

%if x is the parent of Z, then stop. if X is the parent of Y then recursively call predecessor with Y and Z

just_ate(cat,mouse).
just_ate(mouse,cheese).

%QUESTION 1

%base case: direct consumption
is_digesting(X,Y) :- just_ate(X,Y).

%recursion
is_digesting(X,Y) :- just_ate(X,Z), is_digesting(Z,Y).


%QUESTION 2 - representing a tree in swiprolog
%node(value, left, right)
node(2, node(1, nil, nil), node(6, node(4, node(3, nil, nil), node(5, nil, nil)), node(7, nil, nil))).

%FIRST PROGRAMMING QUESTION
%it will be how to make a singly linked list with recursive structures
%so like node(value, next)?
node(2, node(3, node(4, nil))).

%how do we add a new node? to make it simple we can add it to the start
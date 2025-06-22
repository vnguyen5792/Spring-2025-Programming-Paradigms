add_front(L,E,NList) :- NList = node(E,L).

add_back(nil,E,NList) :- NList = node(E,nil).

add_back(node(Head,Tail),E,NList) :-
    add_back(Tail,E,NewTail),
    NList = node(Head,NewTail).


delete_front(node(_, Tail), Tail).

delete_back(node(_, nil), nil).

delete_back(node(Head, Tail), node(Head, NewTail)) :-
    delete_back(Tail, NewTail).

% Base case: An empty list has zero nodes
count_nodes(nil, 0).

% Recursive case: Count nodes in non-empty list
count_nodes(node(_, Tail), Count) :-
    count_nodes(Tail, TailCount),
    Count is TailCount + 1.

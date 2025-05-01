//n is the number of disks that we have on the source rung?

let rec hanoi n source target auxillary =
    match n with
    | 1 -> printfn "Move disk 1 from %s to %s" source target
    | _ ->
        hanoi (n - 1) source auxillary target
        printfn "Move disk %d from %s to %s" n source target
        hanoi (n - 1) auxillary target source

let numberOfDisks = 3
hanoi numberOfDisks "Source" "Target" "Auxillary"
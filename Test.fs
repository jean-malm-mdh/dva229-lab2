namespace Lab2



[<RequireQualifiedAccess>]
module Test =



  open FsCheck



  let catchWithFalse (f : Lazy<bool>) =
    try f.Force () with | _ -> false



  // backticks allow for spaces in names
  type ``Lab2 list functions`` =
    static member Mem (x : int) (xs : int list) =
      lazy (List.contains x xs = Lab2.List.mem x xs)
      |> catchWithFalse



    static member Union (xs : int list) (ys : int list) =
      try
        let result =
          Lab2.List.union xs ys
          |> List.sort

        Set.union (Set.ofList xs) (Set.ofList ys)
        |> Set.toList
        |> List.sort
        |> (=) result

      with
      | _ -> false



    static member Foo1 (x : int) (xs : int list) =
      try
        let n = List.sumBy (fun y -> if x = y then 1 else 0) xs

        Seq.replicate n x
        |> Seq.toList
        |> (=) (Lab2.List.foo1 x xs)

      with
      | _ -> false



    static member Foo2 (x : int) (xs : int list) =
      try
        let eq  a b = a = b
        let lt  a b = a < b
        let gt  a b = a > b
        let neq a b = a = b

        Lab2.List.foo2 eq  x xs = List.filter (eq  x) xs &&
        Lab2.List.foo2 lt  x xs = List.filter (lt  x) xs &&
        Lab2.List.foo2 gt  x xs = List.filter (gt  x) xs &&
        Lab2.List.foo2 neq x xs = List.filter (neq x) xs

      with
      | _ -> false



  module List =
    let mem () = Check.Quick ``Lab2 list functions``.Mem



    let union () = Check.Quick ``Lab2 list functions``.Union



    let foo1 () = Check.Quick ``Lab2 list functions``.Foo1



    let foo2 () = Check.Quick ``Lab2 list functions``.Foo2



    let all () = Check.QuickAll<``Lab2 list functions``>()



  // backticks allow for spaces in names
  type ``Lab2 BST functions`` =
    static member SortList (xs : int list) =
      lazy (BST.sortList xs = List.sort xs)
      |> catchWithFalse



  module BST =
    let sortList () = Check.Quick ``Lab2 BST functions``.SortList



    let all () = Check.QuickAll<``Lab2 BST functions``>()



  let all () =
    Check.QuickAll<``Lab2 list functions``>()
    Check.QuickAll<``Lab2 BST functions``>()

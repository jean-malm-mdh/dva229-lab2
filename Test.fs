namespace Lab2



[<RequireQualifiedAccess>]
module Test =



  open FsCheck



  let catchWithFalse (f : Lazy<bool>) =
    try f.Force () with | _ -> false
  
  let allAreTrue conds =
    let _and a b = a && b
    List.reduce _and conds


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
  
  type ``Lab2 Tree functions`` =

    static member isEmptyProperty (e : int) =
      [
        Tree.empty 
          |> Tree.isEmpty = true ;
        Tree.leaf e 
          |> Tree.isEmpty = false ;
        (Tree.root (Tree.empty) e (Tree.empty)) 
          |> Tree.isEmpty = false ;
      ] |> allAreTrue
    static member isLeafProperty (e : int) =
      [
        Tree.empty 
          |> Tree.isLeaf = false ;
        Tree.leaf e 
          |> Tree.isLeaf = true ;
        (Tree.root (Tree.empty) e (Tree.empty)) 
          |> Tree.isLeaf = false ;
      ] |> allAreTrue
    static member canExtractHead (e : int) =
      let checkEmptyHead () =
        try
          // head on empty should throw some exception
          Tree.head (Tree.empty)
          // Hence, if we reach this point without raising an issue, fail the test
          false
        with 
        | _ -> true

      let testLeaf = Tree.leaf e
      [
        checkEmptyHead ();
        testLeaf 
          |> Tree.head = e ;
        (Tree.root (Tree.leaf e / 2) e (Tree.leaf e / 4)) 
          |> Tree.head = e ;
      ] |> allAreTrue

  module Tree =
    let emptyTree () = Check.Quick ``Lab2 Tree functions``.isEmptyProperty

    let leafTree () = Check.Quick ``Lab2 Tree functions``.isLeafProperty
    
    let all () = Check.QuickAll<``Lab2 Tree functions``>()
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
    Check.QuickAll<``Lab2 Tree functions``>()
    Check.QuickAll<``Lab2 BST functions``>()

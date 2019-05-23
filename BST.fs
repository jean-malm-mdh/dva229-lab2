namespace Lab2



module BST =



  // You cannot declare a new type for BSTs!
  // Instead, make use of the interface you defined in Tree.fs.



  // val insert : int -> Tree -> Tree
  // Given an integer x and a BST t1, it returns a BST t2 containing all
  // elements in t1 as well as x. x is inserted, even if x is already in t1.



  // let insert...



  // val insertList : int list -> Tree
  // Given an integer list xs and a BST t1, it returns a BST t2 containing
  // all elements in t1 as well as all x in xs. All x in xs are inserted,
  // even if they are already in t1.
  //
  // Note:
  //   * Define insertList using insert.



  // let insertList...



  // val ofList : int list -> Tree
  // Given an integer list xs, it returns a BST containing all x in xs.
  //
  // Note:
  //   * Define ofList using insertList.



  // let ofList...



  // val toList : Tree -> int list
  // Given a tree t, it returns a list of integers xs.
  // xs contains all elements in t, sorted in ascending order.
  //
  // Hint:
  //   * Define toList as an inorder traversal of t.
  //
  // Note:
  //   * You cannot use any builtin sorting functions.



  // let toList...



  // val sortList : int list -> int list
  // Given an integer list xs, it returns an integer list ys.
  // ys contains all elements in xs, sorted in ascending order.
  //
  // Note:
  //   * You cannot use any builtin sorting functions.



  let sortList xs = failwith "Error @ sortList: Not implemented!"
